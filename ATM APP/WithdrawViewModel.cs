using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ATM_APP
{
    public class WithdrawViewModel:VIewModelPropertyChanged
    {
          string ConString = "Data Source=(DESCRIPTION =" +
            "(ADDRESS = (PROTOCOL = TCP)(HOST = LAPTOP-TVRMPHSE)(PORT = 1521))" +
            "(CONNECT_DATA =" +
            "(SERVER = DEDICATED)" +
            "(SERVICE_NAME = XE)" +")"+");User Id=mydba1;Password=db123;";//ConnectionString
        public string cust_card_no;
        public Int64 cust_balance;
        public string cust_name;

          public void Withdr()
          {
              try
            {
              using (OracleConnection con = new OracleConnection(ConString))
                {
                    MessageBox.Show(cust_name);
                    con.Open();

                    OracleCommand cmd = new OracleCommand("SELECT acc_bal FROM Customer1 where card_no='" + CardNo1 + "' and card_pin='" + Pin1 + "' ", con);
                   // OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    OracleDataReader odr = cmd.ExecuteReader();
                    if (odr.Read())
                    {
                        cust_balance = Convert.ToInt64(odr.GetValue(0));
                        if(cust_balance<WithdrAmt)
                        MessageBox.Show(cust_name +"\n Withdraw Amount is more than Your Account Balance");
                        Withdr();
                        //Page1 pg=new Page1();
                        //pg.InitializeComponent();
                        MessageBox.Show(cust_name+" Transaction Successfull ");
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
    

          public ICommand CmdWithdr
          {
              get { return new DelegateCommand(Withdr); }
          }

          public string _card_no;

          public string CardNo1
          {
              get { return _card_no; }
              set
              {
                  _card_no = value;
                  OnPropertyChanged("CardNo1");
              }
          }

          public string _pin;
          public string Pin1
          {
              get { return _pin; }
              set
              {
                  _pin = value;
                  OnPropertyChanged("Pin1");
              }
          }

       

          private Int64 _withdrAmt;

          public Int64 WithdrAmt
          {
              get { return _withdrAmt; }
              set { _withdrAmt = value;
              OnPropertyChanged("WithdrAmt");
              }
          }

       
}
}
