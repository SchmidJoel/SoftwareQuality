using System.ComponentModel;

namespace SoftwareQuality
{
    class PhoneNumber : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if(e != null)
            {
                PropertyChanged(this, e);
            }
        }

        private string inputNumber;
        public string InputNumber { 
            get => inputNumber; 
            set {
                inputNumber = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(InputNumber)));
            } }

        private string countryShort;
        public string CountryShort
        {
            get => countryShort;
            set
            {
                countryShort = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(CountryShort)));
            }
        }

        private string countryCode;
        public string CountryCode
        {
            get => countryCode;
            set
            {
                countryCode = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(CountryCode)));
            }
        }

        private string areaCode;
        public string AreaCode
        {
            get => areaCode;
            set
            {
                areaCode = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(AreaCode)));
            }
        }

        private string mainCode;
        public string MainCode
        {
            get => mainCode;
            set
            {
                mainCode = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(MainCode)));
            }
        }

        private string extension;
        public string Extension
        {
            get => extension;
            set
            {
                extension = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Extension)));
            }
        }
    }
}
