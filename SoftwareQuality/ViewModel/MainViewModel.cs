using SoftwareQuality.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace SoftwareQuality.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (e != null)
            {
                PropertyChanged(this, e);
            }
        }

        public RelayCommand ParsePhoneNumberCommand { get; private set; }       

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

        public ObservableCollection<string> CountryCodes { get; } = new ObservableCollection<string>();
        public MainViewModel()
        {
            ParsePhoneNumberCommand = new RelayCommand(ParsePhoneNumber, o => true);
            CountryCodes.Add("DE");
            CountryCodes.Add("US");
            //todo fill CountryCode Liste
            selectedCountryCode = CountryCodes[0];
        }

        private void ParsePhoneNumber(object obj)
        {
            var x = new PhoneNumberModel() { ISOCountryText = "DE", CountryCode = "+49", AreaCode = "1234", ParticipantNumber = "5678", Extension = "90" };
            PhoneNumberModel = x;
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
