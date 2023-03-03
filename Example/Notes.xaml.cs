using CsvHelper;
using System.Globalization;
using System.IO;
using System.Windows;

namespace Prog_124_W23_Lecture_16_ReadCSV.Example
{
    /// <summary>
    /// Interaction logic for Notes.xaml
    /// </summary>
    public partial class Notes : Window
    {
        public Notes()
        {
            InitializeComponent();
            SaveToFile();
            

        } // Notes()

        #region Save

        public void SaveToFile()
        {
            CultureInfo ci = CultureInfo.InvariantCulture;


            // Append - Continue to add to our code
            using (var stream = File.Open(FileLocation_Ex.dataExample, FileMode.OpenOrCreate))
            using (var writer = new StreamWriter(stream))
            using (var csvWriter = new CsvWriter(writer, ci))
            {

                // Grabbing text from first name, saving it as a field
                csvWriter.WriteField("Field1");
                // Grabbing grade and saving as a second field
                csvWriter.WriteField("Field2");
                // Going to next record
                csvWriter.NextRecord();
                //// flushing writer
                writer.Flush();
            }
        }

        //public void SaveToFile()
        //{
        //    CultureInfo ci = CultureInfo.InvariantCulture;


        //    // Append - Continue to add to our code
        //    using (var stream = File.Open(FilePaths.dataPath, FileMode.Append))
        //    using (var writer = new StreamWriter(stream))
        //    using (var csvWriter = new CsvWriter(writer, ci))
        //    {

        //        // Grabbing text from first name, saving it as a field
        //        csvWriter.WriteField(txtFirstName.Text);
        //        // Grabbing grade and saving as a second field
        //        csvWriter.WriteField(txtGrade.Text);
        //        // Going to next record
        //        csvWriter.NextRecord();
        //        //// flushing writer
        //        writer.Flush();
        //    }
        //}

        //public void SaveList()
        //{
        //    CultureInfo ci = CultureInfo.InvariantCulture;
        //    string filePath = FilePaths.playerPath;

        //    using (var stream = File.Open(filePath, FileMode.OpenOrCreate))
        //    using (var writer = new StreamWriter(stream))
        //    using (var csvWriter = new CsvWriter(writer, ci))
        //    {
        //        // .WriteRecords(list);
        //        csvWriter.WriteRecords(players);
        //        writer.Flush();
        //    }
        //} // SaveList


        #endregion

        #region Read
        public void ReadFile()
        {

            //string filePath = Directory.GetCurrentDirectory() + @"\Example\CSV_Files\data.csv";

            //using (StreamReader sr = new StreamReader(filePath))
            //{
            //    runDisplay.Text = "";
            //    string line = sr.ReadLine();
            //    string[] splitLine = line.Split(",");

            //    for (int i = 0; i < splitLine.Length; i++)
            //    {
            //        runDisplay.Text += splitLine[i] + "\n";
            //    }
            //}
        }

        //public void ReadFileCSV_Helper()
        //{
        //    string filePath = FileLocation.csvLocation;

        //    using(StreamReader reader = new StreamReader(filePath))
        //    {
        //        using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        //        {
        //            while(csv.Read())
        //            {
        //                string val1 = csv.GetField(0);
        //                string val2 = csv.GetField(1);
        //                string val3 = csv.GetField(2);

        //                runDisplay.Text += $"{val1} \n" +
        //                    $"{val2} \n " +
        //                    $"{val3} \n";

        //            }
        //        }
        //    }
        //}


        //public void ReadPlayerFile()
        //{
        //    string filePath = Directory.GetCurrentDirectory() + @"\CSV_Files\players.csv";
        //    using (var reader = new StreamReader(filePath))
        //    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        //    {
        //        players = csv.GetRecords<Player>().ToList<Player>();
        //    }

        //}
        #endregion




    }
}
