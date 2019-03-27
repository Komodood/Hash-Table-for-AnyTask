using NUnit.Framework;
using NUnit.Compatibility;
using System;
using HashTableKmdd;
namespace HashTableKmdd
{

    [TestFixture]
    public class SortingTest
    {
        [Test]
        public void TestMassive3El()
        {
            string firstName = "Привет", secondName = "Сосед", thirdName = "Анвар";
            var hashTable = new HashTable(3);
            hashTable.PutPair(0, firstName);
            hashTable.PutPair(1, secondName);
            hashTable.PutPair(2, thirdName);
            Assert.AreEqual(firstName, hashTable.GetValueByKey(0));
            Assert.AreEqual(secondName, hashTable.GetValueByKey(1));
            Assert.AreEqual(thirdName, hashTable.GetValueByKey(2));
        }


        [Test]
        public void AnotherValueInOneKey()
        {
            string firstName = "Я", secondName = "Гриша";
            var hashTable = new HashTable(2);
            hashTable.PutPair(0, firstName);
            hashTable.PutPair(0, secondName);
            Assert.AreEqual(secondName, hashTable.GetValueByKey(0));
        }


        [Test]
        public void TestMassive10000El()
        {
            var h = new HashTable(10000);
            for (int i = 1; i < 10000; i++)
            {
                h.PutPair(i, i + 1);
            }
            Assert.AreEqual(h.GetValueByKey(15), 16);
            //var j = -1;
            //var hashTable = new HashTable(10000);
            //var rand = new Random();
            //var massiveOfValue = new char[10000];
            //for (int i = 0; i < 10000; i++)
            //    massiveOfValue[i] = (char)rand.Next(0x00A1, 0x27B2);
            //foreach (var e in massiveOfValue)
            //{
            //    hashTable.PutPair(j++, e);
            //}
            //hashTable.GetValueByKey(5000);
        }

        [Test]
        public void TestMassive10000ElAnd1000()
        {
            var j = 1002;
            var hashTable = new HashTable(10000);
            var rand = new Random();
            var massiveOfValue = new char[10000];
            for (int i = 0; i < 10000; i++)
                massiveOfValue[i] = (char)rand.Next(0x00A1, 0x27B2);
            foreach (var e in massiveOfValue)
            {
                hashTable.PutPair(j++, e);
            }
            for (int k = 0; k < 1000; k++)
                hashTable.GetValueByKey(k);
        }
    }
}

