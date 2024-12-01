namespace GestureDrawingApp
{
    partial class Settings
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtImageFolder = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.nudTimeInSeconds = new System.Windows.Forms.NumericUpDown();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeInSeconds)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Image folder path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Timer time in seconds";
            // 
            // txtImageFolder
            // 
            this.txtImageFolder.Location = new System.Drawing.Point(126, 38);
            this.txtImageFolder.Name = "txtImageFolder";
            this.txtImageFolder.Size = new System.Drawing.Size(297, 20);
            this.txtImageFolder.TabIndex = 2;
            this.txtImageFolder.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(389, 115);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // nudTimeInSeconds
            // 
            this.nudTimeInSeconds.Location = new System.Drawing.Point(127, 64);
            this.nudTimeInSeconds.Name = "nudTimeInSeconds";
            this.nudTimeInSeconds.Size = new System.Drawing.Size(120, 20);
            this.nudTimeInSeconds.TabIndex = 5;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(429, 38);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(308, 115);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 150);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.nudTimeInSeconds);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtImageFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Settings";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeInSeconds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtImageFolder;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown nudTimeInSeconds;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnCancel;
    }
}