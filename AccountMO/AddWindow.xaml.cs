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

namespace AccountMO
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        ServicesRepository servicesRepository = new ServicesRepository();
        InstrumentRepository InstrumentRepository = new InstrumentRepository();
        public AddWindow()
        {
            InitializeComponent();
            List<string> services = servicesRepository.GetNamesServices().ToList();
            Services.ItemsSource = services;

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

    }
}
