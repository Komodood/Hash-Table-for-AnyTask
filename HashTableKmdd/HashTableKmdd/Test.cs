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
            var OverTable = new HashTable(10000);
            for (int i = 0; i < 10000; i++)
            {
                OverTable.PutPair(i, i + 100);
            }
            Assert.AreEqual(OverTable.GetValueByKey(15), 115);
        }

        [Test]
        public void TestMassive10000ElAnd1000()
        {
            var OverTable = new HashTable(10000);
            for (int i = 0; i < 10000; i++)
            {
                OverTable.PutPair(i, i + 100);
            }
            for (int i = 10000; i < 11000; i++)
            {
                Assert.AreEqual(OverTable.GetValueByKey(i), null);
            }
        }
    }
}

