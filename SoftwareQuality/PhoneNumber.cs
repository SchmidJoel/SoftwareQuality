using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

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

        private int countryCode;
        public int CountryCode
        {
            get => countryCode;
            set
            {
                countryCode = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(CountryCode)));
            }
        }

        private int areaCode;
        public int AreaCode
        {
            get => areaCode;
            set
            {
                areaCode = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(AreaCode)));
            }
        }

        private int mainCode;
        public int MainCode
        {
            get => mainCode;
            set
            {
                mainCode = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(MainCode)));
            }
        }

        private int extension;
        public int Extension
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
