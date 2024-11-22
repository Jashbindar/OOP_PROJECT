using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Cloud.Firestore;

namespace Homework2Library
{
    [FirestoreData]
    public class Income : UserTransaction
    {
        [FirestoreProperty]
        public double total_income { get; set; }

        public Income() { }

        public Income(double a_amount, string a_transactionreason, DateTime a_datetime)
    : base(a_amount, a_transactionreason, a_datetime)
        {

        }

    }
}
