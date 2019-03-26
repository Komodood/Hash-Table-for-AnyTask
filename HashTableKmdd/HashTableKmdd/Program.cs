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
            public object Key { get; set; }
            public object Value { get; set; }
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
                list.Add(new List<BothKeyValue>());//создание таблицы нужного размера
            }
        }
        ///
        /// Метод складывающий пару ключь-значение в таблицу
        ///
        /// key">
        /// value">
        public void PutBoth(object key, object value)
        {
            var HashInFirstList = Math.Abs(key.GetHashCode());
            foreach (var hash in list[HashInFirstList])
            {
                if (Equals(hash.Key, key))
                {
                    hash.Value = value;
                    return;
                }
                list[HashInFirstList].Add(new BothKeyValue { Key = key, Value = value });
            }
        }
        /// <summary>
        /// Поиск значения по ключу
        /// summary>
        /// key">Ключ
        /// <returns>Значение, null если ключ отсутствует
        /// returns>
        public object GetValueByKey(object key)
        {
            var HashInFirstList = Math.Abs(key.GetHashCode());
            foreach (var hash in list[HashInFirstList])
            {
                if (Equals(hash.Key, key))
                {
                    return hash.Value;
                }
            }
            return null;
        }
    }
}
