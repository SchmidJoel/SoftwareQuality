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
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }

    public class PhoneNumberVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converter zum Anzeigen/Verstecken eines PhoneNumberModels
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null && value is PhoneNumberModel && string.IsNullOrEmpty((value as PhoneNumberModel).Formatted.Trim()))
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
