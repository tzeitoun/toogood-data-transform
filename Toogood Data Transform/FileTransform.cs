using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Toogood_Data_Transform
{
    class FileTransform
    {
        public List<AccountRecord> TargetRecords { private set; get; }

        private FileReader fileReader;
        public InputFileType FileType { private set; get; }
        
        /// <summary>
        /// Create a new File Transformer for ingesting files from the specified File Reader.
        /// </summary>
        public FileTransform(FileReader fileReader)
        {
            FileType = fileReader.inputFileType;
            this.fileReader = fileReader;
        }

        /// <summary>
        /// Transform a set of records according to the filetype set upon instantiation.
        /// </summary>
        /// <param name="records"></param>
        /// <returns></returns>
        public List<AccountRecord> TransformRecords()
        {
            TargetRecords = new List<AccountRecord>();

            //if (FileType == InputFileType.Type1)
            //{
//                transformType1(fileReader, TargetRecords);

            for (int i = 0; i < 10; i++)
            {
                AccountRecord targetRecord = new AccountRecord();

                string[] fields = fileReader.getFields(i);

                if (FileType == InputFileType.Type1)
                {
                    // Record 0 -- Identifier
                    string identifier = fields[0].ToString();  // eg. 123|AbcCode
                    string accountCode = identifier.Split('|')[1];  // eg. AbcCode
                    targetRecord.AccountCode = accountCode;

                    // Record 1 -- Account Name
                    string name = fields[1].ToString();  // eg. My Account
                    targetRecord.Name = name;

                    // Record 2 -- Account Type
                    int accountInput = 0; 
                    Int32.TryParse(fields[2].ToString(), out accountInput);  // eg. 1, 2, 3, 4
                    if (accountInput >= 1 && accountInput <= 4)
                    {
                        targetRecord.Type = (AccountType)accountInput;
                    }

                    // Record 3 -- Opened Date
                    DateTime openDate = DateTime.MinValue;  // DateTime is not nullable
                    if (DateTime.TryParse(fields[3].ToString(), out openDate))
                    {
                        targetRecord.OpenDate = openDate;
                    }

                    // Record 4 -- Currency Type
                    CurrencyType currencyType = CurrencyType.Unknown;
                    string currencyInput = fields[4].ToString();
                    if (currencyInput == "CD")
                    {
                        currencyType = CurrencyType.CAD;
                    }
                    else if (currencyInput == "US")
                    {
                        currencyType = CurrencyType.USD;
                    }
                    targetRecord.Currency = currencyType;

                }
                else if (FileType == InputFileType.Type2)
                {
                    // AccountCode
                    string custodianCode = fields[3].ToString();  // Custodian Code
                    targetRecord.AccountCode = custodianCode;

                    // Name
                    string name = fields[0].ToString();  // eg. My Account
                    targetRecord.Name = name;

                    // Type
                    string accountInput = fields[1];
                    AccountType accountType;
                    if (Enum.TryParse(accountInput, out accountType))
                    {
                        targetRecord.Type = accountType;
                    }

                    // Open Date
                    // not available in this file format

                    // Currency
                    string currencyInput = fields[2].ToString();
                    if (currencyInput == "C")
                    {
                        targetRecord.Currency = CurrencyType.CAD;
                    }
                    else if (currencyInput == "U")
                    {
                        targetRecord.Currency = CurrencyType.USD;
                    }

                }
                
                TargetRecords.Add(targetRecord);
            }

            return TargetRecords;
        }

        /// <summary>
        /// 
        /// </summary>
        //private void transformType1(FileReader fileReader, List<AccountRecord> accountRecords)
        //{

        //}
    }
}
