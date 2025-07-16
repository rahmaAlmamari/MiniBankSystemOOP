using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankSystemOOP
{
    class Transactions
    {
        //1. Transction class fields ...
        public int TransactionID = 0;
        public string TransactionType;
        public double TransactionAmount;
        public double TransactionBalance;//balance after transaction
        public DateTime TransactionDate;

        //2. Transaction class properties ...
        //3. Transaction class constructor ...
        public Transactions()
        {
            TransactionID++;
        }
    }
}
