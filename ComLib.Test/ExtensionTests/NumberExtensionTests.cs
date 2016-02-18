using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ComLib.Extension;
using System.Linq;

namespace ComLib.Test
{
    [TestClass]
    public class NumberExtensionTests
    {
        [TestMethod]
        public void ToFileSizeStringTest()
        {
            // 9.54 MB
            long size = 0x989680;
            Assert.IsTrue(size.ToFileSizeString().Equals("9.54 MB"));
        }
    }
}
