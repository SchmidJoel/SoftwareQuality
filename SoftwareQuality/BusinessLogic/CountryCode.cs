using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

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
    }
}
