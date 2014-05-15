namespace KinectTest1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.KinectIdLabel = new System.Windows.Forms.Label();
            this.KinectStatusLabel = new System.Windows.Forms.Label();
            this.LaunchButton = new System.Windows.Forms.Button();
            this.KinectIdValue = new System.Windows.Forms.Label();
            this.KinectStatusValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // KinectIdLabel
            // 
            this.KinectIdLabel.AutoSize = true;
            this.KinectIdLabel.Location = new System.Drawing.Point(29, 27);
            this.KinectIdLabel.Name = "KinectIdLabel";
            this.KinectIdLabel.Size = new System.Drawing.Size(55, 13);
            this.KinectIdLabel.TabIndex = 0;
            this.KinectIdLabel.Text = "KinectId : ";
            // 
            // KinectStatusLabel
            // 
            this.KinectStatusLabel.AutoSize = true;
            this.KinectStatusLabel.Location = new System.Drawing.Point(32, 59);
            this.KinectStatusLabel.Name = "KinectStatusLabel";
            this.KinectStatusLabel.Size = new System.Drawing.Size(46, 13);
            this.KinectStatusLabel.TabIndex = 1;
            this.KinectStatusLabel.Text = "Status : ";
            // 
            // LaunchButton
            // 
            this.LaunchButton.Location = new System.Drawing.Point(317, 384);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.Size = new System.Drawing.Size(75, 23);
            this.LaunchButton.TabIndex = 2;
            this.LaunchButton.Text = "Start";
            this.LaunchButton.UseVisualStyleBackColor = true;
            this.LaunchButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // KinectIdValue
            // 
            this.KinectIdValue.AutoSize = true;
            this.KinectIdValue.Location = new System.Drawing.Point(107, 26);
            this.KinectIdValue.Name = "KinectIdValue";
            this.KinectIdValue.Size = new System.Drawing.Size(10, 13);
            this.KinectIdValue.TabIndex = 3;
            this.KinectIdValue.Text = "-";
            // 
            // KinectStatusValue
            // 
            this.KinectStatusValue.AutoSize = true;
            this.KinectStatusValue.Location = new System.Drawing.Point(107, 59);
            this.KinectStatusValue.Name = "KinectStatusValue";
            this.KinectStatusValue.Size = new System.Drawing.Size(10, 13);
            this.KinectStatusValue.TabIndex = 4;
            this.KinectStatusValue.Text = "-";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 484);
            this.Controls.Add(this.KinectStatusValue);
            this.Controls.Add(this.KinectIdValue);
            this.Controls.Add(this.LaunchButton);
            this.Controls.Add(this.KinectStatusLabel);
            this.Controls.Add(this.KinectIdLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label KinectIdLabel;
        private System.Windows.Forms.Label KinectStatusLabel;
        private System.Windows.Forms.Button LaunchButton;
        private System.Windows.Forms.Label KinectIdValue;
        private System.Windows.Forms.Label KinectStatusValue;
    }
}

