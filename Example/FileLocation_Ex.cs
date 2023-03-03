using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Prog_124_W23_Lecture_16_ReadCSV.Example
{
    public static class FileLocation_Ex
    {

        private static string projectLocation = Directory.GetCurrentDirectory();
        private static string folder = @"\DataExample\";
        private static string dataExamplefile = @"example_data.csv";

        public static string dataExample = projectLocation + folder + dataExamplefile;

        static FileLocation_Ex()
        {
            
        }

    }
}
