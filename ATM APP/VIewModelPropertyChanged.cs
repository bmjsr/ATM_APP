using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_APP
{
    public class VIewModelPropertyChanged:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(String PropertyName)
        {
            var Handler = PropertyChanged;
            if (Handler != null)
            {
                Handler(this, new PropertyChangedEventArgs(PropertyName));
            }

        }
    }
}
