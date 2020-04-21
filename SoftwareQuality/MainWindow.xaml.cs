using PhoneNumbers;
using SoftwareQuality.ViewModel;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SoftwareQuality
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        CountryCode Code;

        public MainWindow()
        {
            InitializeComponent();

            Code = new CountryCode();

            DataContext = new MainViewModel();
        }

        private void ParsePhonenumber(object sender, RoutedEventArgs e)
        {
            var phoneNumber = DataContext as MainViewModel;

            if (Validation.IsPhoneNumber(phoneNumber.InputNumber))
            {
                PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
                var parsedNumber = phoneUtil.Parse(phoneNumber.InputNumber, "");
                PhoneNumberParser parser = new PhoneNumberParser(phoneUtil.Format(parsedNumber, PhoneNumberFormat.INTERNATIONAL));

                phoneNumber.CountryCode = parsedNumber.CountryCode.ToString();
                phoneNumber.AreaCode = parser.LocalCode;
                phoneNumber.MainCode = parser.ParticipantNumber;
                phoneNumber.Extension = parser.Extension;
                phoneNumber.CountryShort = Code.GetISOCode(parsedNumber.CountryCode.ToString());
            }
            else
            {
                MessageBox.Show("Sie haben eine ungültige Nummer eingegeben! Bitte überprüfen Sie Ihre Eingaben", "Achtung");
            }            
        }
    }

    public class IntToString : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int ret = 0;
            return int.TryParse((string)value, out ret) ? ret : 0;
        }
    }
}
