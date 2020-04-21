using SoftwareQuality.Model;

namespace SoftwareQuality.BusinessLogic
{
    /// <summary>
    /// Phone number parser to certain fields
    /// </summary>
    public interface IPhoneNumberParser
    {
        /// <summary>
        /// parses and validates a phone number
        /// </summary>
        /// <param name="input">given phone number</param>
        /// <param name="number">structured phone number</param>
        /// <returns>true if phone number is valid</returns>
        bool ParsePhoneNumber(string input, out PhoneNumberModel number);
    }
}
