// *** ArduinoController ***

// Written by Nithin Anand
// Last modified: 07/08/2019
// Full documentation, links and credits at https://github.com/Nithin-Anand/RGB_Arduino_Controller
// Credit to GitHub user thijse for the CmdMessenger library


using System;
using CommandMessenger;
using CommandMessenger.Queue;
using CommandMessenger.Transport.Serial;

namespace ArduinoController
{
    enum Command
    {
        Acknowledge,            // Command to acknowledge a received command
        Error,                  // Command to message that an error has occurred
        SetLed,                
        SetLedFrequency,        
        SetRed,
        SetGreen,
        SetBlue,
        AddGlitter,
    };

    public class ArduinoController
    {
        // This class (kind of) contains presentation logic, and domain model.
        // ChartForm.cs contains the view components 

        private SerialTransport   _serialTransport;
        private CmdMessenger      _cmdMessenger;
        private ControllerForm    _controllerForm;

        // ------------------ MAIN  ----------------------

        // Setup function
        public void Setup(ControllerForm controllerForm)
        {
            // storing the controller form for later reference
            _controllerForm = controllerForm;

            // Create Serial Port object
            // Note that for some boards (e.g. Sparkfun Pro Micro) DtrEnable may need to be true.
            _serialTransport = new SerialTransport
            {
                CurrentSerialSettings = { PortName = "COM3", BaudRate = 9600, DtrEnable = false } // object initializer
            };

            // Initialize the command messenger with the Serial Port transport layer
            // Set if it is communicating with a 16- or 32-bit Arduino board
            _cmdMessenger = new CmdMessenger(_serialTransport, BoardType.Bit16);

            // Tell CmdMessenger to "Invoke" commands on the thread running the WinForms UI
            _cmdMessenger.ControlToInvokeOn = _controllerForm;

            // Attach the callbacks to the Command Messenger
            AttachCommandCallBacks();
            // Attach to NewLinesReceived for logging purposes
            _cmdMessenger.NewLineReceived += NewLineReceived;

            // Attach to NewLineSent for logging purposes
            _cmdMessenger.NewLineSent += NewLineSent;                       

            // Start listening
            _cmdMessenger.Connect();



        }

        public void Init(ControllerForm controllerForm)
        {
            SetRed(controllerForm._RedValue);
            SetGreen(controllerForm._GreenValue);
            SetBlue(controllerForm._BlueValue);
            AddGlitter(controllerForm.glitter);
        }
        // Exit function
        public void Exit()
        {
            // Stop listening
            _cmdMessenger.Disconnect();

            // Dispose Command Messenger
            _cmdMessenger.Dispose();

            // Dispose Serial Port object
            _serialTransport.Dispose();
            Properties.Settings.Default.initRed = _controllerForm._RedValue;
            Properties.Settings.Default.initGreen = _controllerForm._GreenValue;
            Properties.Settings.Default.initBlue = _controllerForm._BlueValue;
            Properties.Settings.Default.initGlitter = _controllerForm.glitter;
            Properties.Settings.Default.Save();
        }



        /// Attach command call backs. 
        private void AttachCommandCallBacks()
        {
            _cmdMessenger.Attach(OnUnknownCommand);
            _cmdMessenger.Attach((int)Command.Acknowledge, OnAcknowledge);
            _cmdMessenger.Attach((int)Command.Error, OnError);
        }

        // ------------------  CALLBACKS ---------------------

        // Called when a received command has no attached function.
        // In a WinForm application, console output gets routed to the output panel of your IDE
        void OnUnknownCommand(ReceivedCommand arguments)
        {            
            Console.WriteLine(@"Command without attached callback received");
        }

        // Callback function that prints that the Arduino has acknowledged
        void OnAcknowledge(ReceivedCommand arguments)
        {
            Console.WriteLine(@" Arduino is ready");
        }

        // Callback function that prints that the Arduino has experienced an error
        void OnError(ReceivedCommand arguments)
        {
            Console.WriteLine(@"Arduino has experienced an error");
        }


        // Log received line to console
        private void NewLineReceived(object sender, CommandEventArgs e)
        {
            Console.WriteLine(@"Received > " + e.Command.CommandString());
        }

        // Log sent line to console
        private void NewLineSent(object sender, CommandEventArgs e)
        {
            Console.WriteLine(@"Sent > " + e.Command.CommandString());
        }


        public void SetRed(double red)
        {
            // Create command to start sending data
            var command = new SendCommand((int)Command.SetRed, red);

            // Put the command on the queue and wrap it in a collapse command strategy
            // This strategy will avoid duplicates of this certain command on the queue: if a SetLedFrequency command is
            // already on the queue when a new one is added, it will be replaced at its current queue-position. 
            // Otherwise the command will be added to the back of the queue. 
            // 
            // This will make sure that when the slider raises a lot of events that each send a new blink frequency, the 
            // embedded controller will not start lagging.
            _cmdMessenger.QueueCommand(new CollapseCommandStrategy(command));
        }
        public void SetGreen(double green)
        {
            // Create command to start sending data
            var command = new SendCommand((int)Command.SetGreen, green);

            // Put the command on the queue and wrap it in a collapse command strategy
            // This strategy will avoid duplicates of this certain command on the queue: if a SetLedFrequency command is
            // already on the queue when a new one is added, it will be replaced at its current queue-position. 
            // Otherwise the command will be added to the back of the queue. 
            // 
            // This will make sure that when the slider raises a lot of events that each send a new blink frequency, the 
            // embedded controller will not start lagging.
            _cmdMessenger.QueueCommand(new CollapseCommandStrategy(command));
        }
        public void SetBlue(double blue)
        {
            // Create command to start sending data
            var command = new SendCommand((int)Command.SetBlue, blue);

            // Put the command on the queue and wrap it in a collapse command strategy
            // This strategy will avoid duplicates of this certain command on the queue: if a SetLedFrequency command is
            // already on the queue when a new one is added, it will be replaced at its current queue-position. 
            // Otherwise the command will be added to the back of the queue. 
            // 
            // This will make sure that when the slider raises a lot of events that each send a new blink frequency, the 
            // embedded controller will not start lagging.
            _cmdMessenger.QueueCommand(new CollapseCommandStrategy(command));
        }

        public void AddGlitter(bool glitter)
        {
            // Create command to start sending data
            var command = new SendCommand((int)Command.AddGlitter, glitter);

            // Put the command on the queue and wrap it in a collapse command strategy
            // This strategy will avoid duplicates of this certain command on the queue: if a SetLedFrequency command is
            // already on the queue when a new one is added, it will be replaced at its current queue-position. 
            // Otherwise the command will be added to the back of the queue. 
            // 
            // This will make sure that when the slider raises a lot of events that each send a new blink frequency, the 
            // embedded controller will not start lagging.
            _cmdMessenger.QueueCommand(new CollapseCommandStrategy(command)); 
        }

        // Sent command to change led on/of state
        public void SetLedState(bool ledState)
        {
            // Create command to start sending data
            var command = new SendCommand((int)Command.SetLed, ledState);

            // Send command
            _cmdMessenger.SendCommand(new SendCommand((int)Command.SetLed, ledState));         
        }
    }
}
