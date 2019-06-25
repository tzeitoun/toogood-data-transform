﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Toogood_Data_Transform
{
    class Program
    {
        static void printUsage()
        {
            Console.WriteLine("Toogood Data Transform: Usage: toogoodt [filename] [file_format]");
            Console.WriteLine(" File_format may be: Type1, Type2");
        }

        static void Main(string[] args)
        {
            /* First argument from the command line would be the filename,
             * Second argument would be the file type.
             * Create the appropriate file reader.
             */
            // Verify arguments
            if (args.Length < 2)
            {
                printUsage();
                return;
            }

            // Parse arguments
            string filename = args[0];
            string typeinput = args[1];
            InputFileType inputFileType;
            if (typeinput == "Type1")
            {
                inputFileType = InputFileType.Type1;
            }
            else if (typeinput == "Type2")
            {
                inputFileType = InputFileType.Type2;
            }
            else
            {
                printUsage();
                return;
            }

            // Create file reader (will "read" file)
            FileReader fileReader = new FileReader(filename, inputFileType);

            // Create file transformer
            FileTransform fileTransform = new FileTransform(fileReader);

            // Transform records...
            fileTransform.TransformRecords();

            // Get the records in the standard format and write them to a new file
            List<AccountRecord> standardRecords = fileTransform.TargetRecords;
            for (int i = 0; i < standardRecords.Count; i++)
            {
                string standardRecord = standardRecords[i].getRecord();
                Console.WriteLine(standardRecord);
            }


        }
    }
}
