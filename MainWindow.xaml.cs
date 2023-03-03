using CsvHelper;
using Prog_124_W23_Lecture_16_ReadCSV.Example;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

namespace Prog_124_W23_Lecture_16_ReadCSV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<VideoGameSystem> systems = new List<VideoGameSystem>();

        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show(systems.Count.ToString());
            //PreloadVideoGames();

        }

        #region Events

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            SaveToFile(FileMode.OpenOrCreate);
        } // btnCreate_Click

        private void btnAppend_Click(object sender, RoutedEventArgs e)
        {
            SaveToFile(FileMode.Append);
        } // btnAppend_Click

        private void btnSaveGameSystems_Click(object sender, RoutedEventArgs e)
        {
            SaveList();
        }

        private void btnLoadGameSystems_Click(object sender, RoutedEventArgs e)
        {
            ReadFullList();
            DisplayVideoGames();
        }

        #endregion

      public void DisplayVideoGames()
        {
            runDisplay.Text = "";

            foreach (VideoGameSystem vgs in systems)
            {
                runDisplay.Text += vgs + "\n";
            }
        }

        #region Save File

        public void SaveList()
        {
            CultureInfo ci = CultureInfo.InvariantCulture;
            string filePath = FilePaths.videoGameFilePath;

            using (var stream = File.Open(filePath, FileMode.OpenOrCreate))
            using (var writer = new StreamWriter(stream))
            using (var csvWriter = new CsvWriter(writer, ci))
            {
                // .WriteRecords(list);
                csvWriter.WriteRecords(systems);
                writer.Flush();
            }
        } // SaveList

        public void SaveToFile(FileMode mode)
        {
            CultureInfo ci = CultureInfo.InvariantCulture;
            // Append - Continue to add to our code
            
            using (var stream = File.Open(FilePaths.studentFilePath, mode))
            using (var writer = new StreamWriter(stream))
            using (var csvWriter = new CsvWriter(writer, ci))
            {

                // Grabbing text from first name, saving it as a field
                csvWriter.WriteField(txtFirstName.Text);
                // Grabbing grade and saving as a second field
                csvWriter.WriteField(txtLastName.Text);
                // Grabbing grade and saving as a second field
                csvWriter.WriteField(txtGrade.Text);
                // Going to next record
                csvWriter.NextRecord();
                //// flushing writer
                writer.Flush();
            }
            MessageBox.Show("File was saved");
        }

        #endregion


        #region Read File

        // Read back a full list , as a type
        public void ReadFullList()
        {
            string filePath = FilePaths.videoGameFilePath;

            using(StreamReader sr = new StreamReader(filePath))
            using(CsvReader csv = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                // Pull the entire csv file as a list of VideoGameSystem
                // For this to work, class must have a default constructor,
                // and properties must be the EXACT SAME NAME AND SPELLING AS HEADERS IN CSV
                systems = csv.GetRecords<VideoGameSystem>().ToList<VideoGameSystem>();
            }

        }


        //public void ReadPlayerFile()
        //{
        //    string filePath = Directory.GetCurrentDirectory() + @"\CSV_Files\players.csv";
        //    using (var reader = new StreamReader(filePath))
        //    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        //    {
        //        players = csv.GetRecords<Player>().ToList<Player>();
        //    }

        //}

        public void ReadFileNoHelper()
        {
 

            // Using StreamReader
            using (StreamReader sr = new StreamReader(FilePaths.filePath))
            { // OPens connection to file

                // Runs until the end of the file
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine(); // returns a line as a string
                    string[] split = line.Split(",");

                    // How we are formatting how the line is displayed
                    foreach (string field in split)
                    {
                        runDisplay.Text += field + " ";
                    }
                    runDisplay.Text += "\n";
                }
            } // Closes connection to file

        } // ReadFileNoHelper()

        // Read a csv WITH CSVHelper
        public void ReadFileWithCSV_Helper()
        {
            string filePath = FilePaths.filePath;
            CultureInfo info = CultureInfo.InvariantCulture;

            double average = 0;
            int count = 0;

            using (StreamReader sr = new StreamReader(filePath))
            using (CsvReader csv = new CsvReader(sr, info))
            {
                while (csv.Read())
                {
                    count++;

                    string firstName = csv.GetField(0);
                    string lastName = csv.GetField(1);
                    int grade = csv.GetField<int>(2);

                    average += grade;

                    runDisplay.Text += $"{count} : First Name: {firstName} - Last Name: {lastName} \n";

                }

                runDisplay.Text += $"Average Grade: {average / count}";
            }
        }

        #endregion

        public void PreloadVideoGames()
        {
            systems.Add(new VideoGameSystem()
            {
                Company = "Sony",
                SystemName = "Playstation 5",
                Storage = "Blu Ray",
                InventoryCount = 10000

            });

            systems.Add(new VideoGameSystem("Nintendo", "N64", "Catridge", 1888));
            systems.Add(new VideoGameSystem("Nintendo", "Gamecube", "Mini CD", 1888));
            systems.Add(new VideoGameSystem("Sega", "Dreamcast", "Dvd", 1888));
        }
    }
}
