using System;
using System.Collections;
using System.Collections.Generic;

namespace Sequence
{
    internal class Sequence<T> : IEnumerable<T>
    {
        private List<T> list = new List<T>();

        public void Insert(int index, T item)
        {
            list.Insert(index, item);
        }

        internal Sequence<T> GetSubsequence(int startIndex, int endIndex)
        {
            if (startIndex < 0 || endIndex >= list.Count || startIndex > endIndex)
            {
                throw new ArgumentOutOfRangeException("Invalid start or end inex for subsequence");
            }

            Sequence<T> sequence = new Sequence<T>();
            for (int i = startIndex; i <= endIndex; i++)
            {
                sequence.Add(list[i]);
            }

            return sequence;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= list.Count)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
                return list[index];
            }
            set
            {
                if (index < 0 || index >= list.Count)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
                list[index] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            list.Add(item);
        }

        public int Count { get { return list.Count; } }
    }
}
