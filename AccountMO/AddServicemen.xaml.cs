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

namespace AccountMO
{
    /// <summary>
    /// Логика взаимодействия для AddServicemen.xaml
    /// </summary>
    public partial class AddServicemen : Window
    {
        SrvicemnRepository srvicemnRepository = new SrvicemnRepository();
        public int temp;
        public AddServicemen()
        {
            InitializeComponent();
            List<string> servicmens = srvicemnRepository.GetNamesServicemen().ToList();
            comboBoxServicemen.ItemsSource = servicmens;
            
            
        }
        
        private void SaveButton_Click_1(object sender, RoutedEventArgs e)
        {

            temp = srvicemnRepository.GetServicemen(comboBoxServicemen.Text);
            Singleton.getInstance().IdServicemen = temp;
            Close();
        }
    }
}
