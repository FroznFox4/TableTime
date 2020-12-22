using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTime.Week
{
    /// <summary>
    /// There should be no more than 6 elements in a dict
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        protected IDictionary<TKey, TValue> Dictionary;
        public MyDictionary()
        {
            Dictionary = new Dictionary<TKey, TValue>();
        }
        public MyDictionary(int capacity)
        {
            Dictionary = new Dictionary<TKey, TValue>(capacity);
        }
        public MyDictionary(IEqualityComparer<TKey> comparer)
        {
            Dictionary = new Dictionary<TKey, TValue>(comparer);
        }
        public MyDictionary(int capacity, IEqualityComparer<TKey> comparer)
        {
            Dictionary = new Dictionary<TKey, TValue>(capacity, comparer);
        }
        public MyDictionary(IDictionary<TKey, TValue> dictionary)
        {
            Dictionary = new Dictionary<TKey, TValue>(dictionary);
        }
        public MyDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
        {
            Dictionary = new Dictionary<TKey, TValue>(dictionary, comparer);
        }
        public virtual void Add(TKey key, TValue value)
        {
            if(Dictionary.Count < 7)
            {
                Dictionary.Add(key, value);
            }
            else 
            {
                throw new OverflowException("There should be no more than 6 elements in a dict");
            }
        }
        public virtual bool ContainsKey(TKey key)
        {
            return Dictionary.ContainsKey(key);
        }
        public virtual ICollection<TKey> Keys
        {
            get
            {
                return Dictionary.Keys;
            }
        }
        public virtual bool Remove(TKey key)
        {
            return Dictionary.Remove(key);
        }
        public virtual bool TryGetValue(TKey key, out TValue value)
        {
            return Dictionary.TryGetValue(key, out value);
        }
        public virtual ICollection<TValue> Values
        {
            get
            {
                return Dictionary.Values;
            }
        }
        public virtual TValue this[TKey key]
        {
            get
            {
                return Dictionary[key];
            }
            set
            {
                Dictionary[key] = value;
            }
        }
        public virtual void Add(KeyValuePair<TKey, TValue> item)
        {
            Dictionary.Add(item);
        }
        public virtual void Clear()
        {
            Dictionary.Clear();
        }
        public virtual bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return Dictionary.Contains(item);
        }
        public virtual void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            Dictionary.CopyTo(array, arrayIndex);
        }
        public virtual int Count
        {
            get
            {
                return Dictionary.Count;
            }
        }
        public virtual bool IsReadOnly
        {
            get { return Dictionary.IsReadOnly; }
        }
        public virtual bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Dictionary.Remove(item);
        }
        public virtual IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return Dictionary.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
