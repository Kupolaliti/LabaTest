using System.Collections.Generic;
using NUnit.Framework;

namespace Laba1Test
{
    [TestFixture]
    public class Laba1Tests
    {
        [Test]
        public void IsEqualsTexts_IsNotEmpty_ReturnsTrue()
        {
            //Arrange
            Laba1.Child child = new Laba1.Child();

            //Act
            List<string[]> result = child.IsEqualsTexts("Какого", "Што");

            //Assert
            Assert.IsNotEmpty(result);
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual(Laba1.ForTests.getSum(2, 5), 7);
        }

        [Test]
        public void Test3()
        {
            Assert.AreEqual(Laba1.ForTests.getDif(7, 5), 2);
        }

        [Test]
        public void Test4()
        {
            Assert.AreEqual(Laba1.ForTests.getDiv(8, 2), 4);
        }

        [Test]
        public void Test5()
        {
            Assert.AreEqual(Laba1.ForTests.getMult(2, 5), 10);
        }

        [Test]
        public void Test6()
        {
            Assert.AreEqual(Laba1.ForTests.isEqual("Ура", "Ура"), true);
        }

        [Test]
        public void Test7()
        {
            string[] a = { "у","р","а" };
            Assert.AreEqual(Laba1.ForTests.concatination(a), "ура");
        }

        [Test]
        public void Test8()
        {
            Assert.AreEqual(Laba1.ForTests.getForce(4, 10), 40);
        }

        [Test]
        public void Test9()
        {
            Assert.AreEqual(Laba1.ForTests.getHypotenuse(3, 4), 5);
        }

        [Test]
        public void Test10()
        {
            Assert.AreEqual(Laba1.ForTests.getForce(2, 3), 6);
        }
    }
}
