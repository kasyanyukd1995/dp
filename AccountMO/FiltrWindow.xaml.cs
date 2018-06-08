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
using DomainLib.Concrete;
using DomainLib.Entity;
    

namespace AccountMO
{
    /// <summary>
    /// Логика взаимодействия для FiltrWindow.xaml
    /// </summary>
    public partial class FiltrWindow : Window
    {
        public int N=2;
        InstrumentRepository instrumentRepository = new InstrumentRepository();
        ServiceRepository serviceRepository = new ServiceRepository();
        
        public FiltrWindow()
        {
            InitializeComponent();
            List<string> services = serviceRepository.GetNamesServices().ToList();
            ServiceCB.ItemsSource = services;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Singleton.getInstance().Filtr = N;
            Close();
        }

        private void allradbut_Checked(object sender, RoutedEventArgs e)
        {
            N = 1;
        }

        private void accountradbat_Checked(object sender, RoutedEventArgs e)
        {
            N = 2;
        }

        private void unaccountradbat_Checked(object sender, RoutedEventArgs e)
        {
            N = 3;
        }

        private void ServiceCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedServices = e.Source.ToString();
            List<string> instruments = instrumentRepository.GetNameInstruments(selectedServices, ServiceCB.SelectedIndex + 1).ToList();
            InstrumentCB.ItemsSource = instruments;
        }
    }
}
