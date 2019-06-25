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
        public List<TargetRecord> records { private set; get; }

        /// <summary>
        /// Create a new FileReader for the specified input file type.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="inputFileType"></param>
        public FileReader(string filename, InputFileType inputFileType)
        {
            records = new List<TargetRecord>();

            // Open CSV file...

            int accountTypeLength = Enum.GetNames(typeof(AccountType)).Length;
            int currencyTypeLength = Enum.GetNames(typeof(CurrencyType)).Length;

            DateTime startDate = DateTime.Now;

            // Read and parse CSV data here...  (Actually generate pretend records)
            for (int i=0; i < 10; i++)
            {
                TargetRecord targetRecord = new TargetRecord(
                    "ACNTCODE" + i,
                    "ACNTNAME" + i,
                    (AccountType)(i % accountTypeLength),
                    startDate.AddDays(i),
                    (CurrencyType)(i % currencyTypeLength)
                    );
                records.Add(targetRecord);
            }
            
        }
    }
}
