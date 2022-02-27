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
        string fio;
        string position;
        public MasterMenuWindow(string login_, string fio_, string position_)
        {
            InitializeComponent();
            login = login_;
            fio = fio_;
            position = position_;
            lb_fio.Content = fio;
            lb_position.Content = position;
        }

        

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ViewMasterOrderWindow viewMasterOrderWindow = new ViewMasterOrderWindow(login);
            viewMasterOrderWindow.ShowDialog();
        }
    }
}
