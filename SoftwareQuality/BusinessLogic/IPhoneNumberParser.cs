using SoftwareQuality.Model;

namespace SoftwareQuality.BusinessLogic
{
    public interface IPhoneNumberParser
    {
        PhoneNumberModel ParsePhoneNumber(string input);
    }
}
