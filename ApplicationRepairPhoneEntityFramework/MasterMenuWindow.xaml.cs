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

namespace ApplicationRepairPhoneEntityFramework
{
    /// <summary>
    /// Логика взаимодействия для MasterMenuWindow.xaml
    /// </summary>
    public partial class MasterMenuWindow : Window
    {
        string login;
        public MasterMenuWindow(string login)
        {
            InitializeComponent();
            this.login = login;
        }

        

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ViewMasterOrderWindow viewMasterOrderWindow = new ViewMasterOrderWindow(login);
            viewMasterOrderWindow.ShowDialog();
        }
    }
}
