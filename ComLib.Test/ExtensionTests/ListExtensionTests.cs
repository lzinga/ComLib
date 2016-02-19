using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ComLib.Extensions;
using System.Linq;

namespace ComLib.Test
{
    [TestClass]
    public class ListExtensionTests
    {
        [TestMethod]
        public void ToStringTest()
        {
            List<int> test = new List<int>();
            test.Add(1);
            test.Add(2);

            string result = test.ToString<int>();

            Assert.IsTrue(result.Equals("List`1 { 1 , 2 }"));
        }

        [TestMethod]
        public void DistinctByTest()
        {
            List<TestClass> test = new List<TestClass>();
            test.Add(new TestClass() { TestInt = 1 });
            test.Add(new TestClass() { TestInt = 1 });
            test.Add(new TestClass() { TestInt = 2 });
            test.Add(new TestClass() { TestInt = 2 });
            test.Add(new TestClass() { TestInt = 3 });
            test.Add(new TestClass() { TestInt = 3 });
            test.Add(new TestClass() { TestInt = 4 });
            test.Add(new TestClass() { TestInt = 4 });

            List<TestClass> distinct = test.DistinctBy(i => i.TestInt).OrderBy(i => i.TestInt).ToList();
            int count = distinct.Count();

            // The distinct should get unique TestInt making it 1, 2, 3, 4 and thats it no more.
            Assert.IsTrue(count == 4);
        }
    }
}
