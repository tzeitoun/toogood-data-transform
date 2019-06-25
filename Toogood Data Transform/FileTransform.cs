﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Toogood_Data_Transform
{
    class FileTransform
    {
        public List<AccountRecord> TargetRecords { private set; get; }
        public InputFileType FileType { private set; get; }
        
        /// <summary>
        /// Create a new File Transformer for ingesting files of the specified type.
        /// </summary>
        public FileTransform(InputFileType fileType)
        {
            FileType = fileType;
            
        }

        /// <summary>
        /// Transform a set of records according to the filetype set upon instantiation.
        /// </summary>
        /// <param name="records"></param>
        /// <returns></returns>
        public List<AccountRecord> TransformRecords(string[] records)
        {
            TargetRecords = new List<AccountRecord>();

            for (int i = 0; i < 10; i++)
            {
                AccountRecord targetRecord = new AccountRecord();

                if (FileType == InputFileType.Type1)
                {
                    // Record 0 -- Identifier
                    string identifier = records[i][0].ToString();  // eg. 123|AbcCode
                    string accountCode = identifier.Split('|')[1];  // eg. AbcCode
                    targetRecord.Code = accountCode;

                    // Record 1 -- Account Name
                    string name = records[i][1].ToString();  // eg. My Account
                    targetRecord.Name = name;

                    // Record 2 -- Account Type
                    int accountInput = 0; 
                    Int32.TryParse(records[i][2].ToString(), out accountInput);  // eg. 1, 2, 3, 4
                    if (accountInput >= 1 && accountInput <= 4)
                    {
                        targetRecord.Type = (AccountType)accountInput;
                    }

                    // Record 3 -- Opened Date
                    DateTime openDate = DateTime.MinValue;  // DateTime is not nullable
                    if (DateTime.TryParse(records[i][3].ToString(), out openDate))
                    {
                        targetRecord.OpenDate = openDate;
                    }

                    // Record 4 -- Currency Type
                    CurrencyType currencyType = CurrencyType.Unknown;
                    string currencyInput = records[i][4].ToString();
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

                }
                else
                {
                
                }

                TargetRecords.Add(targetRecord);
            }

            return TargetRecords;
        }

    }
}