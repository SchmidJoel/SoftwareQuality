using PhoneNumbers;
<<<<<<< HEAD
using SoftwareQuality.BusinessLogic;
=======
>>>>>>> 80614def174e7ca5111e2a4ef96cdd3dc140051b
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
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
<<<<<<< HEAD

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
=======
>>>>>>> 80614def174e7ca5111e2a4ef96cdd3dc140051b
    }

    public class PhoneNumberVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is PhoneNumberModel && string.IsNullOrEmpty((value as PhoneNumberModel).Formatted.Trim()))
            {
                return Visibility.Collapsed;
            }
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
