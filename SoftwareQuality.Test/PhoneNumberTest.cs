using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftwareQuality.BusinessLogic;
using SoftwareQuality.Model;

namespace SoftwareQuality.Test
{
    [TestClass]
    public class PhoneNumberTest
    {
        private IPhoneNumberParser phoneNumberParser;

        [TestInitialize]
        public void init()
        {
            // TODO init phoneNumberParser
        }

        [TestMethod]
        public void Test_plus490201123456()
        {
            // Arrange
            var model = new PhoneNumberModel
            {
                AreaCode = "201",
                CountryCode = "49",
                Extension = "",
                ISOCountryText = "DE",
                ParticipantNumber = "123456"
            };

            // Act
            var number = phoneNumberParser.ParsePhoneNumber("+49 0201 123456");

            // Assert
            Assert.AreEqual(model, number);
        }

        [TestMethod]
        public void Test_plus440201123456()
        {
            // Arrange
            var model = new PhoneNumberModel
            {
                AreaCode = "201",
                CountryCode = "44",
                Extension = "",
                ISOCountryText = "GB",
                ParticipantNumber = "123456"
            };

            // Act
            var number = phoneNumberParser.ParsePhoneNumber("+44 0201123456");

            // Assert
            Assert.AreEqual(model, number);
        }

        [TestMethod]
        public void Test_00330201123456()
        {
            // Arrange
            var model = new PhoneNumberModel
            {
                AreaCode = "201",
                CountryCode = "33",
                Extension = "",
                ISOCountryText = "FR",
                ParticipantNumber = "123456"
            };

            // Act
            var number = phoneNumberParser.ParsePhoneNumber("0033 0201/123456");

            // Assert
            Assert.AreEqual(model, number);
        }

        [TestMethod]
        public void Test_0049201123456()
        {
            // Arrange
            var model = new PhoneNumberModel
            {
                AreaCode = "201",
                CountryCode = "49",
                Extension = "",
                ISOCountryText = "DE",
                ParticipantNumber = "123456"
            };

            // Act
            var number = phoneNumberParser.ParsePhoneNumber("0049201123456");

            // Assert
            Assert.AreEqual(model, number);
        }

        [TestMethod]
        public void Test_0201123456()
        {
            // Arrange
            var model = new PhoneNumberModel
            {
                AreaCode = "201",
                CountryCode = "49",
                Extension = "",
                ISOCountryText = "DE",
                ParticipantNumber = "123456"
            };

            // Act
            var number = phoneNumberParser.ParsePhoneNumber("(0)201 1234 56");

            // Assert
            Assert.AreEqual(model, number);
        }

        [TestMethod]
        public void Test_plus499417904780()
        {
            // Arrange
            var model = new PhoneNumberModel
            {
                AreaCode = "941",
                CountryCode = "49",
                Extension = "4780",
                ISOCountryText = "DE",
                ParticipantNumber = "760"
            };

            // Act
            var number = phoneNumberParser.ParsePhoneNumber("+49 (941) 790-4780");

            // Assert
            Assert.AreEqual(model, number);
        }

        [TestMethod]
        public void Test_015115011900()
        {
            // Arrange
            var model = new PhoneNumberModel
            {
                AreaCode = "151",
                CountryCode = "49",
                Extension = "",
                ISOCountryText = "DE",
                ParticipantNumber = "15011900"
            };

            // Act
            var number = phoneNumberParser.ParsePhoneNumber("015115011900");

            // Assert
            Assert.AreEqual(model, number);
        }

        [TestMethod]
        public void Test_plus9109870987899()
        {
            // Arrange
            var model = new PhoneNumberModel
            {
                AreaCode = "98709",
                CountryCode = "91",
                Extension = "",
                ISOCountryText = "IN",
                ParticipantNumber = "87899"
            };

            // Act
            var number = phoneNumberParser.ParsePhoneNumber("+91 09870987 899");

            // Assert
            Assert.AreEqual(model, number);
        }

        [TestMethod]
        public void Test_plus4908980084950()
        {
            // Arrange
            var model = new PhoneNumberModel
            {
                AreaCode = "89",
                CountryCode = "49",
                Extension = "50",
                ISOCountryText = "DE",
                ParticipantNumber = "800849"
            };

            // Act
            var number = phoneNumberParser.ParsePhoneNumber("[+49] (0)89-800/849-50");

            // Assert
            Assert.AreEqual(model, number);
        }

        [TestMethod]
        public void Test_plus498024990477()
        {
            // Arrange
            var model = new PhoneNumberModel
            {
                AreaCode = "8024",
                CountryCode = "49",
                Extension = "477",
                ISOCountryText = "DE",
                ParticipantNumber = "990"
            };

            // Act
            var number = phoneNumberParser.ParsePhoneNumber("+49 (8024) [990-477]");

            // Assert
            Assert.AreEqual(model, number);
        }

        [TestMethod]
        public void Test_pus162821855()
        {
            // Arrange
            var model = new PhoneNumberModel
            {
                AreaCode = "62821855",
                CountryCode = "1",
                Extension = "",
                ISOCountryText = "US/CA",
                ParticipantNumber = ""
            };

            // Act
            var number = phoneNumberParser.ParsePhoneNumber("+1 628 21855");

            // Assert
            Assert.AreEqual(model, number);
        }

    }
}
