﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Toogood_Data_Transform
{
    /// <summary>
    /// This class will serve as the file input. It will read the files
    /// from CSV (not implemented), and store the data as an array of TargetRecord objects.
    /// </summary>
    /// 

    enum InputFileType
    {
        Type1 = 1,
        Type2 = 2
    }

    class FileReader
    {
        public InputFileType inputFileType { private set; get; }
        string[][] recordFields;
        public int recordsCount { private set; get; }
        
        /// <summary>
        /// Create a new FileReader for the specified input file type.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="inputFileType"></param>
        public FileReader(string filename, InputFileType inputFileType)
        {
            this.inputFileType = inputFileType;
        }

        /// <summary>
        /// Read the file into the internal recordFields structure.
        /// </summary>
        /// <returns>Number of records (excluding header) read from file.</returns>
        public int ReadFile()
        {
            int recordsCount = 10;

            recordFields = new string[recordsCount][];

            // Open CSV file...
            /* Specification states that column headers are present in this file. 
             * We may want to verify them to ensure that the file is of the expected type.
             * Either way, we must ensure we don't try to parse the header line as record data
             * by reading it for verification or skipping it.
             */

            // setup for generating records below
            int accountTypeCount = Enum.GetNames(typeof(AccountType)).Length - 1; // count not including item 0 ("unknown")
            int currencyTypeCount = Enum.GetNames(typeof(CurrencyType)).Length - 1;
            DateTime startDate = DateTime.Now;

            // Read and parse CSV data here...  (Actually generate pretend records)
            for (int i = 0; i < recordsCount; i++)
            {
                // "Read" from file...
                string fileRecord;

                if (inputFileType == InputFileType.Type1)
                {
                    fileRecord =
                        (i + 1) * 100 + "|AbcCode"
                        + "," + "My Account " + i
                        + "," + (((i + accountTypeCount) % accountTypeCount) + 1)  // cycle through each account type
                        + "," + startDate.AddDays(i)
                        + "," + ((((i + currencyTypeCount) % currencyTypeCount) + 1) == 1 ? "CD" : "US")
                        ;
                }
                else if (inputFileType == InputFileType.Type2)
                {
                    fileRecord =
                        "My Account " + i  // Name
                        + "," + (((i + accountTypeCount) % accountTypeCount) + 1)  // Type
                        + "," + ((((i + currencyTypeCount) % currencyTypeCount) + 1) == 1 ? "C" : "U")  // Currency
                        + "," + "CustCode" + i  // Custodian Code
                        //+ "," + ((i1 % 3) == 1 ? startDate.AddDays(i).ToShortDateString() : "")  // Date, optional, every 3rd record
                        ;
                }
                else
                {
                    fileRecord = "";
                }
                // Parse and store into array
                recordFields[i] = fileRecord.Split(',');
            }

            this.recordsCount = recordsCount;
            return recordsCount;
        }

        /// <summary>
        /// Get the fields of an individual record. 
        /// </summary>
        /// <param name="recordIndex"></param>
        /// <returns></returns>
        public string[] getFields(int recordIndex)
        {
            return recordFields[recordIndex];
        }

    }
}
