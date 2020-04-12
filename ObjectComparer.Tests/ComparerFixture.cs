using System;
using System.Collections.Generic;
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
        public void Valuestring_Nullstring_values_are_not_similar_test()
        {
            string first = "ABCD", second = null;
            bool result = Comparer.AreSimilar(first, second);
            Assert.AreEqual(false,result);
        }
        [TestMethod]
        public void String_values_are_similar_test()
        {
            string first = "ABCD", second = "ABCD";
            Assert.IsTrue(Comparer.AreSimilar(first, second));

        }
        [TestMethod]
        public void Stringnull_stringvalues_are_not_similar_test()
        {
            string first = null, second = "ABCD";
            Assert.IsFalse(Comparer.AreSimilar(first, second));
        }
        [TestMethod]
        public void String_stringvalues_are_notsimilar_test()
        {
            string first = "GHGHJ", second = "ABCD";
            Assert.IsFalse(Comparer.AreSimilar(first, second));
        }
        [TestMethod]
        public void Int_values_are_similar_test()
        {
            int first = 1, second = 1;
            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }
        [TestMethod]
        public void Int_values_are_Notsimilar_test()
        {
            int first = 1,  second = 2;
            Assert.IsFalse(Comparer.AreSimilar(first, second));
        }
        [TestMethod]
        public void Float_values_are_similar_test()
        {
            float first = 1.2F, second = 1.2F;
            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }
        [TestMethod]
        public void Float_values_are_notsimilar_test()
        {
            float first = 1.2F, second = 2.1F;
            Assert.IsFalse(Comparer.AreSimilar(first, second));
        }
        [TestMethod]
        public void IntArray_values_are_similar_test()
        {
            int[] first = new int[] { 1, 2, 3 };
            int[] second = new int[] { 1, 2, 3 };
            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }
        [TestMethod]
        public void IntArrayDifferentElementPosition_values_are_similar_test()
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
            Assert.IsFalse(Comparer.AreSimilar(first, second));
        }
        [TestMethod]
        public void IntArray_values_are_not_similar_test()
        {
            int[] first = new int[] { 1, 2, 3 };
            int[] second = new int[] { 2, 1, 4 };
            Assert.IsFalse(Comparer.AreSimilar(first, second));
        }
        [TestMethod]
        public void StingArray_values_are_similar_test()
        {
            string[] first = new string[] { "abcd","pqr" };
            string[] second = new string[] { "abcd", "pqr" };
            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }
        [TestMethod]
        public void StingArray_values_are_notsimilar_test()
        {
            string[] first = new string[] { "abcd", "pqr" };
            string[] second = new string[] { "dfs", "pdsfdfqr" };
            Assert.IsFalse(Comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void Object_Property_values_are_similar_test()
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
        public void Object_Property_values_are_notsimilar_test()
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

            Assert.IsFalse(Comparer.AreSimilar(first, second));
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

        [TestMethod]       
        public void Object_with_list_similar_test()
        {
            var s1 =new Student()
            {
                Id = 101,
                Name = "Mahesh",
                Codes = new string[] { "MH", "IN" },
                Marks = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
            };
            var s2 = new Student()
            {
                Id = 101,
                Name = "Mahesh",
                Codes = new string[] { "MH", "IN" },
                Marks = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
            };    
            Assert.IsTrue(Comparer.AreSimilar(s1, s2));
        }
        [TestMethod]
        public void Object_with_list_Not_similar_test()
        {
            var s1 = new Student()
            {
                Id = 101,
                Name = "Mahesh",
                Codes = new string[] { "MH", "IN" },
                Marks = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
            };
            var s2 = new Student()
            {
                Id = 101,
                Name = "Santosh",
                Codes = new string[] { "MH", "IN" },
                Marks = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
            };
            Assert.IsFalse(Comparer.AreSimilar(s1, s2));
        }

        [TestMethod]
        public void List_Of_Object_similar_test()
        {
            var s1 = new List<Student>();
            s1.Add(new Student()
            {
                Id = 101,
                Name = "Mahesh",
                Codes = new string[] { "MH", "IN" },
                Marks = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
            });
            s1.Add(new Student()
            {
                Id = 102,
                Name = "Ramesh",
                Codes = new string[] { "MH", "IN" },
                Marks = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
            });

            var s2 = new List<Student>();
            s2.Add(new Student()
            {
                Id = 101,
                Name = "Mahesh",
                Codes = new string[] { "MH", "IN" },
                Marks = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
            });
            s2.Add(new Student()
            {
                Id = 102,
                Name = "Ramesh",
                Codes = new string[] { "MH", "IN" },
                Marks = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
            });

            Assert.IsTrue(Comparer.AreSimilar(s1, s2));

        }
        [TestMethod]
        public void List_Of_Object_Not_similar_test()
        {
            var s1 = new List<Student>();
            s1.Add(new Student()
            {
                Id = 101,
                Name = "Mahesh",
                Codes = new string[] { "MH", "IN" },
                Marks = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
            });
            s1.Add(new Student()
            {
                Id = 102,
                Name = "Ramesh",
                Codes = new string[] { "MH", "IN" },
                Marks = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
            });

            var s2 = new List<Student>();
            s2.Add(new Student()
            {
                Id = 101,
                Name = "Raju",
                Codes = new string[] { "MH", "IN" },
                Marks = new List<int>() { 1, 2, 3, 4, 5,}
            });
            s2.Add(new Student()
            {
                Id = 102,
                Name = "Ramesh",
                Codes = new string[] { "MH", "IN" },
                Marks = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
            });

            Assert.IsFalse(Comparer.AreSimilar(s1, s2));

        }


        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string[] Codes { get; set; }
            public List<int> Marks { get; set; }
        }

    }
}
