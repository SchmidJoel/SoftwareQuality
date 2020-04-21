using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

            DataContext = new PhoneNumber();
        }

        private void ParsePhonenumber(object sender, RoutedEventArgs e)
        {
            var phoneNumber = DataContext as PhoneNumber;

            if (Validation.IsPhoneNumber(phoneNumber.InputNumber))
            {
                PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
                var parsedNumber = phoneUtil.Parse(phoneNumber.InputNumber, "");
                PhoneNumberParser parser = new PhoneNumberParser(phoneUtil.Format(parsedNumber, PhoneNumberFormat.INTERNATIONAL));

                phoneNumber.CountryShort = Code.GetISOCode(parser.CountryCode);
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
