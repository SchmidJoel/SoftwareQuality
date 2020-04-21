using System;

namespace SoftwareQuality
{
    public class PhoneNumberParser
    {
        #region Properties

        public string CountryCode
        {
            get
            {
                if (partialCodes[0] == null)
                    Parse();
                return partialCodes[0];
            }
        }

        public string LocalCode
        {
            get
            {
                if (partialCodes[1] == null)
                    Parse();
                return partialCodes[1];
            }
        }

        public string ParticipantNumber
        {
            get
            {
                if (partialCodes[2] == null)
                    Parse();
                return partialCodes[2];
            }
        }

        public string Extension
        {
            get
            {
                if (partialCodes[3] == null)
                    Parse();
                return partialCodes[3];
            }
        }

        #endregion Properties

        private string phonenumber;
        private string[] partialCodes;

        public PhoneNumberParser(string phonenumber)
        {
            this.phonenumber = phonenumber;
            this.partialCodes = new string[4];
        }

        private void Parse()
        {
            /*Initialize empty string for country code, local code, participant number and extension*/
            Array.Fill<string>(partialCodes, String.Empty);

            string t = partialCodes[0];

            phonenumber.Trim('+');                                   //Remove country code prefix
            if (phonenumber.StartsWith('0'))
                phonenumber.Remove(0, 1);                           //Remove Leading '0'

            string[] parts = phonenumber.Split(new char[0]);        //split by whitespaces

            for (int i = 0; i < parts.Length; i++)
            {
                partialCodes[i] = parts[i];

                if (i >= partialCodes.Length-1)
                    break;
            }
        }
    }
}
