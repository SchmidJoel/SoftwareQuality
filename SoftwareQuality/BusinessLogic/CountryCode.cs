using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SoftwareQuality
{
    /// <summary>
    /// identifies ISO country code text to country code
    /// </summary>
    public class CountryCode
    {
        private readonly IDictionary<string, string> _Codes;

        public CountryCode()
        {
            var text = File.ReadAllText("./CountryCode.json");
            _Codes = JsonConvert.DeserializeObject<Dictionary<string, string>>(text);
        }

        /// <summary>
        /// gets the ISO country text to the given country code
        /// </summary>
        /// <param name="countryCode">country code as string</param>
        /// <returns>country code text with 2 digits</returns>
        public string GetISOCode(string countryCode)
        {
            if (_Codes.ContainsKey(countryCode))
            {
                return _Codes[countryCode];
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// gets the country code to the given ISO country code string
        /// </summary>
        /// <param name="isoCode">ISO code with 2 digits</param>
        /// <returns>country code</returns>
        public string GetCountryCode(string isoCode)
        {
            if (_Codes.Values.Contains(isoCode))
            {
                return _Codes.First(kv => kv.Value.Equals(isoCode)).Key;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// get all ISO country codes
        /// </summary>
        /// <returns></returns>
        public List<string> GetCountryCodes()
        {
            return _Codes.Values.OrderBy(v => v).ToList();
        }
    }
}
