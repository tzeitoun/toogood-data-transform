using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Toogood_Data_Transform
{
    enum AccountType
    {
        Unknown = 0,
        Trading = 1,
        RRSP = 2,
        RESP = 3,
        Fund = 4
    }

    enum CurrencyType
    {
        Unknown = 0,
        CAD = 1,
        USD = 2
    }

    class AccountRecord  // aka. TargetRecord
    {
        // Properties with auto-implemented accessors.
        // (Accessors can be implemented manually here to contain custom logic if required.)
        // Alternative to writing out a get..() and set..() method for each field.
        public string AccountCode { get; set; }
        public string Name { get; set; }
        public AccountType Type { get; set; }
        public DateTime OpenDate { get; set; }
        public CurrencyType Currency { get; set; }

        /// <summary>
        /// Creates a new record with default parameters.
        /// </summary>
        public AccountRecord()
        {
            AccountCode = "";
            Name = "";
            Type = AccountType.Unknown;
            OpenDate = DateTime.MinValue;
            Currency = CurrencyType.Unknown;
        }

        /// <summary>
        /// Creates a new record with the specified parameters.
        /// </summary>
        /// <param name="accountCode"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="openDate"></param>
        /// <param name="currency"></param>
        public AccountRecord(
            string accountCode,
            string name,
            AccountType type,
            DateTime openDate,
            CurrencyType currency
            )
        {
            this.AccountCode = accountCode;
            this.Name = name;
            this.Type = type;
            this.OpenDate = openDate;
            this.Currency = currency;
        }

        /// <summary>
        /// Transforms the record into the standard format and returns it as a string.
        /// </summary>
        /// <returns>The record in the standard format as a string.</returns>
        public string getRecord()
        {
            string separator = ",";  // could be \t for tab delimited, etc.
            string record = AccountCode
                + separator + Name
                + separator + Type
                + separator + ((OpenDate > DateTime.MinValue) ? OpenDate.ToShortDateString() : "")
                + separator + Currency 
                ;
            return record;
        }
    }

}
