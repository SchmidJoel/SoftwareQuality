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
            phoneNumberParser = new PhoneNumberParser();
        }

        [TestMethod]
        public void Test_plus490201123456()
        {
            // Arrange
            var model = new PhoneNumberModel
            {
                AreaCode = "201",
                CountryCode = "49",
                Extension = null,
                ISOCountryText = "DE",
                ParticipantNumber = "123456"
            };

            // Act
            var success = phoneNumberParser.ParsePhoneNumber("+49 0201 123456", out var number);

            // Assert
            Assert.IsTrue(success);
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
                Extension = null,
                ISOCountryText = "GB",
                ParticipantNumber = "123456"
            };

            // Act
            var success = phoneNumberParser.ParsePhoneNumber("+44 0201123456", out var number);

            // Assert
            Assert.IsFalse(success);
            Assert.IsNull(number);
        }

        [TestMethod]
        public void Test_00490201123456()
        {
            // Arrange
            var model = new PhoneNumberModel
            {
                AreaCode = "201",
                CountryCode = "49",
                Extension = null,
                ISOCountryText = "DE",
                ParticipantNumber = "123456"
            };

            // Act
            var success = phoneNumberParser.ParsePhoneNumber("0049 0201/123456", out var number);

            // Assert
            Assert.IsTrue(success);
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
                Extension = null,
                ISOCountryText = "DE",
                ParticipantNumber = "123456"
            };

            // Act
            var success = phoneNumberParser.ParsePhoneNumber("0049201123456", out var number);

            // Assert
            Assert.IsTrue(success);
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
                Extension = null,
                ISOCountryText = "DE",
                ParticipantNumber = "123456"
            };

            // Act
            var success = phoneNumberParser.ParsePhoneNumber("(0)201 1234 56", out var number);

            // Assert
            Assert.IsTrue(success);
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
                ParticipantNumber = "790"
            };

            // Act
            var success = phoneNumberParser.ParsePhoneNumber("+49 (941) 790-4780", out var number);

            // Assert
            Assert.IsTrue(success);
            Assert.AreEqual(model, number);
        }

        [TestMethod]
        public void Test_015115011900()
        {
            // Arrange
            var model = new PhoneNumberModel
            {
                AreaCode = "1511",
                CountryCode = "49",
                Extension = null,
                ISOCountryText = "DE",
                ParticipantNumber = "5011900"
            };

            // Act
            var success = phoneNumberParser.ParsePhoneNumber("015115011900", out var number);

            // Assert
            Assert.IsTrue(success);
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
                Extension = null,
                ISOCountryText = "IN",
                ParticipantNumber = "87899"
            };

            // Act
            var success = phoneNumberParser.ParsePhoneNumber("+91 09870987 899", out var number);

            // Assert
            Assert.IsTrue(success);
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
            var success = phoneNumberParser.ParsePhoneNumber("[+49] (0)89-800/849-50", out var number);

            // Assert
            Assert.IsTrue(success);
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
            var success = phoneNumberParser.ParsePhoneNumber("+49 (8024) [990-477]", out var number);

            // Assert
            Assert.IsTrue(success);
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
                Extension = null,
                ISOCountryText = "US/CA",
                ParticipantNumber = ""
            };

            // Act
            var success = phoneNumberParser.ParsePhoneNumber("+1 628 21855", out var number);

            // Assert
            Assert.IsFalse(success);
            Assert.IsNull(number);
        }

    }
}
