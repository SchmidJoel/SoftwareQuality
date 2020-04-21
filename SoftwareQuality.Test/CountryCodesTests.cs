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

        [TestMethod]
        public void Test()
        {
            var util = PhoneNumbers.PhoneNumberUtil.GetInstance();

            var number = util.Parse("+91 09870987 899", null);

            Console.WriteLine(util.Format(number, PhoneNumbers.PhoneNumberFormat.INTERNATIONAL));

            Assert.IsNotNull(number);
        }
    }
}
