using PhoneNumbers;
using SoftwareQuality.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SoftwareQuality.BusinessLogic
{
    /// <summary>
    /// Parses international phone numbers to a intermediate
    /// representation
    /// </summary>
    public class PhoneNumberParser : IPhoneNumberParser
    {
        private readonly PhoneNumberUtil phoneUtil;
        private const int numberOfPartialCodes = 3;

        public PhoneNumberParser()
        {
            phoneUtil = PhoneNumberUtil.GetInstance();
        }

        /// <summary>
        /// Parses a phone number into an intermediate representation in order
        /// to retrieve its country code, area code, participant number and 
        /// extension
        /// </summary>
        /// <param name="input">Phone number to be parsed</param>
        /// <param name="parsedNumber">Intermediate representation of partial phone number codes</param>
        /// <returns>Returns a boolean value indicating if the input string is a valid phone number</returns>
        public bool ParsePhoneNumber(string input, out PhoneNumberModel parsedNumber)
        {
            PhoneNumberModel number = new PhoneNumberModel();
            if (input.StartsWith("00"))
                input = "+" + input.Remove(0, 2);

            input = Regex.Replace(input, @"[()\[\]/]", "");

            List<string> parts = input.Split('-').ToList();
            if (parts.Count > 1)
            {
                number.Extension = parts.Last();
                parts.RemoveAt(parts.Count - 1);
                input = string.Join("", parts);
            }

            PhoneNumber numberRepresentation = GetPhoneNumberRepresentation(input);
            if (phoneUtil.IsValidNumber(numberRepresentation))
            {
                GetPartialCodes(ref number, numberRepresentation);
                parsedNumber = number;
                return true;
            }
            else
            {
                parsedNumber = null;
                return false;
            }

        }

        /// <summary>
        /// Transforms a given string into a google phone number
        /// representation to be used by Google libphonenumber library
        /// </summary>
        /// <param name="number">Phone number to be transformed</param>
        /// <returns>Google phone number repesentation used by 
        /// libphonenumber library</returns>
        private PhoneNumber GetPhoneNumberRepresentation(string number)
        {
            PhoneNumber parsed;
            try
            {
                parsed = phoneUtil.Parse(number, "DE");
            }
            catch (NumberParseException)         //Phone number is not valid
            {
                return null;
            }

            return parsed;
        }


        /// <summary>
        /// Extracts the partial codes of the phone number
        /// </summary>
        /// <param name="numberModel">Google phone number representation to extract codes from</param>
        /// <param name="numberRepresentation">Intermediate representation containing the partial codes</param>
        private void GetPartialCodes(ref PhoneNumberModel numberModel, PhoneNumber numberRepresentation)
        {
            /*Format phonenumber to international representation*/
            string internationalRep = phoneUtil.Format(numberRepresentation, PhoneNumberFormat.INTERNATIONAL);

            /*Parse out partial codes*/
            string[] parts = internationalRep.Split(new char[0]);           //split by whitespaces which represent the borders of partial codes within the international representation

            /*Initialize empty string for country code, local code and participant number*/
            string[] partialCodes = new string[numberOfPartialCodes];
            Array.Fill(partialCodes, string.Empty);
            parts.Take(numberOfPartialCodes).ToArray().CopyTo(partialCodes, 0);

            /*Extract partial codes from result array*/
            numberModel.CountryCode = partialCodes[0].Remove(partialCodes[0].IndexOf('+'), 1);              //Remove country code prefix(+)
            numberModel.AreaCode = partialCodes[1];
            numberModel.ParticipantNumber = partialCodes[2];

            /*Select ISO textual country representation corresponding the numeric country code*/
            CountryCode codePicker = new CountryCode();
            numberModel.ISOCountryText = codePicker.GetISOCode(numberModel.CountryCode);
        }
    }
}
