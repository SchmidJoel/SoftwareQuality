using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SoftwareQuality
{
    public class CountryCode
    {
        private readonly IDictionary<string, string> _Codes;

        public CountryCode()
        {
            var text = File.ReadAllText("./CountryCode.json");
            _Codes = JsonConvert.DeserializeObject<Dictionary<string, string>>(text);
        }

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

        public List<string> GetCountryCodes()
        {
            return _Codes.Values.OrderBy(v => v).ToList(); ;
        }
    }
}
