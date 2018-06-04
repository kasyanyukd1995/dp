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
        public class ForVieWonMain
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
        //--------------------------------------------------------


        Context contextv;

        public MainWindow()
        {
            InitializeComponent();
            Context contextv;
            contextv = new Context();
            contextv.Accounts.Load();
            //загрузка в datagrid
            Account account = new Account();
        

            dataGridAccount.ItemsSource = contextv.Accounts.Local.ToBindingList();
            this.Closing += MainWindow_Closing;

            /*List<ForVieWonMain> forVies = new List<ForVieWonMain>
            {
                new ForVieWonMain { Id = account.Id, ServiceName = account.Service.NameService, InstrumentName = account.Instrument.NameInstrument, DateOn = account.AccountingDate, DateOf = account.Date_ofderegistration, AddirInf = account.AddirionalInf, Condition = account.Condition, DecisionOprt = account.DecisionOprtn, Inventory = account.InventoryNumber, Serial = account.SerialNumber }

            };
            dataGridAccount.ItemsSource=forVies;
            */


        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            contextv.Dispose(); 
        }

             

        private void AddPage (object sender, RoutedEventArgs e)
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
            


        }
        private void ClickFiltr(object sender, RoutedEventArgs e)
        {
            FiltrWindow filtrWindow = new FiltrWindow();
            filtrWindow.Show();
        }
        
    }
 
}
