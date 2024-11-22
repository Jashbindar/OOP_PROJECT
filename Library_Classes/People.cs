using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Cloud.Firestore;

namespace Homework2Library
{
    [FirestoreData]
    public class People
    {
        [FirestoreProperty]
        public string ?name { get; set; }


        public People() { }
        public People (string a_name)
        {
            name = a_name;
        }

        public string getName()
        {
            return name;
        }
    }
}
