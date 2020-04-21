using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SoftwareQuality
{
    static class Validation
    {
        public static bool IsPhoneNumber(string number)
        {

            return Regex.Match(number, @"^\(?(\+|0)\(?[0-9]{1,3}\)?[ ()]?([- /()]?\d[- ()]?){4,15}$").Success;
        }
    }
   
}
