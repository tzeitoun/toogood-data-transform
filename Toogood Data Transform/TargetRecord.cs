using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Toogood_Data_Transform
{
    enum AccountType
    {
        Trading = 1,
        RRSP = 2,
        RESP = 3,
        Fund = 4
    }

    enum CurrencyType
    {
        CAD = 0,
        USD = 1
    }

    class TargetRecord
    {
        string AccountCode;
        string Name;
        AccountType Type;
        DateTime OpenDate;
        CurrencyType Currency;

        /// <summary>
        /// Creates a new record with the specified parameters.
        /// </summary>
        /// <param name="accountCode"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="openDate"></param>
        /// <param name="currency"></param>
        public TargetRecord(
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
            string record = AccountCode
                + "\t" + Name
                + "\t" + Type
                + "\t" + OpenDate
                + "\t" + Currency
                ;
            return record;
        }
    }

}
