using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Cloud.Firestore;

namespace Homework2Library
{
    [FirestoreData]
    public class Item
    {
        [FirestoreProperty("Item Name")]
        public string itemname { get; set; }
        [FirestoreProperty("Quantity")]
        public int itemcount { get; set; }
        [FirestoreProperty("Price")]
        public double price { get; set; }
        [FirestoreProperty("Item ID")]
        public string itemID { get; set; }

        public Item() { }

        public Item(string a_itemname, int a_itemcount, double a_price)
        {
            itemname = a_itemname;
            itemcount = a_itemcount;
            price = a_price;
            itemID = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Replace("=", "").Replace("+", "-").Replace("/", "_");
        }

        public Item(string a_itemname, int a_itemcount, double a_price, string a_itemID)
        {
            itemname = a_itemname;
            itemcount = a_itemcount;
            price = a_price;
            itemID = a_itemID;
        }

        public string getItemName()
        {
            return itemname;
        }
        public int getItemCount()
        {
            return itemcount;
        }
        public double getPrice ()
        {
            return price;
        }
        public string getItemID()
        {
            return itemID;
        }
    }
}
