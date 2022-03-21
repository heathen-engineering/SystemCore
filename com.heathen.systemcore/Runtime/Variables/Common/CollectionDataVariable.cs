#if HE_SYSCORE
using HeathenEngineering.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering
{

    [Serializable]
    public abstract class CollectionDataVariable<T> : DataVariable<List<T>>, ICollectionDataVariable<T>
    {
        [HideInInspector]
        public List<ICollectionChangeEventListener<T>> typeCollectionChangeListeners = new List<ICollectionChangeEventListener<T>>();
        [HideInInspector]
        public List<UnityAction<CollectionChangeEventData<T>>> typeCollectionChangeSenderActions = new List<UnityAction<CollectionChangeEventData<T>>>();

        public T this[int index] { get => m_value[index]; set => m_value[index] = value; }

        public int Capacity { get => m_value.Capacity; set => m_value.Capacity = value; }

        public int Count => m_value.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            m_value.Add(item);
            Raise(this);
        }

        public void AddListener(ICollectionChangeEventListener<T> listener)
        {
            typeCollectionChangeListeners.Add(listener);
        }

        public void AddListener(UnityAction<CollectionChangeEventData<T>> listener)
        {
            typeCollectionChangeSenderActions.Add(listener);
        }

        public void AddRange(IEnumerable<T> collection)
        {
            m_value.AddRange(collection);
            Raise(this);
        }

        public int BinarySearch(T item) => m_value.BinarySearch(item);

        public int BinarySearch(T item, IComparer<T> comparer) => m_value.BinarySearch(item, comparer);

        public int BinarySearch(int index, int count, T item, IComparer<T> comparer) => m_value.BinarySearch(index, count, item, comparer);

        public void Clear()
        {
            m_value.Clear();
            Raise(this);
        }

        public bool Contains(T item) => m_value.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => m_value.CopyTo(array, arrayIndex);

        public bool Exists(Predicate<T> match) => m_value.Exists(match);

        public T Find(Predicate<T> match) => m_value.Find(match);

        public List<T> FindAll(Predicate<T> match) => m_value.FindAll(match);

        public int FindIndex(Predicate<T> match) => m_value.FindIndex(match);

        public int FindIndex(int startIndex, Predicate<T> match) => m_value.FindIndex(startIndex, match);

        public int FindIndex(int startIndex, int count, Predicate<T> match) => m_value.FindIndex(startIndex, count, match);

        public T FindLast(Predicate<T> match) => m_value.FindLast(match);

        public int FindLastIndex(Predicate<T> match) => m_value.FindLastIndex(match);

        public int FindLastIndex(int startIndex, Predicate<T> match) => m_value.FindLastIndex(startIndex, match);

        public int FindLastIndex(int startIndex, int count, Predicate<T> match) => m_value.FindLastIndex(startIndex, count, match);

        /// <summary>
        /// This will trigger the Collection Change Event
        /// </summary>
        /// <param name="action"></param>
        public void ForEach(Action<T> action)
        {
            m_value.ForEach(action);
            Raise(this);
        }

        public IEnumerator<T> GetEnumerator() => m_value.GetEnumerator();

        public List<T> GetRange(int index, int count) => m_value.GetRange(index, count);

        public int IndexOf(T item) => m_value.IndexOf(item);

        public void Insert(int index, T item)
        {
            m_value.Insert(index, item);
            Raise(this);
        }

        public void InsertRange(int index, IEnumerable<T> collection)
        {
            m_value.InsertRange(index, collection);
            Raise(this);
        }

        public int LastIndexOf(T item) => m_value.LastIndexOf(item);
                
        public override void Raise(object sender, List<T> oldValue, List<T> newValue)
        {
            base.Raise(sender, oldValue, newValue);

            CollectionChangeEventData<T> data = new CollectionChangeEventData<T>(sender, m_value);

            for (int i = typeCollectionChangeListeners.Count - 1; i >= 0; i--)
            {
                if (typeCollectionChangeListeners[i] != null)
                    typeCollectionChangeListeners[i].OnEventRaised(data);
            }
            for (int i = typeChangeSenderActions.Count - 1; i >= 0; i--)
            {
                if (typeCollectionChangeSenderActions[i] != null)
                    typeCollectionChangeSenderActions[i].Invoke(data);
            }
        }
        
        public bool Remove(T item)
        {
            if (m_value.Remove(item))
            {
                Raise(this);
                return true;
            }
            else
                return false;
        }

        public int RemoveAll(Predicate<T> match)
        {
            var result = m_value.RemoveAll(match);
            if (result > 0)
                Raise(this);

            return result;
        }

        public void RemoveAt(int index)
        {
            m_value.RemoveAt(index);
            Raise(this);
        }

        public void RemoveListener(ICollectionChangeEventListener<T> listener)
        {
            typeCollectionChangeListeners.Remove(listener);
        }

        public void RemoveListener(UnityAction<CollectionChangeEventData<T>> listener)
        {
            typeCollectionChangeSenderActions.Remove(listener);
        }

        public void RemoveRange(int index, int count)
        {
            m_value.RemoveRange(index, count);
            Raise(this);
        }

        public void Reverse()
        {
            m_value.Reverse();

            if (m_value.Count > 0)
                Raise(this);
        }

        public void Reverse(int index, int count)
        {
            m_value.Reverse(index, count);

            if (m_value.Count > 0)
                Raise(this);
        }

        public void Sort(Comparison<T> comparison)
        {
            m_value.Sort(comparison);

            if (m_value.Count > 0)
                Raise(this);
        }

        public void Sort(int index, int count, IComparer<T> comparer)
        {
            m_value.Sort(index, count, comparer);

            if (m_value.Count > 0)
                Raise(this);
        }

        public void Sort()
        {
            m_value.Sort();

            if (m_value.Count > 0)
                Raise(this);
        }

        public void Sort(IComparer<T> comparer)
        {
            m_value.Sort(comparer);

            if (m_value.Count > 0)
                Raise(this);
        }

        public T[] ToArray() => m_value.ToArray();

        public void TrimExcess() => m_value.TrimExcess();

        public bool TrueForAll(Predicate<T> match) => m_value.TrueForAll(match);

        IEnumerator IEnumerable.GetEnumerator() => m_value.GetEnumerator();
    }
}
#endif