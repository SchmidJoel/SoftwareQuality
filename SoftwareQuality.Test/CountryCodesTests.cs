using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SoftwareQuality.Test
{
    [TestClass]
    public class CountryCodesTests
    {
        [TestMethod]
        public void ISOCodeTest()
        {
            var code = new CountryCode();

            Assert.AreEqual("DE", code.GetISOCode("49"));
            Assert.AreEqual("GB", code.GetISOCode("44"));
            Assert.AreEqual("US/CA", code.GetISOCode("1"));
            Assert.AreEqual(string.Empty, code.GetISOCode("45z2387"));
        }
    }
}
