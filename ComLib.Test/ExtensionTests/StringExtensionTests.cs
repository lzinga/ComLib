using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComLib.Extensions;

namespace ComLib.Test
{
    [TestClass]
    public class StringExtenionTests
    {
        [TestMethod]
        public void FormatTest()
        {
            string testString = "{0} Format Test".FormatWith("SUCCESS");
            Assert.IsTrue(testString.Equals("SUCCESS Format Test"));
        }

        [TestMethod]
        public void ContainsTest()
        {
            string testString = "Does this StRiNg contain something?";
            Assert.IsTrue(testString.Contains("something"));
            Assert.IsTrue(testString.Contains("StRiNg"));
        }

        [TestMethod]
        public void TryReplaceTest()
        {
            string result = "Replace item with something else.";
            Assert.IsTrue(result.Replace("something", "nothing").Equals("Replace item with nothing else."));
            Assert.IsTrue(result.Replace("replace", "do nothing", StringComparison.OrdinalIgnoreCase).Equals("do nothing item with something else."));
        }
    }
}
