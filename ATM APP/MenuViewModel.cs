using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Data;
namespace ATM_APP
{
    public class MenuViewModel:VIewModelPropertyChanged
    {
          
        string ConString = "Data Source=(DESCRIPTION =" +
    "(ADDRESS = (PROTOCOL = TCP)(HOST = LAPTOP-TVRMPHSE)(PORT = 1521))" +
    "(CONNECT_DATA =" +
      "(SERVER = DEDICATED)" +
      "(SERVICE_NAME = XE)" +
    ")" +
  ");User Id=mydba1;Password=db123;";//ConnectionString
       // public string cust_name;
        public string cust_balance;
        public WithdrawViewModel childvmm1;
        public MenuViewModel()
        {
            childvmm1 = new WithdrawViewModel();
        }
        public void CheckBal() 
        {         
          try
            {
              using (OracleConnection con = new OracleConnection(ConString))
                {
                    con.Open();

                    OracleCommand cmd = new OracleCommand("SELECT acc_bal FROM Customer1 where card_no='"+CardNo+"' and card_pin='"+Pin+"' ", con);
                   // OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    OracleDataReader odr = cmd.ExecuteReader();
                    if (odr.Read())
                    {
                        cust_balance = Convert.ToString(odr.GetValue(0));
                        MessageBox.Show(Custlbl+" Your Balance is "+cust_balance+" Rupees only ");
                        //Page1 pg=new Page1();
                        //pg.InitializeComponent();
                    }

                    else
                        MessageBox.Show("Invalid username or password");  
  
                  //  datagridview1.ItemsSource=dt.DefaultView;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void WithdrawAmt()
        {
            WithdrawMoney withdrmnyscrn = new WithdrawMoney();
            withdrmnyscrn.Show();
            childvmm1.CardNo1 = CardNo;
            childvmm1.Pin1 = Pin;
        }
        
        
        public ICommand CmdCheckBal
        {
            get { return new DelegateCommand(CheckBal); }
        }
        public ICommand CmdWithdrawAmt
        {
            get { return new DelegateCommand(WithdrawAmt); }
        }

        public ICommand CmdChngPin
        {
            get { return new DelegateCommand(ChngPin); }
        }
        public ICommand CmdTransferMoney
        {
            get { return new DelegateCommand(transfer_money); }
        }

        public ICommand CmdMiniStatement
        {
            get { return new DelegateCommand(ministmt); }
        }
        private void ministmt()
        {
            MiniStatement miniscreen = new MiniStatement();
            miniscreen.Show();
           
        }

        private void transfer_money()
        {
            TransferMoney trnsfrmny = new TransferMoney();
            trnsfrmny.Show();
        }

        private void ChngPin()
        {
            PINChange pinchngscreen = new PINChange();
            pinchngscreen.Show();
        }
        

        public string _card_no;

        public string CardNo
        {
            get { return _card_no; }
            set
            {
                _card_no = value;
                OnPropertyChanged("CardNo");
            }
        }

        public string _pin;

        public string Pin
        {
            get { return _pin; }
            set
            {
                _pin = value;
                OnPropertyChanged("Pin");
            }
        }

        public string _custlbl;
        public string Custlbl
        {
            get { return _custlbl; }
            set
            {
                _custlbl = value;
                OnPropertyChanged("Custlbl");
            }
        }

        
    }
}
