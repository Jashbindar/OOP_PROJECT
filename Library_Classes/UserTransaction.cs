using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Cloud.Firestore;
namespace Homework2Library
{
    [FirestoreData]
    public class UserTransaction
    {
        [FirestoreProperty]
        public string ?TransactionReason { get; set; }
        [FirestoreProperty]
        public double amount { get; set; }
        [FirestoreProperty]
        public DateTime TransactionDate { get; set; }
        [FirestoreProperty]
        public string ?transaction_id { get; set; }

        public UserTransaction() { }
        public UserTransaction (double a_amount, string a_transactionreason, DateTime a_datetime)
        {
            amount = a_amount;
            TransactionReason = a_transactionreason;
            TransactionDate = a_datetime;
            transaction_id = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Replace("=", "").Replace("+", "-").Replace("/", "_");
        }

        public UserTransaction(double a_amount, string a_transactionreason, DateTime a_datetime, string a_transaction_id)
        {
            amount = a_amount;
            TransactionReason = a_transactionreason;
            TransactionDate = a_datetime;
            transaction_id = a_transaction_id;
        }

        public double getAmount()
        {
            return amount;
        }

        public string getTransactionReason ()
        {
            return TransactionReason;
        }

        public DateTime getTransactionDateTime ()
        {
            return TransactionDate;
        }

        public string getTransactionID()
        {
            return transaction_id;
        }

        public void DisplayTransactionDetails()
        {
            Console.WriteLine("Amount: {0} Date Time: {1} Reason: {2} ID: {3}", amount, TransactionDate, TransactionReason, transaction_id);
        }
    }
}
