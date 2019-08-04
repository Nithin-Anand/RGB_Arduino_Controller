# RGB_Arduino_Controller

## Description

A GUI for setting RGB values over serial for a WS8211 LED strip, connected to an Arduino. Allows for updating the colours of the LEDs without needing to modify, recompile and reupload Arduino code. Currently the program allows for the setting of (255, 255, 255) solid colour LEDs.

### Libraries Used

In the Arduino source, the [FastLED](http://fastled.io/) and [CmdMessenger](https://github.com/thijse/Arduino-CmdMessenger) libraries are used.

For the C# code, the CmdMessenger source files are bundled with the project files.

## TODO

1. Refactor code
2. Add Documentation
3. Re-do comments and attribute everything properly
4. Add support for LED lighting effects
5. Clean up the build files
