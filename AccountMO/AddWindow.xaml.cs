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
        AccountsRepository accountsRepository = new AccountsRepository();
        ServicesRepository servicesRepository = new ServicesRepository();
        InstrumentRepository InstrumentRepository = new InstrumentRepository();
        Context context = new Context();

        



        public AddWindow()
        {

            
            InitializeComponent();
            List<string> services = servicesRepository.GetNamesServices().ToList();
            Services.ItemsSource = services;
            //загрузка в datagrid 
            
            context.AssServicemans.Load();
            assServicemanGrid.ItemsSource = context.AssServicemans.Local.ToBindingList();
            //end
        }

        


        private void Addservicemen(object sender, RoutedEventArgs e)
        {
            AddServicemen addServicemen = new AddServicemen();
            addServicemen.Show();
        }

        private void Services_Selected(object sender, RoutedEventArgs e)
        {
            var selectedServices = e.Source.ToString();
            List<string> instruments = InstrumentRepository.GetNameInstruments(selectedServices).ToList();
            Instrument.ItemsSource = instruments;
        }


        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {





            if (ButtonAdd.Content.ToString() == "Добавить")
            {

                //account.Service.Id=
                //account.Instrument.NameInstrument = Instrument.ToString(); //не так
                instruments.Description = Descript.ToString();
                instruments.YearIssue = yearissue.ToString();
                account.AccountingDate = DateOn.DisplayDate;
                account.Date_ofderegistration = DateOff.DisplayDate;
                account.DecisionOprtn = decisionOprtn.Text;
                account.SerialNumber = serialN.Text;
                account.InventoryNumber = inventoryN.Text;
                account.Condition = condition.Text;
                account.AddirionalInf = AddInf.Text;

                
            }
        }

    }
}
