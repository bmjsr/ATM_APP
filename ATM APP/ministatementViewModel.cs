using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

 namespace ATM_APP
{
   public class ministatementViewModel:VIewModelPropertyChanged
    {
       public ObservableCollection<Transactions> transactions { get; set; }
       string ConString = "Data Source=(DESCRIPTION =" +
     "(ADDRESS = (PROTOCOL = TCP)(HOST = LAPTOP-TVRMPHSE)(PORT = 1521))" +
     "(CONNECT_DATA =" +
       "(SERVER = DEDICATED)" +
       "(SERVICE_NAME = XE)" +
     ")" +
   ");User Id=mydba1;Password=db123;";
       public string cust_card_no;
       
       public class Transactions
       {

           public int t_id { get; set; }
           public int card_no_t { get; set; }
           public DateTime tdate { get; set; }
           public string desc { get; set; }
           public int amt { get; set; }
           public int bal { get; set; }
       }
       public ministatementViewModel()
       {
           MiniStatement();
         
       }

       
       public void MiniStatement()
       {
           try
           {
               using (OracleConnection con = new OracleConnection(ConString))
               {
                   //MessageBox.Show(cust_name);
                   con.Open();

                   OracleCommand cmd12 = new OracleCommand("SELECT * FROM transaction1 where card_no='" +ViewModel.cust_card_no + "' order by t_id desc,t_date desc ", con);
                   //   OracleDataReader odr12 = cmd12.ExecuteReader();
                   OracleDataAdapter oda12 = new OracleDataAdapter(cmd12);
                   DataSet ds = new DataSet();
                   oda12.Fill(ds, "transaction1");

                   if (transactions == null)
                       transactions = new ObservableCollection<Transactions>();

                   foreach (DataRow dr in ds.Tables[0].Rows)
                   {

                       transactions.Add(new Transactions
                       {
                           t_id = Convert.ToInt32(dr[0].ToString()),
                           //t_id = odr12.GetInt64(odr12.GetOrdinal("t_id")),
                           card_no_t = Convert.ToInt32(dr[1].ToString()),
                           tdate = Convert.ToDateTime(dr[2].ToString()),
                           desc = (dr[3].ToString()),
                           amt = Convert.ToInt32(dr[4].ToString()),
                           bal = Convert.ToInt32(dr[5].ToString()),

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

       
    }
   
}
