using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComLib.Extension;

namespace ComLib.Test
{
    [TestClass]
    public class StringExtenionTests
    {
        [TestMethod]
        public void FormatTest()
        {
            string test = "{0} Format Test".FormatWith("SUCCESS");
            Assert.IsTrue(test.Equals("SUCCESS Format Test"));
        }
    }
}
