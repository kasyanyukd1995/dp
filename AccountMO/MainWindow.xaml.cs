using System;
using System.Collections.Generic;
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
using DomainLib.Concrete;
using System.Data.Entity;
using DomainLib.Entity;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.Sql;

namespace AccountMO
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {

        //AccountMain acc = new AccountMain();
        //List<AccountMain> accounts = new List<AccountMain>();
        //модель для заполнения таблицы

        public SqlConnection connect;
        public SqlCommand sqlCommand;
        public SqlDataAdapter dataAdapter;
        public DataSet dataSet;
        public int IdAccount;

        public int IndexColumn;
        Context context = new Context();
        AccountRepository accountRepository = new AccountRepository();


        public class ForViewonMain
        {

            public int Id { get; set; }
            public string ServiceName { get; set; }
            public string InstrumentName { get; set; }
            public DateTime DateOn { get; set; }
            public DateTime DateOf { get; set; }
            public string Serial { get; set; }
            public string Inventory { get; set; }
            public string Condition { get; set; }
            public string DecisionOprt { get; set; }
            public string AddirInf { get; set; }

        }
        public ForViewonMain ConvertAccountToForVieWonMain(Account account)
        {
            return new ForViewonMain()
            {
                Id = account.Id,
                ServiceName = account.Service.NameService,
                InstrumentName = account.Instrument.NameInstrument,
                DateOn = account.AccountingDate,
                DateOf = account.Date_ofderegistration,
                AddirInf = account.AddirionalInf,
                Condition = account.Condition,
                DecisionOprt = account.DecisionOprtn,
                Inventory = account.InventoryNumber,
                Serial = account.SerialNumber
            };
        }

        //--------------------------------------------------------


        AccountRepository acountRepository = new AccountRepository();
        ServiceRepository servicesRepository = new ServiceRepository();

        public MainWindow()
        {

            InitializeComponent();
            Context contextv = new Context();
            connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DefaultConnectionT;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");


            //загрузка в datagrid
        }

        private void AddPage(object sender, RoutedEventArgs e)
        {
            AddWindow addWndow = new AddWindow();
            addWndow.Show();
            addWndow.ButtonAdd.Content = "Добавить";

        }
        private void AddPage2(object sender, RoutedEventArgs e)
        {
            AddWindow addWndow = new AddWindow();
            addWndow.Show();
            addWndow.ButtonAdd.Content = "Изменить";

            var a = dataGridAccount.SelectedCells;


        }
        private void ClickFiltr(object sender, RoutedEventArgs e)
        {
            FiltrWindow filtrWindow = new FiltrWindow();
            filtrWindow.Show();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            connect.Open();
            dataAdapter = new SqlDataAdapter("Select * from ViewMain", connect);

            dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridAccount.ItemsSource = dataSet.Tables[0].DefaultView;

        }

        private void Update_button_Click_1(object sender, RoutedEventArgs e)
        {
            dataAdapter.Update(dataSet.Tables[0]);
            switch (Singleton.getInstance().Filtr)
            {
                case 1:
                    {
                        dataAdapter = new SqlDataAdapter("Select * from ViewAll", connect); break;
                    }
                case 2:
                    {
                        dataAdapter = new SqlDataAdapter("Select * from ViewMain", connect); break;
                    }
                case 3:
                    {
                        dataAdapter = new SqlDataAdapter("Select * from ViewNoAcc", connect); break;
                    }
                default:
                    {
                        dataAdapter = new SqlDataAdapter("Select * from ViewMain", connect); break;
                    }
            }
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridAccount.ItemsSource = dataSet.Tables[0].DefaultView;

        }

        private void dataGridAccount_CurrentCellChanged(object sender, EventArgs e)
        {
            //var a = dataGridAccount.SelectedCells;


        }

        private void dataGridAccount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = dataGridAccount.SelectedValue as DataRowView;
           /* var a = rowView[0];
            if (a!=null)
            IdAccount=Convert.ToInt32(rowView[0].ToString());*/
        }

        private void Delete_button_Click(object sender, RoutedEventArgs e)
        {
            dataAdapter = new SqlDataAdapter("delete from Accounts where Id =" + this.IdAccount.ToString(), connect);
        }
    }
 
}
