using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ObjectComparer.Tests
{
    [TestClass]
    public class ComparerFixture
    {
        [TestMethod]
        public void Null_values_are_similar_test()
        {
            string first = null, second = null;
            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }
        [TestMethod]
        public void string_values_are_similar_test()
        {
            string first = "ABCD", second = "ABCD";
            Assert.IsTrue(Comparer.AreSimilar(first, second));

            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }
        [TestMethod]
        public void stringnull_stringvalues_are_similar_test()
        {
            string first = null, second = "ABCD";
            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }
        [TestMethod]
        public void int_values_are_similar_test()
        {
            int first = 1,  second = 2;
            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }
        [TestMethod]
        public void float_values_are_similar_test()
        {
            float first = 1.2F, second = 2.1F;
            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }
        [TestMethod]
        public void IntArray_values_are_similar_test()
        {
            int[] first = new int[] { 1, 2, 3 };
            int[] second = new int[] { 1, 2, 3 };
            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }
        [TestMethod]
        public void IntArrayElementPosition_values_are_similar_test()
        {
            int[] first = new int[] { 1, 2, 3 };
            int[] second = new int[] { 3,2,1 };
            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void IntArrayLengthMismatch_values_are_similar_test()
        {
            int[] first = new int[] { 1, 2, 3 };
            int[] second = new int[] { 3, 2, 1 ,4};
            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }
        [TestMethod]
        public void StingArray_values_are_similar_test()
        {
            string[] first = new string[] { "abcd","pqr" };
            string[] second = new string[] { "abcd", "pqr" };
            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }
        [TestMethod]
        public void StingArraynotequal_values_are_similar_test()
        {
            string[] first = new string[] { "abcd", "pqr" };
            string[] second = new string[] { "dfs", "pdsfdfqr" };
            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void Object_values_are_similar_test()
        {
            var first = new
            {
                firstProperty = "First",
                secondProperty = 1,
                thirdProperty = true
            };
            var second = new
            {
                firstProperty = "First",
                secondProperty = 1,
                thirdProperty = true
            };

            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }
        public void NotMatchingObject_values_are_similar_test()
        {
            var first = new
            {
                firstProperty = "First",
                secondProperty = 1,
                thirdProperty = true
            };
            var second = new
            {
                firstProperty = "Second",
                secondProperty = 2,
                thirdProperty = false
            };

            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void ObjectwithArray_values_are_similar_test()
        {
            var first = new
            {
                Id = 1,
                Name = "Santosh",
                Marks = new[] { 1, 2, 3 }
            };
            var second = new
            {
                Id = 1,
                Name = "Santosh",
                Marks = new[] { 1, 2, 3 }
            };

            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }

    }
}
