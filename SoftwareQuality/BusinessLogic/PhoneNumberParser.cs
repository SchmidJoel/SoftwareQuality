using SoftwareQuality.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Documents;

namespace SoftwareQuality
{
    public class PhoneNumberParser
    {
        //#region Properties

        //public string CountryCode
        //{
        //    get
        //    {
        //        if (partialCodes[0] == null)
        //            Parse();
        //        return partialCodes[0];
        //    }
        //}

        //public string LocalCode
        //{
        //    get
        //    {
        //        if (partialCodes[1] == null)
        //            Parse();
        //        return partialCodes[1];
        //    }
        //}

        //public string ParticipantNumber
        //{
        //    get
        //    {
        //        if (partialCodes[2] == null)
        //            Parse();
        //        return partialCodes[2];
        //    }
        //}

        //public string Extension
        //{
        //    get
        //    {
        //        if (partialCodes[3] == null)
        //            Parse();
        //        return partialCodes[3];
        //    }
        //}

        ////#endregion Properties

        //private string phonenumber;
        //private string[] partialCodes;

        //public PhoneNumberParser(string phonenumber)
        //{
        //    this.phonenumber = phonenumber;
        //    this.partialCodes = new string[4];
        //}

        public static bool ParsePhoneNumber(string input)//,out PhoneNumberModel number)
        {
           PhoneNumberModel number=new PhoneNumberModel();
            if (input.StartsWith("00")) 
                input="+" + input.Remove(0, 2);

            input=Regex.Replace(input, @"[()\[\]/]", "");

            List<string> parts = input.Split('-').ToList();
            if (parts.Count > 1)
            {
                number.Extension=parts.Last();
                parts.RemoveAt(parts.Count - 1);
                input = string.Join("", parts);
            }
            //ToDo: Validation-Check
            //Todo: Lib-Parser

            

            return true;
        }

        //private void Parse()
        //{
        //    /*Initialize empty string for country code, local code, participant number and extension*/
        //    Array.Fill<string>(partialCodes, String.Empty);

        //    string t = partialCodes[0];

        //    phonenumber.Trim('+');                                   //Remove country code prefix
        //    if (phonenumber.StartsWith('0'))
        //        phonenumber.Remove(0, 1);                           //Remove Leading '0'

        //    string[] parts = phonenumber.Split(new char[0]);        //split by whitespaces

        //    for (int i = 0; i < parts.Length; i++)
        //    {
        //        partialCodes[i] = parts[i];

        //        if (i >= partialCodes.Length-1)
        //            break;
        //    }
        
    }
}
