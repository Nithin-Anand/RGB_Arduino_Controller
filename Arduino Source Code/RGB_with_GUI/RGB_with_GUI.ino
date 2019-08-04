#include <FastLED.h>
#include <CmdMessenger.h>  // CmdMessenger

FASTLED_USING_NAMESPACE

// FastLED "100-lines-of-code" demo reel, showing just a few 
// of the kinds of animation patterns you can quickly and easily 
// compose using FastLED.  
//
// This example also shows one easy way to define multiple 
// animations patterns and have them automatically rotate.
//
// -Mark Kriegsman, December 2014

#if defined(FASTLED_VERSION) && (FASTLED_VERSION < 3001000)
#warning "Requires FastLED 3.1 or later; check github for latest code."
#endif

#define DATA_PIN    12
//#define CLK_PIN   4
#define LED_TYPE    WS2811
#define COLOR_ORDER GRB
#define NUM_LEDS    30
CRGB leds[NUM_LEDS];

#define BRIGHTNESS          96
#define FRAMES_PER_SECOND  120

const int kBlinkLed            = 12;  // Pin of internal Led
bool ledState                  = 1;   // Current state of Led
float ledFrequency             = 1.0; // Current blink frequency of Led

int RED = 0;
int GREEN = 0;
int BLUE = 0;

bool glitter;

uint8_t gCurrentPatternNumber = 0; // Index number of which pattern is current

CmdMessenger cmdMessenger = CmdMessenger(Serial);

enum
{
  kAcknowledge,
  kError,
  kSetLed, // Command to request led to be set in specific state
  kSetLedFrequency,
  kSetRed,
  kSetGreen,
  kSetBlue,
  kAddGlitter,
};

void attachCommandCallbacks()
{
  // Attach callback methods
  cmdMessenger.attach(OnUnknownCommand);
  cmdMessenger.attach(kSetLed, OnSetLed);
  cmdMessenger.attach(kSetRed, OnSetRed);
  cmdMessenger.attach(kSetGreen, OnSetGreen);
  cmdMessenger.attach(kSetBlue, OnSetBlue);
  cmdMessenger.attach(kAddGlitter, OnSetGlitter);
}

void OnUnknownCommand()
{
  cmdMessenger.sendCmd(kError,"Command without attached callback");
}

// Callback function that sets led on or off
void OnSetLed()
{
  // Read led state argument, interpret string as boolean
  ledState = cmdMessenger.readBoolArg();
  cmdMessenger.sendCmd(kAcknowledge,ledState);
}

void OnSetRed()
{
  RED = int(cmdMessenger.readFloatArg());
  cmdMessenger.sendCmd(kAcknowledge, RED);
}

void OnSetGreen()
{
  GREEN = int(cmdMessenger.readFloatArg());
  cmdMessenger.sendCmd(kAcknowledge, GREEN);
}

void OnSetBlue()
{
  BLUE = int(cmdMessenger.readFloatArg());
  cmdMessenger.sendCmd(kAcknowledge, BLUE);
}

void OnSetGlitter()
{
  glitter = cmdMessenger.readBoolArg();
  if (glitter == 1) {  gCurrentPatternNumber = 1;  }
  else {  gCurrentPatternNumber = 0;  }
  cmdMessenger.sendCmd(kAcknowledge, "Glitter changed!");
}


void setup() {
  delay(3000); // 3 second delay for recovery
  Serial.begin(9600);
  attachCommandCallbacks();
  cmdMessenger.sendCmd(kAcknowledge,"Arduino has started!");

  // tell FastLED about the LED strip configuration
  FastLED.addLeds<LED_TYPE,DATA_PIN,COLOR_ORDER>(leds, NUM_LEDS).setCorrection(TypicalLEDStrip);
  //FastLED.addLeds<LED_TYPE,DATA_PIN,CLK_PIN,COLOR_ORDER>(leds, NUM_LEDS).setCorrection(TypicalLEDStrip);

  // set master brightness control
  FastLED.setBrightness(BRIGHTNESS);
}


// List of patterns to cycle through.  Each is defined as a separate function below.
typedef void (*SimplePatternList[])();
SimplePatternList gPatterns = { solidColour, colourWithGlitter , confetti, sinelon, juggle, bpm };

uint8_t gHue = 0; // rotating "base color" used by many of the patterns
  
void loop()
{ 
  // Call the current pattern function once, updating the 'leds' array
  gPatterns[gCurrentPatternNumber]();
  // send the 'leds' array out to the actual LED strip
  FastLED.show();  
  // insert a delay to keep theframerate modest
  FastLED.delay(1000/FRAMES_PER_SECOND); 
  // Process incoming serial data, and perform callbacks
  cmdMessenger.feedinSerialData();
  delay(10);
}

#define ARRAY_SIZE(A) (sizeof(A) / sizeof((A)[0]))

void nextPattern()
{
  // add one to the current pattern number, and wrap around at the end
  gCurrentPatternNumber = (gCurrentPatternNumber + 1) % ARRAY_SIZE( gPatterns);
}

void solidColour() 
{

  fill_solid( leds , NUM_LEDS, CRGB(RED, GREEN, BLUE));
}

void colourWithGlitter() 
{
  // built-in FastLED rainbow, plus some random sparkly glitter
  solidColour();
  addGlitter(80);
}

void addGlitter( fract8 chanceOfGlitter) 
{
  if( random8() < chanceOfGlitter) {
    leds[ random16(NUM_LEDS) ] += CRGB::White;
  }
}

void confetti() 
{
  // random colored speckles that blink in and fade smoothly
  fadeToBlackBy( leds, NUM_LEDS, 10);
  int pos = random16(NUM_LEDS);
  leds[pos] += CHSV( gHue + random8(64), 200, 255);
}

void sinelon()
{
  // a colored dot sweeping back and forth, with fading trails
  fadeToBlackBy( leds, NUM_LEDS, 20);
  int pos = beatsin16( 13, 0, NUM_LEDS-1 );
  leds[pos] += CHSV( gHue, 255, 192);
}

void bpm()
{
  // colored stripes pulsing at a defined Beats-Per-Minute (BPM)
  uint8_t BeatsPerMinute = 62;
  CRGBPalette16 palette = PartyColors_p;
  uint8_t beat = beatsin8( BeatsPerMinute, 64, 255);
  for( int i = 0; i < NUM_LEDS; i++) { //9948
    leds[i] = ColorFromPalette(palette, gHue+(i*2), beat-gHue+(i*10));
  }
}

void juggle() {
  // eight colored dots, weaving in and out of sync with each other
  fadeToBlackBy( leds, NUM_LEDS, 20);
  byte dothue = 0;
  for( int i = 0; i < 8; i++) {
    leds[beatsin16( i+7, 0, NUM_LEDS-1 )] |= CHSV(dothue, 200, 255);
    dothue += 32;
  }
}
