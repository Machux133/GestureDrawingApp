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
    public partial class Form1 : Form
    {
        private Timer _imageTimer;
        private Timer _countdownTimer;
        private string[] _imageFiles;
        private int _currentImageIndex;
        private int _timeLeft;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeImageSlideshow()
        {
            // Read settings from the config file
            var (imageFolderPath, timeInSeconds) = Program.ReadConfig();

            // Validate and retrieve image files from the folder
            if (Directory.Exists(imageFolderPath))
            {
                _imageFiles = Directory.GetFiles(imageFolderPath, "*.*")
                                       .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                                   f.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                                                   f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                                                   f.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase))
                                       .ToArray();
            }

            if (_imageFiles == null || _imageFiles.Length == 0)
            {
                MessageBox.Show("No images found in the selected folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Initialize or reset the image change Timer
            _imageTimer?.Stop();
            _imageTimer = new Timer
            {
                Interval = timeInSeconds * 1000 // Convert seconds to milliseconds
            };
            _imageTimer.Tick += OnImageTimerTick;
            _imageTimer.Start();

            // Initialize or reset the countdown Timer
            _countdownTimer?.Stop();
            _countdownTimer = new Timer
            {
                Interval = 1000 // 1-second interval
            };
            _countdownTimer.Tick += OnCountdownTimerTick;
            _countdownTimer.Start();

            // Set the initial countdown
            _timeLeft = timeInSeconds;
            label1.Text = $"Time left: {_timeLeft} seconds";

            // Start with the first image
            _currentImageIndex = 0;
            DisplayImage();
        }

        private void OnImageTimerTick(object sender, EventArgs e)
        {
            // Move to the next image
            _currentImageIndex = (_currentImageIndex + 1) % _imageFiles.Length;
            DisplayImage();

            // Reset the countdown
            var (_, timeInSeconds) = Program.ReadConfig();
            _timeLeft = timeInSeconds;
        }

        private void OnCountdownTimerTick(object sender, EventArgs e)
        {
            // Update the countdown
            if (_timeLeft > 0)
            {
                _timeLeft--;
                label1.Text = $"Time left: {_timeLeft} seconds";
            }
        }

        private void DisplayImage()
        {
            try
            {
                // Safely dispose of the current image
                pictureBox1.Image?.Dispose();
                pictureBox1.Image = Image.FromFile(_imageFiles[_currentImageIndex]);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Dispose the timers to release resources
            _imageTimer?.Stop();
            _imageTimer?.Dispose();
            _countdownTimer?.Stop();
            _countdownTimer?.Dispose();
            base.OnFormClosing(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Open the settings form as a dialog
            Settings settings = new Settings();
            settings.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Optional: Add any functionality for when the PictureBox is clicked
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Initialize the slideshow when the button is clicked
            InitializeImageSlideshow();
            button1.Hide();
            button2.Hide();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
