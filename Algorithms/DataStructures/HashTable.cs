using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    public class HashTable<K,V>
    {
        private class Data
        {
            public K Key { get; set; }
            public V Value { get; set; }
        }

        private ListNode<Data>[] data = new ListNode<Data>[10];

        public bool Contains(K key)
        {
            return this.GetNode(this.GetIndex(key), key) != null;
        }

        public V this[K key]
        {
            get
            {
                ListNode<Data> node = this.GetNode(key);
                if (node == null)
                    return default(V);

                return node.Value.Value;
            }
            set
            {
                int index = this.GetIndex(key);
                ListNode<Data> data = this.GetNode(index, key);

                if (data != null)
                {
                    data.Value.Value = value;
                    return;
                }

                data = new ListNode<Data>() { Value = new Data { Key = key, Value = value } };

                data.Next = this.data[index];
                if (data.Next != null)
                {
                    data.Next.Previous = data;
                }

                this.data[index] = data;
            }
        }

        public bool Delete(K key)
        {
            int index = this.GetIndex(key);
            ListNode<Data> node = GetNode(index, key);

            if (node == null)
                return false;

            if (node.Previous == null)
                this.data[index] = node.Next;
            else
                node.Previous.Next = node.Next;

            if (node.Next != null)
                node.Next.Previous = node.Previous;

            return true;
        }

        private int GetIndex(K key)
        {
            return key.GetHashCode() % this.data.Length;
        }

        private ListNode<Data> GetNode(K key)
        {
            return this.GetNode(this.GetIndex(key), key);
        }

        private ListNode<Data> GetNode(int index, K key)
        {
            ListNode<Data> current = this.data[index];
            while (current != null && !current.Value.Key.Equals(key))
                current = current.Next;

            return current;
        }
    }
}
