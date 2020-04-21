using System.Windows;

namespace SoftwareQuality
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            string phonenumber = "044 668 000 111 00";
            PhoneNumberParser parser = new PhoneNumberParser(phonenumber);
            string cc = parser.CountryCode;
            string localCode = parser.LocalCode;
            string participant = parser.ParticipantNumber;
            string ext = parser.Extension;
        }
    }
}
