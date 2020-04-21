using PhoneNumbers;
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
