using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Dictionary<TKey, TValue> where TKey : IEquatable<TKey>
    {
        private const int DefaultCapacity = 1000;

        private struct Entry
        {
            public enum State { None, Using, Deleted }

            public State state;
            public TKey key;
            public TValue value;
        }

        private Entry[] table;
        private int usedCount;
        private int deletedCount;

        public Dictionary()
        {
            table = new Entry[DefaultCapacity];
            usedCount = 0;
            deletedCount = 0;
        }

        public TValue this[TKey key]
        {
            get
            {
                if (TryFind(key, out int index) == false)
                    throw new KeyNotFoundException();

                return table[index].value;
            }
            set
            {
                if (TryFind(key, out int index))
                {
                    table[index].value = value;
                }
                else
                {
                    Add(key, value);
                }
            }
        }

        public int Capacity { get { return table.Length; } }
        public int Count { get { return usedCount; } }

        public void Add(TKey key, TValue value)
        {
            if (TryFind(key, out int index) == false)
                throw new InvalidOperationException();

            if (usedCount + deletedCount > table.Length * 0.7f)
            {
                ReHashing();
            }

            table[index].key = key;
            table[index].value = value;
            table[index].state = Entry.State.Using;
            usedCount++;
        }

        public void Clear()
        {
            table = new Entry[DefaultCapacity];
            usedCount = 0;
            deletedCount = 0;
        }

        public bool ContainsKey(TKey key)
        {
            if (TryFind(key, out int index))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Remove(TKey key)
        {
            if (TryFind(key, out int index))
            {
                table[index].state = Entry.State.Deleted;
                usedCount--;
                deletedCount++;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool TryFind(TKey key, out int index)
        {
            if (key == null)
                throw new ArgumentNullException();

            index = Hash(key);
            for (int i = 0; i < table.Length; i++)
            {
                if (table[index].state == Entry.State.None)
                {
                    return false;
                }
                else if (table[index].state == Entry.State.Using)
                {
                    if (key.Equals(table[index].key))
                    {
                        return true;
                    }
                    else
                    {
                        index = Hash2(index);
                    }
                }
                else // if (table[index].state == Entry.State.Deleted)
                {
                    if (key.Equals(table[index].key))
                    {
                        return false;
                    }
                    else
                    {
                        index = Hash2(index);
                    }
                }
            }

            index = -1;
            throw new InvalidOperationException();
        }

        private int Hash(TKey key)
        {
            // 나눗셈법
            return Math.Abs(key.GetHashCode() % table.Length);
        }

        private int Hash2(int index)
        {
            // 선형 탐사
            return (index + 1) % table.Length;

            // 제곱 탐사
            // return (index + 1) * (index + 1) % table.Length;

            // 이중 해싱
            // return Math.Abs((index + 1).GetHashCode() % table.Length);
        }

        private void ReHashing()
        {
            Entry[] oldTable = table;
            table = new Entry[table.Length * 2];
            usedCount = 0;
            deletedCount = 0;

            for (int i = 0; i <  oldTable.Length; i++)
            {
                Entry entry = oldTable[i];
                if (entry.state == Entry.State.Using)
                {
                    Add(entry.key, entry.value);
                }
            }
        }
    }
}
