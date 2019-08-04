using System;
using System.Globalization;
using System.Windows.Forms;

namespace ArduinoController
{
    public partial class ControllerForm : Form
    {
        private readonly ArduinoController _arduinoController;
        public double _RedValue = Properties.Settings.Default.initRed;
        public double _GreenValue = Properties.Settings.Default.initGreen;
        public double _BlueValue = Properties.Settings.Default.initBlue;
        public bool glitter = Properties.Settings.Default.initGlitter;
        public ControllerForm()
        {
            InitializeComponent();
            _arduinoController = new ArduinoController();
            _arduinoController.Setup(this);

        }


        // Update value label and arduinoController on value changed using slider
        private void RedTrackBarScroll(object sender, EventArgs e)
        {
            _RedValue = ((double)RedLabelTrackbar.Value) ;
            RedValue.Text = _RedValue.ToString(CultureInfo.InvariantCulture);
            _arduinoController.SetRed(_RedValue);
        }


        // Set frequency slider
        public void SetRed(double redIntensity)
        {
            RedLabelTrackbar.Value = (int) ((redIntensity));
        }

        // Update value label and arduinoController on value changed
        private void RedLabelValueChanged(object sender, EventArgs e)
        {
            RedTrackBarScroll(sender,e);
        }


        // Update value label and arduinoController on value changed using slider
        private void GreenTrackBarScroll(object sender, EventArgs e)
        {
            _GreenValue = ((double)GreenTrackBar.Value);
            GreenValue.Text = _GreenValue.ToString(CultureInfo.InvariantCulture);
            _arduinoController.SetGreen(_GreenValue);
        }


        // Set frequency slider
        public void SetGreen(double greenIntensity)
        {
            GreenTrackBar.Value = (int)((greenIntensity));
        }

        // Update value label and arduinoController on value changed
        private void GreenTrackBarValueChanged(object sender, EventArgs e)
        {
            GreenTrackBarScroll(sender, e);
        }

        // Update value label and arduinoController on value changed using slider
        private void BlueTrackBarScroll(object sender, EventArgs e)
        {
            _BlueValue = ((double)BlueTrackBar.Value);
            BlueValue.Text = _BlueValue.ToString(CultureInfo.InvariantCulture);
            _arduinoController.SetBlue(_BlueValue);
        }


        // Set frequency slider
        public void SetBlue(double blueIntensity)
        {
            BlueTrackBar.Value = (int)((blueIntensity));
        }



        // Update value label and arduinoController on value changed
        private void BlueTrackBarValueChanged(object sender, EventArgs e)
        {
            BlueTrackBarScroll(sender, e);
        }

        private void glitterCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            glitter = glitterCheckBox.Checked;
            _arduinoController.AddGlitter(glitterCheckBox.Checked);
        }





        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing )
            {
                _arduinoController.Exit();
                if (components!=null)
                components.Dispose();
            }
            base.Dispose(disposing);

        }

        private void LedFrequencyLabel_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click_1(object sender, EventArgs e)
        {

        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void ControllerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
