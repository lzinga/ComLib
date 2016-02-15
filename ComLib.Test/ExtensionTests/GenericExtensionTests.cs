using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using ComLib.Extension;

namespace ComLib.Test
{
    [TestClass]
    public class GenericExtensionTests
    {
        [TestMethod]
        public void IsNullOrDefaultTest()
        {
            FileInfo file = null;
            Assert.IsTrue(file.IsNullOrEmpty());

            file = new FileInfo("Test.bin");
            Assert.IsTrue(!file.IsNullOrEmpty());
        }

        [TestMethod]
        public void SerializeTest()
        {
            TestClass obj = new TestClass();
            string serializeFile = obj.Serialize();
            Assert.IsTrue(!serializeFile.IsNullOrEmpty());
        }

        [TestMethod]
        public void DeserializeTest()
        {
            TestClass obj = new TestClass();
            string serializedObject = obj.Serialize();

            TestClass deserializedObject = serializedObject.Deserialize<TestClass>();
            Assert.IsTrue(!deserializedObject.IsNullOrEmpty());
        }
    }
}
