using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

//C:\oraclexe\app\oracle\product\11.2.0\server\network\ADMIN\ tnsnames.ora

namespace ATM_APP
{
    public class ViewModel : VIewModelPropertyChanged
    {
        public ObservableCollection<Transactions> transactions{get;set;}
        string ConString = "Data Source=(DESCRIPTION =" +
     "(ADDRESS = (PROTOCOL = TCP)(HOST = LAPTOP-TVRMPHSE)(PORT = 1521))" +
     "(CONNECT_DATA =" +
       "(SERVER = DEDICATED)" +
       "(SERVICE_NAME = XE)" +
     ")" +
   ");User Id=mydba1;Password=db123;";//ConnectionString
        private MenuViewModel childvm;
        public MiniStatement childvm1;
        //public WithdrawViewModel childvmm;
       
       public static string cust_card_no;
        static string cust_pin;
        public Int64 cust_balance;
        static string cust_name;

        public ViewModel()
        {
            //Validate_card();
            childvm1 = new MiniStatement();
            childvm = new MenuViewModel();
            ///childvmm = new WithdrawViewModel();
            //MiniStatement();
           
        }

        public void CheckPin()
        {
            try
            {
                using (OracleConnection con = new OracleConnection(ConString))
                {
                    con.Open();
                    OracleCommand cmd = new OracleCommand("SELECT count(*) FROM customer1 where card_no=" + CardNo + " and card_pin=" + Pin + " ", con);
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    DataTable dt = new DataTable(); //this is creating a virtual table  
                    oda.Fill(dt);
              
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        
                        /* I have made a new page called home page. If the user is successfully authenticated then the form will be moved to the next form */
                        OracleCommand cmd1 = new OracleCommand("SELECT c_name FROM Customer1 where card_no='" + CardNo + "' and card_pin='" + Pin + "' ", con);
                        // OracleDataAdapter oda = new OracleDataAdapter(cmd);
                        OracleDataReader odr = cmd1.ExecuteReader();
                        if (odr.Read())
                        {

                            MessageBox.Show("Welcome " + Convert.ToString(odr.GetValue(0)));
                            cust_card_no = CardNo;
                            cust_pin = Pin;
                            ministatementViewModel mns = new ministatementViewModel();
                            mns.cust_card_no = cust_card_no;
                            cust_name = Convert.ToString(odr.GetValue(0));
                        }
                       // MessageBox.Show("SUCCESS");
                        Menuscreen menuscrn = new Menuscreen();
                        WithdrawMoney withdrmnyscrn = new WithdrawMoney();
                        /* MainWindow mainw =new MainWindow();
                         mainw.Close();
                         mainw.Hide(); */
                        menuscrn.Show();
                        
                        //withdrmnyscrn.Show();
                        menuscrn.DataContext = childvm;
                        /// withdrmnyscrn.DataContext = childvmm;
                        // childvmm.CardNo1 = CardNo;
                        childvm.CardNo = CardNo;
                        childvm.Pin = Pin;
                        /// childvmm.cust_card_no = CardNo;
                        ///childvmm.Pin1 = Pin;
                        childvm.Custlbl = "Hi, " + Convert.ToString(odr.GetValue(0));
                        ///childvmm.cust_name = Convert.ToString(odr.GetValue(0));

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


        public void ChangePIN()
        {
            try
            {
                using (OracleConnection con = new OracleConnection(ConString))
                {
                    con.Open();
                    OracleCommand cmd = new OracleCommand("UPDATE customer1 set card_pin='" + NewPin + "' where card_pin='" + OldPin + "' ", con);
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    int n = cmd.ExecuteNonQuery();
                    if (n > 0)
                    {
                        MessageBox.Show("PIN UPDATED");
                        OldPin = string.Empty;
                        NewPin = string.Empty;
                    }

                    /*
                    DataTable dt = new DataTable(); //this is creating a virtual table  
                    oda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        
                        MessageBox.Show("Updated");
    
                    } */
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

        public void Withdr()
        {
            try
            {
                using (OracleConnection con = new OracleConnection(ConString))
                {
                    //MessageBox.Show(cust_name);
                    con.Open();

                    OracleCommand cmd = new OracleCommand("SELECT acc_bal FROM Customer1 where card_no='" + cust_card_no + "' and card_pin='" + cust_pin + "' ", con);
                    // OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    OracleDataReader odr = cmd.ExecuteReader();
                    if (odr.Read())
                    {
                        cust_balance = Convert.ToInt64(odr.GetValue(0));

                        if (cust_balance < Convert.ToInt64(WithdrAmt))
                        {
                            MessageBox.Show(cust_name+"\n Withdraw Amount is more than Your Account Balance");
                        }
                        else
                        {
                           // con.Open();
                            OracleCommand cmd2 = new OracleCommand("UPDATE customer1 set acc_bal='" + (cust_balance - Convert.ToInt64(WithdrAmt)) + "' where card_no='" + cust_card_no + "' ", con);
                            //OracleDataAdapter oda = new OracleDataAdapter(cmd2);
                            int n = cmd2.ExecuteNonQuery();
                            if (n > 0)
                            {
                                MessageBox.Show(" Transaction Successfull \n PLEASE TAKE YOUR CASH");
                                // WithdrAmt=string.Empty;
                            }
                        }
                        //Page1 pg=new Page1();
                        //pg.InitializeComponent();
                      //  MessageBox.Show(cust_name + " Transaction Successfull ");
                        WithdrAmt = string.Empty;
                       
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


        public string _card_no;

        public string CardNo
        {
            get
            { return _card_no;
            }
            set
            {
                _card_no = value;
                            cust_card_no = value;
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

        /// <summary>
        /// PINCHANGE
        /// </summary>
        public string _oldpin;

        public string OldPin
        {
            get { return _oldpin; }
            set
            {
                _oldpin = value;
                OnPropertyChanged("OldPin");
            }
        }
        
        public string _newpin;

        public string NewPin
        {
            get { return _newpin; }
            set
            {
                _newpin = value;
                OnPropertyChanged("NewPin");
            }
        }
        //WITHDRAW VM
        private string _withdrAmt;

        public string WithdrAmt
        {
            get { return _withdrAmt; }
            set
            {
                _withdrAmt = value;
                OnPropertyChanged("WithdrAmt");
            }
        }

        private string _cardNo;

        public string CardNO_T
        {
            get { return _cardNo; }
            set { _cardNo = value;
            OnPropertyChanged("CardNO_T");
            }
        }

        private string _amount_T;

        public string Amount_T
        {
            get { return _amount_T; }
            set { _amount_T = value;
            OnPropertyChanged("Amount_T");

            }
        }
        

        public ICommand CmdWithdr
        {
            get { return new DelegateCommand(Withdr); }
        }

        



        public ICommand CmdCheckPin
        {
            get { return new DelegateCommand(CheckPin); }
        }

        public ICommand CmdChangePIN
        {
            get { return new DelegateCommand(ChangePIN); }
        }

        public ICommand CmdTransferMoney
        {
            get { return new DelegateCommand(TransferMoney); }
        }

        public ICommand CmdMinistatement
        {
            get { return new DelegateCommand(MiniStatement); }
        }
        public class Transactions
        {

            public int t_id { get; set; }
            public int card_no_t { get; set; }
            public DateTime tdate { get; set; }
            public string desc { get; set; }
            public int amt { get; set; }
            public int bal { get; set; }
        }

        public  void MiniStatement()
        {
            try
            {
                using (OracleConnection con = new OracleConnection(ConString))
                {       
                    //MessageBox.Show(cust_name);
                    con.Open();

                    OracleCommand cmd12 = new OracleCommand("SELECT * FROM transaction1 where card_no='" + cust_card_no + "' order by sysdate desc ", con);
                 //   OracleDataReader odr12 = cmd12.ExecuteReader();
                    OracleDataAdapter oda12 = new OracleDataAdapter(cmd12);
                    DataSet ds = new DataSet();
                    oda12.Fill(ds, "transaction1");

                    if (transactions == null)
                        transactions = new ObservableCollection<Transactions>();
                 
                   foreach (DataRow dr in ds.Tables[0].Rows )
                   {

                       transactions.Add(new Transactions
                        {
                            t_id=Convert.ToInt32(dr[0].ToString()),
                            //t_id = odr12.GetInt64(odr12.GetOrdinal("t_id")),
                            card_no_t = Convert.ToInt32(dr[1].ToString()),
                            tdate = Convert.ToDateTime(dr[2].ToString()),
                            desc =(dr[3].ToString()),
                            amt =Convert.ToInt32(dr[4].ToString()),
                            bal =Convert.ToInt32(dr[5].ToString()),

                        });
                    }
                }
            }

                    //  datagridview1.ItemsSource=dt.DefaultView;
             

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        
        
        }
 
   
        
        public void TransferMoney()
        {
            try
            {
                using (OracleConnection con = new OracleConnection(ConString))
                {
                    //MessageBox.Show(cust_name);
                    con.Open();

                    OracleCommand cmd12 = new OracleCommand("SELECT * FROM Customer1 where card_no='" + CardNO_T + "' ", con);

                    OracleDataReader odr12 = cmd12.ExecuteReader();

                    OracleCommand cmd = new OracleCommand("SELECT acc_bal FROM Customer1 where card_no='" + cust_card_no + "' and card_pin='" + cust_pin + "' ", con);
                    // OracleDataAdapter oda = new OracleDataAdapter(cmd);

                    OracleDataReader odr = cmd.ExecuteReader();

                    if (odr.Read() && odr12.HasRows == true)
                    {
                        cust_balance = Convert.ToInt64(odr.GetValue(0));

                        if (cust_balance < Convert.ToInt64(Amount_T))
                        {
                            MessageBox.Show(cust_name + "\n Withdraw Amount is more than Your Account Balance");
                        }
                        else
                        {
                            // con.Open();
                            OracleCommand cmd2 = new OracleCommand("UPDATE customer1 set acc_bal='" + (cust_balance - Convert.ToInt64(Amount_T)) + "' where card_no='" + cust_card_no + "' ", con);
                            OracleCommand cmd11 = new OracleCommand("UPDATE customer1 set acc_bal= acc_bal+'" + (Convert.ToInt64(Amount_T)) + "' where card_no='" + CardNO_T + "' ", con);
                            // OracleDataAdapter oda = new OracleDataAdapter(cmd2);
                            int nn11 = cmd11.ExecuteNonQuery();
                            int nn = cmd2.ExecuteNonQuery();

                            if (nn > 0 && nn11>0)
                            {
                                MessageBox.Show(" Transaction Successfull \n " + Amount_T + " Has been Transfered to " + CardNO_T);
                                // WithdrAmt=string.Empty;
                            }
                        }


                        //Page1 pg=new Page1();
                        //pg.InitializeComponent();
                        //  MessageBox.Show(cust_name + " Transaction Successfull ");
                        Amount_T = string.Empty;
                        CardNO_T = string.Empty;

                    }

                    else
                    {
                        MessageBox.Show("Invalid Card No");
                        CardNO_T = string.Empty;
                    }   

                    //  datagridview1.ItemsSource=dt.DefaultView;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }




    }
}





  


