using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

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
            var bucket = GetBucket(key);


            if (bucket == null)
            {
                bucket = new LinkedList<Entry>();
                Entries[Hash(key)] = bucket;

                var entry = new Entry(key, value);
                bucket.AddFirst(entry);
            }
            else
            {
                var entry = (from pair in bucket where pair.Key == key select pair).First();
                entry.Value = value;
            }
        }
        public Entry Get(int key)
        {
            var bucket = GetBucket(key);
            if (bucket == null) return null;
            if (bucket.Count == 0) return null;

            return (from entry in bucket where entry.Key == key select entry).First();
        }
        public string GetValue(int key) => Get(key)?.Value;

        public void Remove(int key) => GetBucket(key)?.Remove(Get(key));
        private int Hash(int key) => Math.Abs(key % Entries.Length);
        private LinkedList<Entry> GetBucket(int key) => Entries[Hash(key)];

        public void ImplementHashTable()
        {
            var hashTable = new CustomHashTable(10);
            hashTable.Add(1, "john");
            WriteLine(hashTable.GetValue(1));
            var x = hashTable.GetValue(5);
            WriteLine(x);
            hashTable.Add(1, "maz");
            WriteLine(hashTable.GetValue(1));
            hashTable.Add(4, "four");
            WriteLine(hashTable.GetValue(4));
            hashTable.Remove(4);
            WriteLine(hashTable.GetValue(4));
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
