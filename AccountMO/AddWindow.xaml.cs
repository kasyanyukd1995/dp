using DomainLib.Concrete;
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
using System.Windows.Shapes;
using System.Data.Entity;
using DomainLib.Entity;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace AccountMO
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>


    public partial class AddWindow : Window
    {


        Account account = new Account();
        Service service = new Service();
        Instrument instruments = new Instrument();
        AccountRepository accountsRepository = new AccountRepository();
        ServiceRepository servicesRepository = new ServiceRepository();
        InstrumentRepository InstrumentRepository = new InstrumentRepository();
        SrvicemnRepository srvicemnRepository = new SrvicemnRepository();
        AddServicemen addServicemen = new AddServicemen();
        Context context = new Context();
        SqlConnection con;
        public int TEMP = 0;
        MainWindow mainWindow = new MainWindow();

        SqlDataAdapter dataAd = new SqlDataAdapter();
        DataSet DSet;
        



        public AddWindow()
        {


            InitializeComponent();
            List<string> services = servicesRepository.GetNamesServices().ToList();
            Services.ItemsSource = services;

            con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DefaultConnectionT;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();


            //загрузка в datagrid 

            // context.AssServicemen.Load();
            //assServicemanGrid.ItemsSource = context.AssServicemens.Local.ToBindingList();
            //end
        }




        private void Addservicemen(object sender, RoutedEventArgs e)
        {
            AddServicemen addServiceman = new AddServicemen();
            addServiceman.Show();
        }

        private void Services_Selected(object sender, RoutedEventArgs e)
        {
            var selectedServices = e.Source.ToString();
            List<string> instruments = InstrumentRepository.GetNameInstruments(selectedServices, Services.SelectedIndex + 1).ToList();
            Instrument.ItemsSource = instruments;


        }

        private void Instrument_Selection(object sender, RoutedEventArgs e)
        {
            var selectedInstrument = (string)Instrument.SelectedItem;
            yearissue.Text = InstrumentRepository.GetYearissue(selectedInstrument);
            Descript.Text = InstrumentRepository.GetDescript(selectedInstrument);
            characteristic.Text = InstrumentRepository.GetCharacteristic(selectedInstrument);
        }


        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {

            if (ButtonAdd.Content.ToString() == "Добавить" && DateOff.Visibility==Visibility.Hidden)
            {

                //dataAd.Update(DSet.Tables[0]);
                string Query = String.Format("INSERT INTO Accounts (Service_Id, Instrument_Id, Srvicemn_Id, " +
                    "AccountingDate, DecisionOprtn, " +
                    "SerialNumber,InventoryNumber,Condition,AddirionalInf) " +
                    "values ({0},{1},{2},'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}')",
                    this.servicesRepository.GetServiceId(Services.Text),
                    this.InstrumentRepository.GetInstrumentId(Instrument.Text),
                    Singleton.getInstance().IdServicemen, DateOn.DisplayDate,
                    decisionOprtn.Text, serialN.Text, inventoryN.Text, condition.Text,
                     AddInf.Text);



                dataAd = new SqlDataAdapter(Query, con);
                DSet = new DataSet();
                dataAd.Fill(DSet);
              
                /* instruments.Description = Descript.ToString();
                 instruments.YearIssue = yearissue.ToString(); 
                 account.AccountingDate = DateOn.DisplayDate;
                 account.Date_ofderegistration = DateOff.DisplayDate;
                 account.DecisionOprtn = decisionOprtn.Text;
                 account.SerialNumber = serialN.Text;
                 account.InventoryNumber = inventoryN.Text;
                 account.Condition = condition.Text;
                 account.AddirionalInf = AddInf.Text;*/

            }
            else
            {
                string Query = String.Format("INSERT INTO Accounts (Service_Id, Instrument_Id, Srvicemn_Id, " +
                     "AccountingDate, Date_ofderegistration, DecisionOprtn, " +
                     "SerialNumber,InventoryNumber,Condition,AddirionalInf) " +
                     "values ({0},{1},{2},'{3}','{4}',N'{5}',N'{6}',N'{7}',N'{8}',N'{9}')",
                     this.servicesRepository.GetServiceId(Services.Text),
                     this.InstrumentRepository.GetInstrumentId(Instrument.Text),
                     Singleton.getInstance().IdServicemen, DateOn.DisplayDate, DateOff.DisplayDate,
                     decisionOprtn.Text, serialN.Text, inventoryN.Text, condition.Text,
                      AddInf.Text);
                dataAd = new SqlDataAdapter(Query, con);
                DSet = new DataSet();
                dataAd.Fill(DSet);
                // var a=mainWindow.dataGridAccount.Cells
            }
            //accountsRepository.SaveAccount(account);
            Close();
        }

        private void Instrument_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void inventoryN_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {
            DateOff.Visibility = Visibility.Visible;

        }
    }
}
