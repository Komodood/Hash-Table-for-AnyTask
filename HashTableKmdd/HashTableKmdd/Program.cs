using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableKmdd
{
    public class KeyValue
    {
        public object Key { get; private set; }
        public object Value { get; private set; }
        public KeyValue(object key, object value)
        {
            Key = key;
            Value = value;
            if (Key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (Value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }
        }
    }
    class HashTable
    {
        readonly int Size;
        readonly KeyValue[] Massive;
        /// <summary>
        /// Конструктор контейнера
        /// summary>
        /// size">Размер хэ-таблицы
        public HashTable(int size)
        {
            Massive = new KeyValue[size];
            Size = size;
        }
        ///
        /// Метод складывающий пару ключь-значение в таблицу
        ///
        /// key">
        /// value">
        public void PutPair(object key, object value)
        {
            var hash = Math.Abs(key.GetHashCode());
            var pos = hash % Size;  //Это что то вроде проверки ячейки на коллизию. Или как оно там. Нахождение места в таблице
            for (; Massive[pos] != null; pos = (pos + 1) % Size)
                if (Massive[pos].Key.Equals(key))
                    break;
            Massive[pos] = new KeyValue(key, value);
            //var NewBucket = new KeyValue(key, value); СТРОЧКИ КОТОРЫЕ БЫЛИ В ПРОШЛОМ
            //var OldBuckect = Massive[pos]; ВДРУГ ПОНАДОБЯТСЯ
            //Жаль foreach не помог
        }
        /// <summary>
        /// Поиск значения по ключу
        /// summary>
        /// key">Ключь
        /// <returns>Значение, null если ключ отсутствуетreturns>
        public object GetValueByKey(object key)
        {
            foreach (var e in Massive)
            {
                if (e.Key.Equals(key))
                    return e.Value;
            }
            return null;
        }
    }
}
