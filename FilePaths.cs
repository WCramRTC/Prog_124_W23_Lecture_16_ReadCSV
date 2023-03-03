using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_124_W23_Lecture_16_ReadCSV
{
    public static class FilePaths
    {

        // Gotten our file location
        static string mainDirectory = Directory.GetCurrentDirectory();
        static string folder = @"\InClassExample\";
        
        static string fileName = @"class_data.csv";
        static string videoGameSytemFileName = @"videoGameSystemData.csv";
        static string studentFileName = @"student_Data.csv";


        public static string filePath = mainDirectory + folder + fileName;
        public static string videoGameFilePath = mainDirectory + folder + videoGameSytemFileName;
        public static string studentFilePath = mainDirectory + folder + studentFileName;

    }
}
