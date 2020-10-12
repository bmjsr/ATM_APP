using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Input;

namespace ATM_APP
{
    public class Model:VIewModelPropertyChanged
    {
       // private int _card_no;

        public int _card_no;

        public int CardNo
        {
            get { return _card_no; }
            set { _card_no = value;
            OnPropertyChanged("CardNo");
            }
        }

        public int _pin;

        public int Pin
        {
            get { return _pin; }
            set
            {
                _pin = value;
                OnPropertyChanged("Pin");
            }
        }

       
        
        
        



    }
}
