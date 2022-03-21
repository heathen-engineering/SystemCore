#if HE_SYSCORE
using HeathenEngineering.Events;
using System;
using System.Collections.Generic;

namespace HeathenEngineering
{
    public interface ICollectionDataVariable<T> : IDataVariable<List<T>>, ICollectionChangeEvent<T>, ICollection<T>
    {
        T this[int index] { get; set; }

        int Capacity { get; set; }

        int IndexOf(T item);

        int LastIndexOf(T item);

        void AddRange(IEnumerable<T> collection);

        int BinarySearch(T item);

        int BinarySearch(T item, IComparer<T> comparer);

        int BinarySearch(int index, int count, T item, IComparer<T> comparer);

        bool Exists(Predicate<T> match);

        T Find(Predicate<T> match);

        List<T> FindAll(Predicate<T> match);

        int FindIndex(Predicate<T> match);

        int FindIndex(int startIndex, Predicate<T> match);

        int FindIndex(int startIndex, int count, Predicate<T> match);

        T FindLast(Predicate<T> match);

        int FindLastIndex(Predicate<T> match);

        int FindLastIndex(int startIndex, Predicate<T> match);

        int FindLastIndex(int startIndex, int count, Predicate<T> match);

        void ForEach(Action<T> action);

        List<T> GetRange(int index, int count);

        void Insert(int index, T item);

        void InsertRange(int index, IEnumerable<T> collection);

        int RemoveAll(Predicate<T> match);

        void RemoveAt(int index);

        void RemoveRange(int index, int count);

        void Reverse();

        void Reverse(int index, int count);

        void Sort(Comparison<T> comparison);

        void Sort(int index, int count, IComparer<T> comparer);

        void Sort();

        void Sort(IComparer<T> comparer);

        T[] ToArray();

        void TrimExcess();

        bool TrueForAll(Predicate<T> match);
    }
}
#endif