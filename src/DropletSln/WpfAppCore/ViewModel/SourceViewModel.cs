using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.CodeParser;

namespace WpfAppCore.ViewModel
{
    public class SourceViewModel : INotifyPropertyChanged
    {
        private string _fieldName;
        public int DropletCount  {get ; set;}
        public string DropletIdentifier { get; set; }
        public string FieldName
        {
            get => _fieldName;
            set => SetProperty(ref _fieldName, value, "FieldName");
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, string propertyName)
        {
            if ((storage == null && value == null) ||
                (storage != null && storage.Equals(value)))
                return false;

            storage = value;
            NotifyPropertyChanged(propertyName);
            return true;
        }
        #endregion

    }
}
