using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableKmdd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class HashTable
    {
        class BothKeyValue
        {
            public object key { get; set; }
            public object value { get; set; }
        }
        List<List<BothKeyValue>> list;//Вроде тот самый типизированый список объектов

        /// <summary>
        /// Конструктор контейнера
        /// summary>
        /// size">Размер хэ-таблицы
        public HashTable(int size)
        {
            list = new List<List<BothKeyValue>>();
            for (int i = 0; i < size; i++)
            {
                list.Add(new List<BothKeyValue>());
            }
        }
        ///
        /// Метод складывающий пару ключь-значение в таблицу
        ///
        /// key">
        /// value">
        public void PutPair(object key, object value)
        {
            var bucketNo = GetBucketNumber(key);
            foreach (var p in list[bucketNo])
            {
                if (Equals(p.key, key))
                {
                    p.value = value;
                    return;
                }
            }


        }
        /// <summary>
        /// Поиск значения по ключу
        /// summary>
        /// key">Ключь
        /// <returns>Значение, null если ключ отсутствует
        /// returns>
        public object GetValueByKey(object key)
        {



        }
        private int GetBucketNumber(object key)
        {
            return Math.Abs(key.GetHashCode()) & list.Count;
        }
    }
}