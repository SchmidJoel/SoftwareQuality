using SoftwareQuality.BusinessLogic;
using SoftwareQuality.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace SoftwareQuality.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private IPhoneNumberParser phoneNumberParser = new PhoneNumberParser();
        private CountryCode codes = new CountryCode();

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (e != null)
            {
                PropertyChanged(this, e);
            }
        }

        public RelayCommand ParsePhoneNumberCommand { get; private set; }       

        /// <summary>
        /// Ergebnis einer geparsten Telefonnummer
        /// </summary>
        private PhoneNumberModel phoneNumberModel = new PhoneNumberModel();
        public PhoneNumberModel PhoneNumberModel
        {
            get => phoneNumberModel;
            set
            {
                phoneNumberModel = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(PhoneNumberModel)));
            }
        }

        /// <summary>
        /// Ausgewähltes Standardland
        /// </summary>
        private string selectedCountryCode;
        public string SelectedCountryCode
        {
            get => selectedCountryCode;
            set
            {
                selectedCountryCode = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(SelectedCountryCode)));
            }
        }

        /// <summary>
        /// Eingegebene Nummer
        /// </summary>
        private string inputNumber;
        public string InputNumber
        {
            get => inputNumber;
            set
            {
                inputNumber = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(InputNumber)));
            }
        }

        /// <summary>
        /// Mögliche CountryCodes zur Anzeige für Defaultland
        /// </summary>
        public ObservableCollection<string> CountryCodes { get; } = new ObservableCollection<string>();
        public MainViewModel()
        {
            ParsePhoneNumberCommand = new RelayCommand(ParsePhoneNumber, o => true);
            codes.GetCountryCodes().ForEach(c => CountryCodes.Add(c));
            selectedCountryCode = "DE";
        }

        /// <summary>
        /// Validieren, Parsen der eingegebenen Telefonnummer
        /// </summary>
        /// <param name="obj"></param>
        private void ParsePhoneNumber(object obj)
        {
            PhoneNumberModel model;
            var input = InputNumber;
            if(!(input.StartsWith("+") || input.StartsWith("00")))
            {
                input = string.Format($"+{codes.GetCountryCode(SelectedCountryCode)}{input}");
            }
            if(phoneNumberParser.ParsePhoneNumber(input, out model))
            {
                PhoneNumberModel = model;
                InputNumber = input;
            }
            else
            {
                MessageBox.Show("Sie haben eine ungültige Nummer eingegeben! Bitte überprüfen Sie Ihre Eingaben", "Achtung");
            }
        }
    }

    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
