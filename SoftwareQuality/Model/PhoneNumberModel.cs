﻿namespace SoftwareQuality.Model
{
    /// <summary>
    /// Intermediat representation of a phone number
    /// split up by its partial codes and extensions
    /// </summary>
    public class PhoneNumberModel
    {
        public string CountryCode;

        public string ISOCountryText;

        public string AreaCode;

        public string ParticipantNumber;

        public string Extension;

        public override bool Equals(object obj)
        {
            var number = obj as PhoneNumberModel;
            return CountryCode.Equals(number.CountryCode) &&
                ISOCountryText.Equals(number.ISOCountryText) &&
                AreaCode.Equals(number.AreaCode) &&
                ParticipantNumber.Equals(number.ParticipantNumber) &&
                Extension.Equals(number.Extension);
        }
    }
}