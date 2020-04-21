using System.ComponentModel;

namespace SoftwareQuality.Model
{
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
            return string.Format($"{CountryCode} {AreaCode} {ParticipantNumber} {Extension}");
        }
    }
}
