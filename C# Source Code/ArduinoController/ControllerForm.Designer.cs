namespace ArduinoController
{
    partial class ControllerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;



        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControllerForm));
            this.RedLabel = new System.Windows.Forms.Label();
            this.RedValue = new System.Windows.Forms.Label();
            this.RedLabelTrackbar = new System.Windows.Forms.TrackBar();
            this.GreenTrackBar = new System.Windows.Forms.TrackBar();
            this.GreenLabel = new System.Windows.Forms.Label();
            this.GreenValue = new System.Windows.Forms.Label();
            this.BlueValue = new System.Windows.Forms.Label();
            this.BlueLabel = new System.Windows.Forms.Label();
            this.BlueTrackBar = new System.Windows.Forms.TrackBar();
            this.glitterCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.RedLabelTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // RedLabel
            // 
            this.RedLabel.AutoSize = true;
            this.RedLabel.Location = new System.Drawing.Point(14, 36);
            this.RedLabel.Name = "RedLabel";
            this.RedLabel.Size = new System.Drawing.Size(27, 13);
            this.RedLabel.TabIndex = 2;
            this.RedLabel.Text = "Red";
            // 
            // RedValue
            // 
            this.RedValue.AutoSize = true;
            this.RedValue.Location = new System.Drawing.Point(304, 38);
            this.RedValue.Name = "RedValue";
            this.RedValue.Size = new System.Drawing.Size(13, 13);
            this.RedValue.TabIndex = 3;
            this.RedValue.Text = "0";
            // 
            // RedLabelTrackbar
            // 
            this.RedLabelTrackbar.LargeChange = 50;
            this.RedLabelTrackbar.Location = new System.Drawing.Point(90, 38);
            this.RedLabelTrackbar.Maximum = 255;
            this.RedLabelTrackbar.Name = "RedLabelTrackbar";
            this.RedLabelTrackbar.Size = new System.Drawing.Size(208, 45);
            this.RedLabelTrackbar.SmallChange = 5;
            this.RedLabelTrackbar.TabIndex = 1;
            this.RedLabelTrackbar.Tag = "";
            this.RedLabelTrackbar.TickFrequency = 10;
            this.RedLabelTrackbar.Scroll += new System.EventHandler(this.RedTrackBarScroll);
            this.RedLabelTrackbar.ValueChanged += new System.EventHandler(this.RedLabelValueChanged);
            // 
            // GreenTrackBar
            // 
            this.GreenTrackBar.LargeChange = 50;
            this.GreenTrackBar.Location = new System.Drawing.Point(90, 89);
            this.GreenTrackBar.Maximum = 255;
            this.GreenTrackBar.Name = "GreenTrackBar";
            this.GreenTrackBar.Size = new System.Drawing.Size(208, 45);
            this.GreenTrackBar.SmallChange = 5;
            this.GreenTrackBar.TabIndex = 1;
            this.GreenTrackBar.Tag = "";
            this.GreenTrackBar.TickFrequency = 10;
            this.GreenTrackBar.Scroll += new System.EventHandler(this.GreenTrackBarScroll);
            this.GreenTrackBar.ValueChanged += new System.EventHandler(this.GreenTrackBarValueChanged);
            // 
            // GreenLabel
            // 
            this.GreenLabel.AutoSize = true;
            this.GreenLabel.Location = new System.Drawing.Point(14, 89);
            this.GreenLabel.Name = "GreenLabel";
            this.GreenLabel.Size = new System.Drawing.Size(36, 13);
            this.GreenLabel.TabIndex = 4;
            this.GreenLabel.Text = "Green";
            this.GreenLabel.Click += new System.EventHandler(this.Label1_Click);
            // 
            // GreenValue
            // 
            this.GreenValue.AutoSize = true;
            this.GreenValue.Location = new System.Drawing.Point(304, 89);
            this.GreenValue.Name = "GreenValue";
            this.GreenValue.Size = new System.Drawing.Size(13, 13);
            this.GreenValue.TabIndex = 5;
            this.GreenValue.Text = "0";
            // 
            // BlueValue
            // 
            this.BlueValue.AutoSize = true;
            this.BlueValue.Location = new System.Drawing.Point(304, 144);
            this.BlueValue.Name = "BlueValue";
            this.BlueValue.Size = new System.Drawing.Size(13, 13);
            this.BlueValue.TabIndex = 8;
            this.BlueValue.Text = "0";
            this.BlueValue.Click += new System.EventHandler(this.Label1_Click_1);
            // 
            // BlueLabel
            // 
            this.BlueLabel.AutoSize = true;
            this.BlueLabel.Location = new System.Drawing.Point(14, 144);
            this.BlueLabel.Name = "BlueLabel";
            this.BlueLabel.Size = new System.Drawing.Size(28, 13);
            this.BlueLabel.TabIndex = 7;
            this.BlueLabel.Text = "Blue";
            this.BlueLabel.Click += new System.EventHandler(this.Label2_Click);
            // 
            // BlueTrackBar
            // 
            this.BlueTrackBar.LargeChange = 50;
            this.BlueTrackBar.Location = new System.Drawing.Point(90, 144);
            this.BlueTrackBar.Maximum = 255;
            this.BlueTrackBar.Name = "BlueTrackBar";
            this.BlueTrackBar.Size = new System.Drawing.Size(208, 45);
            this.BlueTrackBar.SmallChange = 5;
            this.BlueTrackBar.TabIndex = 6;
            this.BlueTrackBar.Tag = "";
            this.BlueTrackBar.TickFrequency = 10;
            this.BlueTrackBar.Scroll += new System.EventHandler(this.BlueTrackBarScroll);
            this.BlueTrackBar.ValueChanged += new System.EventHandler(this.BlueTrackBarValueChanged);
            // 
            // glitterCheckBox
            // 
            this.glitterCheckBox.AutoSize = true;
            this.glitterCheckBox.Checked = global::ArduinoController.Properties.Settings.Default.initGlitter;
            this.glitterCheckBox.Location = new System.Drawing.Point(17, 195);
            this.glitterCheckBox.Name = "glitterCheckBox";
            this.glitterCheckBox.Size = new System.Drawing.Size(53, 17);
            this.glitterCheckBox.TabIndex = 9;
            this.glitterCheckBox.Text = "Glitter";
            this.glitterCheckBox.UseVisualStyleBackColor = true;
            this.glitterCheckBox.CheckedChanged += new System.EventHandler(this.glitterCheckBoxCheckedChanged);
            // 
            // ControllerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(344, 256);
            this.Controls.Add(this.glitterCheckBox);
            this.Controls.Add(this.BlueValue);
            this.Controls.Add(this.BlueLabel);
            this.Controls.Add(this.BlueTrackBar);
            this.Controls.Add(this.GreenValue);
            this.Controls.Add(this.GreenLabel);
            this.Controls.Add(this.GreenTrackBar);
            this.Controls.Add(this.RedValue);
            this.Controls.Add(this.RedLabel);
            this.Controls.Add(this.RedLabelTrackbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ControllerForm";
            this.Text = "LED Colour Controller";
            this.Load += new System.EventHandler(this.ControllerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RedLabelTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label RedLabel;
        private System.Windows.Forms.Label RedValue;
        private System.Windows.Forms.TrackBar RedLabelTrackbar;
        private System.Windows.Forms.TrackBar GreenTrackBar;
        private System.Windows.Forms.Label GreenLabel;
        private System.Windows.Forms.Label GreenValue;
        private System.Windows.Forms.Label BlueValue;
        private System.Windows.Forms.Label BlueLabel;
        private System.Windows.Forms.TrackBar BlueTrackBar;
        private System.Windows.Forms.CheckBox glitterCheckBox;
    }
}

