using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Cloud.Firestore;

namespace Homework2Library
{
    [FirestoreData]
    public class Expense : UserTransaction
    {
        [FirestoreProperty]
        public double total_expense { get; set; }

        public Expense() { }

        public Expense (double a_amount, string a_transactionreason, DateTime a_datetime) 
            : base (a_amount, a_transactionreason, a_datetime)
        {

        }
    }
}
