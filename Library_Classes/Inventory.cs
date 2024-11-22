using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Cloud.Firestore;

namespace Homework2Library
{
    [FirestoreData]
    public class Inventory
    {
        public List<Item> items;

        public Inventory ()
        {
            items = new List<Item> ();
        }

        public void AddItem (Item a_item)
        {
            items.Add(a_item);
        }
        public void RemoveItem (Item a_item)
        {
            items.Remove(a_item);
        }

        public void DisplayInventory ()
        {
            foreach (Item tmp in items)
            {
                Console.WriteLine("Item name: {0} x {1} Cost: {2} ID: {3}", tmp.getItemName(), tmp.getItemCount(), tmp.getPrice(), tmp.getItemID());
            }
        }

        public Item findItemByID (Item a_item)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (a_item.getItemID() == items[i].getItemID())
                {
                    return items[i];
                }
            }
            Console.WriteLine("Item not found!");
            return null;
        }

        public void Clear()
        {
            items.Clear();
        }

    }
}
