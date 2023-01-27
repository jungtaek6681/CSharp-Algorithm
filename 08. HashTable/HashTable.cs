using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
	internal class HashTable<TKey, TValue> where TKey : IEquatable<TKey>
	{
		private const int DefaultCapacity = 1000;

		private struct Entry
		{
			public enum State { None, Using, Deleted }

			public int hashCode;
			public State state;
			public TKey key;
			public TValue value;
		}

		private Func<TKey, int> hashFunc;
		private Entry[] table;

		public HashTable()
		{
			table = new Entry[DefaultCapacity];
			hashFunc = HashFunc;
		}

		public HashTable(Func<TKey, int> hashFunc)
		{
			this.table = new Entry[DefaultCapacity];
			this.hashFunc = hashFunc;
		}

		public TValue this[TKey key]
		{
			get
			{
				TValue value;
				if (TryGetValue(key, out value))
					return value;
				else
					throw new KeyNotFoundException();
			}
			set
			{
				TryInsert(key, value, InsertionBehavior.OverrideExist);
			}
		}

		public void Add(TKey key, TValue value)
		{
			TryInsert(key, value, InsertionBehavior.ThrowOnExisting);
		}

		public bool TryAdd(TKey key, TValue value)
		{
			return TryInsert(key, value, InsertionBehavior.None);
		}

		public void Clear()
		{
			table = new Entry[DefaultCapacity];
		}

		public bool ContainsKey(TKey key)
		{
			return TryGetValue(key, out var value);
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			int index = FindIndex(key);

			if (index < 0)
			{
				value = default(TValue);
				return false;
			}
			else
			{
				value = table[index].value;
				return true;
			}
		}

		public bool Remove(TKey key)
		{
			int index = FindIndex(key);

			if (index < 0)
			{
				return false;
			}
			else
			{
				table[index].state = Entry.State.Deleted;
				return true;
			}
		}

		private int HashFunc(TKey key)
		{
			if (key == null)
				throw new ArgumentNullException("key");

			return key.GetHashCode();
		}

		private int DoubleHash(int index)
		{
			return ++index % table.Length;
		}

		private enum InsertionBehavior { None, OverrideExist, ThrowOnExisting }
		private bool TryInsert(TKey key, TValue value, InsertionBehavior behavior)
		{
			int hashCode = hashFunc(key);
			int index = Math.Abs(hashCode) % table.Length;
			while (table[index].state == Entry.State.Using)
			{
				if (key.Equals(table[index].key))
				{
					switch (behavior)
					{
						case InsertionBehavior.OverrideExist:
							table[index].hashCode = hashCode;
							table[index].key = key;
							table[index].value = value;
							return true;
						case InsertionBehavior.ThrowOnExisting:
							throw new ArgumentException();
						case InsertionBehavior.None:
						default:
							return false;
					}
				}
				index = DoubleHash(index);
			}

			table[index].hashCode = hashCode;
			table[index].state = Entry.State.Using;
			table[index].key = key;
			table[index].value = value;
			return true;
		}

		private int FindIndex(TKey key)
		{
			int hashCode = hashFunc(key);
			int index = Math.Abs(hashCode) % table.Length;
			while (table[index].state == Entry.State.Using)
			{
				if (key.Equals(table[index].key))
				{
					return index;
				}
				index = DoubleHash(index);
			}

			return -1;
		}
	}
}
