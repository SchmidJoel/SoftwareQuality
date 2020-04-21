using SoftwareQuality.Model;

namespace SoftwareQuality.BusinessLogic
{
    public interface IPhoneNumberParser
    {
        bool ParsePhoneNumber(string input, out PhoneNumberModel number);
    }
}
