using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestureDrawingApp
{
    public partial class Settings : Form
    {
        public Settings()
        {

            InitializeComponent();
            LoadSettings();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void LoadSettings()
        {
            // Load the current settings from config.txt
            var (imageFolderPath, timeInSeconds) = Program.ReadConfig();

            // Populate the UI with the loaded settings
            txtImageFolder.Text = imageFolderPath;
            nudTimeInSeconds.Value = timeInSeconds;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtImageFolder.Text = folderDialog.SelectedPath;
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate the inputs
            string imageFolderPath = txtImageFolder.Text.Trim();
            if (string.IsNullOrEmpty(imageFolderPath) || !Directory.Exists(imageFolderPath))
            {
                MessageBox.Show("Please enter a valid image folder path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int timeInSeconds = (int)nudTimeInSeconds.Value;

            // Save the updated settings to the config file
            Program.UpdateConfig(imageFolderPath, timeInSeconds);

            // Notify the user and close the form
            MessageBox.Show("Settings saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
