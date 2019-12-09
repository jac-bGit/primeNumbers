using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeNumbers;

namespace UnitTestPrimeNumbers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_EratosthenovoSito()
        {
            // Arrange
            ErastotenovoSito es = new ErastotenovoSito();

            // Act
            int[] prvocisla = new int[]{ 3, 11, 23, 31, 103 }; // Testovana cisla
            int[] cisla = new int[] { 4, 9, 15 };
            int[] vsechnyCisla = new int[prvocisla.Length + cisla.Length];
            prvocisla.CopyTo(vsechnyCisla, 0);
            cisla.CopyTo(vsechnyCisla, prvocisla.Length);

            int pocetPrvocisel = 0;
            for(int i = 0; i < vsechnyCisla.Length; i++)
            {
                if (es.JeToPrvoCislo(vsechnyCisla[i]))
                    pocetPrvocisel++;
            }

            // Assert
            Assert.AreEqual(prvocisla.Length, pocetPrvocisel); // Vypsat uspech pokud vsechna cisla jsou prvocisla
        }
    }
}
