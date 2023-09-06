using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.DataStructures
{
    internal class CustomHashTable
    {
        public CustomHashTable(int length)
        {
            Entries = new LinkedList<Entry>[length];
        }
        public LinkedList<Entry>[] Entries { get; set; }

        public void Add(int key, string value) // replace
        {
            var hashIndex = Hash(key);


            if (Entries[hashIndex] == null)
                Entries[hashIndex] = new LinkedList<Entry>();

            if (!string.IsNullOrEmpty(Get(key)))
            {
                var entry = (from pair in Entries[hashIndex] where pair.Key == key select pair).First();
                entry.Value = value;
            }
            else
            {
                var entry = new Entry(key, value);
                Entries[hashIndex].AddFirst(entry);
            }
        }

        public string Get(int key)
        {
            var hashIndex = Hash(key);
            if (Entries[hashIndex] == null) return null;
            if (Entries[hashIndex].Count == 0) return null;
            
            return (from entry in Entries[hashIndex] where entry.Key == key select entry.Value).First();
        }

        private int Hash(int key)
        {
            return Math.Abs(key % Entries.Length);
        }
    }

    class Entry
    {
        public Entry(int key, string value)
        {
            Key = key;
            Value = value;
        }
        public int Key { get; set; }
        public string Value { get; set; }
    }
}
