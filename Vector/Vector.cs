using System;

namespace Vector
{
    /*
    Описать класс - обёртку над одномерным массивом, 
    содержащий методы для выполнения арифметических операций 
    над одномерными массивами целых чисел
    (поэлементное сложение массивов одинаковой длины, 
    скалярное произведение массивов одинаковой длины, 
    конкатенация массивов). 
    Уделить внимание граничным условиям 
    (пустые массивы, массивы разной длины и т.д.)
    */
    public class Vector
    {
        //Запретим изменять ссылку на массив
        private int[] _array;

        public Vector()
        {
            _array = new int[0];
        }

        public Vector(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            _array = new int[array.Length];
            Array.Copy(array, _array, _array.Length);
        }

        public Vector(Vector other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            _array = new int[other._array.Length];
            Array.Copy(other._array, _array, other._array.Length);
        }

        public int Count => _array.Length;

        public int this[int idx]
        {
            get { return _array[idx]; }
            set { _array[idx] = value; }
        }

        public Vector Copy()
        {
            return new Vector(_array);
        }

        public static Vector operator + (Vector left, Vector right)
        {
            if (left == null)
                throw new ArgumentNullException(nameof(left));
            if (right == null)
                throw new ArgumentNullException(nameof(right));
            if (left.Count != right.Count)
                throw new ArgumentException("Vector lengths are not equal");
            var result = new Vector(left);
            for (var i = 0; i < left.Count; ++i)
                result[i] = right[i];
            return result;
        }

        public static int operator * (Vector left, Vector right)
        {
            if (left == null)
                throw new ArgumentNullException(nameof(left));
            if (right == null)
                throw new ArgumentNullException(nameof(right));
            if (left.Count != right.Count)
                throw new ArgumentException("Vector lengths are not equal");
            var ip = 0;
            for (var i = 0; i < left.Count; ++i)
                ip += left[i]*right[i];
            return ip;
        }

        public void Append(Vector other)
        {
            var tmp = new int[_array.Length + other._array.Length];
            //Array.Copy(other._array, tmp, other._array.Length);
            _array.CopyTo(tmp, 0);
            //Array.Copy(other._array, 0, tmp, _array.Length, other._array.Length);
            other._array.CopyTo(tmp, _array.Length);
            _array = tmp;
        }
    }
}
