using System;
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
        Type1,
        Type2
    }

    class FileReader
    {
        public InputFileType FileType { private set; get; }
        string[][] recordFields;

        /// <summary>
        /// Create a new FileReader for the specified input file type.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="inputFileType"></param>
        public FileReader(string filename, InputFileType inputFileType)
        {
            FileType = inputFileType;
            int recordsCount = 10;

            recordFields = new string[recordsCount][];
        
            // Open CSV file...

            int accountTypeLength = Enum.GetNames(typeof(AccountType)).Length;
            int currencyTypeLength = Enum.GetNames(typeof(CurrencyType)).Length;

            DateTime startDate = DateTime.Now;

            // Read and parse CSV data here...  (Actually generate pretend records)
            for (int i = 0; i < recordsCount; i++)
            {
                // "Read" from file...
                string fileRecord;

                if (inputFileType == InputFileType.Type1)
                {
                    fileRecord =
                        (i+1) * 100 + "|AbcCode"
                        + "," + "My Account " + i
                        + "," + (i % accountTypeLength)
                        + "," + startDate.AddDays(i)
                        + "," + ((i % currencyTypeLength) == 1 ? "US" : "CD")
                        ;
                }
                else if (inputFileType == InputFileType.Type2)
                {
                    fileRecord =
                        "My Account " + i
                        + "," + Enum.GetName(typeof(AccountType), (AccountType)(i % accountTypeLength))
                        + "," + ((i % currencyTypeLength) == 1 ? "U" : "C")
                        + "," + ((i % 3) == 1 ? startDate.AddDays(i).ToShortDateString() : "")
                        ;
                }
                else
                {
                    fileRecord = "";
                }
                // Parse and store into array
                recordFields[i] = fileRecord.Split(',');
            }


        }

    }
}
