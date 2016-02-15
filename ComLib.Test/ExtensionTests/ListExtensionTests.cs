using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ComLib.Extension;

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
    }
}
