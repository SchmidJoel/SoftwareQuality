using PhoneNumbers;
using SoftwareQuality.BusinessLogic;
using SoftwareQuality.Model;
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
            var viewModel = DataContext as MainViewModel;

            IPhoneNumberParser parser = new PhoneNumberParser();
            PhoneNumberModel numberModel = new PhoneNumberModel();
            bool isValidNumber = parser.ParsePhoneNumber(viewModel.InputNumber, out numberModel);

            viewModel.CountryCode = numberModel.ISOCountryText;
            viewModel.AreaCode = numberModel.AreaCode;
            viewModel.MainCode = numberModel.ParticipantNumber;
            viewModel.Extension = numberModel.Extension;
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
