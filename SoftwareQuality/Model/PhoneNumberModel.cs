namespace SoftwareQuality.Model
{
    /// <summary>
    /// Intermediat representation of a phone number
    /// split up by its partial codes and extensions
    /// </summary>
    public class PhoneNumberModel
    {
        public string CountryCode { get; set; }

        public string ISOCountryText { get; set; }

        public string AreaCode { get; set; }

        public string ParticipantNumber { get; set; }

        public string Extension { get; set; }

        public string Formatted { get => ToString(); }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(CountryCode))
            {
                return string.Format($"{AreaCode} {ParticipantNumber} {Extension}");
            }
            return string.Format($"+{CountryCode} {AreaCode} {ParticipantNumber} {Extension}");
        }

        public override bool Equals(object obj)
        {
            var number = obj as PhoneNumberModel;
            return CountryCode.Equals(number.CountryCode) &&
                ISOCountryText.Equals(number.ISOCountryText) &&
                AreaCode.Equals(number.AreaCode) &&
                ParticipantNumber.Equals(number.ParticipantNumber) &&
                (Extension == null && number.Extension == null || Extension.Equals(number.Extension));
        }
    }
}
