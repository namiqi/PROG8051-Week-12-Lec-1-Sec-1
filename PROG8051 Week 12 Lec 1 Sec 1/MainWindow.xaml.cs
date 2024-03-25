using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROG8051_Week_12_Lec_1_Sec_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection(@"Data Source=NAMIQ;Initial Catalog=newDB;Integrated Security=True;TrustServerCertificate=true");

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from Sec1DB.dbo.Sec1_Table1", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;

        }
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            string name = fname.Text;
            string lastname = lname.Text;
            string userage = age.Text;
            string usergender = gender.Text;
            string userprogram = program.Text;

            string command = $"INSERT INTO Sec1DB.dbo.Sec1_Table1(STID, FirstName, LastName, Age, Gender, Program) VALUES ('{RandomString(6)}', '{name}', '{lastname}', {userage}, '{usergender}', '{userprogram}')";

            SqlCommand cmd = new SqlCommand(command, con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Sec1DB.dbo.Sec1_Table1 SET FirstName = 'Namiq' Where STID ='IS123456' ", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from Sec1DB.dbo.Sec1_Table1 Where FirstName = 'Namiq'  ", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;
        }
    }
}
