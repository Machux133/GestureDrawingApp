using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestureDrawingApp
{

    internal static class Program
    {
        public static (string imageFolderPath, int timeInSeconds) ReadConfig()
        {
            string configFilePath = "config.txt";
            string defaultImagePath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            int defaultTimeInSeconds = 30;

            if (!File.Exists(configFilePath))
                return (defaultImagePath, defaultTimeInSeconds);

            try
            {
                string[] lines = File.ReadAllLines(configFilePath);
                string imageFolderPath = lines.FirstOrDefault(l => l.StartsWith("ImageFolderPath="))?.Split('=')[1]?.Trim() ?? defaultImagePath;
                string timeInSecondsString = lines.FirstOrDefault(l => l.StartsWith("TimeInSeconds="))?.Split('=')[1]?.Trim() ?? defaultTimeInSeconds.ToString();

                if (int.TryParse(timeInSecondsString, out int timeInSeconds))
                    return (imageFolderPath, timeInSeconds);

                return (imageFolderPath, defaultTimeInSeconds);
            }
            catch
            {
                return (defaultImagePath, defaultTimeInSeconds);
            }
        }

        public static void UpdateConfig(string imageFolderPath, int timeInSeconds)
        {
            string configFilePath = "config.txt";

            using (StreamWriter writer = new StreamWriter(configFilePath, false))
            {
                writer.WriteLine($"ImageFolderPath={imageFolderPath}");
                writer.WriteLine($"TimeInSeconds={timeInSeconds}");
            }
        }



        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]

        static void DropConfig()
        {
            string configFilePath = "config.txt";

            if (File.Exists(configFilePath))
            {

                return;
            }

            string userPicturesPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            int defaultTimeInSeconds = 30;
            using (StreamWriter writer = new StreamWriter(configFilePath))
            {
                writer.WriteLine($"ImageFolderPath={userPicturesPath}");
                writer.WriteLine($"TimeInSeconds={defaultTimeInSeconds}");
            }
        }



        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            DropConfig();
        }
    }
}
