using System;

namespace ProjectTruckApp.Storage
{
    public class MassiveGenericObjects<T> where T : class
    {
        private T[] _array;
        private int _count;
        private int _capacity;

        public MassiveGenericObjects(int capacity = 20)
        {
            _capacity = capacity;
            _array = new T[capacity];
            _count = 0;
        }

        public int Count => _count;
        public int Capacity => _capacity;

        public bool Insert(T obj, int index)
        {
            if (obj == null || index < 0 || index > _count) return false;

            if (_count >= _capacity)
            {
                _capacity *= 2;
                T[] newArray = new T[_capacity];
                Array.Copy(_array, newArray, _count);
                _array = newArray;
            }

            for (int i = _count; i > index; i--)
                _array[i] = _array[i - 1];

            _array[index] = obj;
            _count++;
            return true;
        }

        public bool Remove(int index)
        {
            if (index < 0 || index >= _count) return false;

            for (int i = index; i < _count - 1; i++)
                _array[i] = _array[i + 1];

            _array[_count - 1] = null;
            _count--;
            return true;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= _count) return null;
            return _array[index];
        }

        public void Clear()
        {
            _array = new T[_capacity];
            _count = 0;
        }
    }
}