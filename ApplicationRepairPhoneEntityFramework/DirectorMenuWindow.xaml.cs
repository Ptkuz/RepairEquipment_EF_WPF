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
    /// Логика взаимодействия для DirectorMenuWindow.xaml
    /// </summary>
    public partial class DirectorMenuWindow : Window
    {
        string login;
        string fio;
        string position;
        public DirectorMenuWindow(string login, string fio, string position)
        {
            InitializeComponent();
            this.login = login;
            this.fio = fio;
            lb_fio.Content = fio;
            lb_position.Content = position;
        }

        private void btn_clients_Click(object sender, RoutedEventArgs e)
        {
            DirectorViewClientsWindow directorViewClientsWindow = new DirectorViewClientsWindow();
            directorViewClientsWindow.ShowDialog();
        }

        private void btn_devices_Click(object sender, RoutedEventArgs e)
        {
            ViewDevicesWindow viewDevicesWindow = new ViewDevicesWindow();
            viewDevicesWindow.ShowDialog();
        }

        private void btn_employees_Click(object sender, RoutedEventArgs e)
        {
            ViewEmployeeWindow viewEmployeeWindow = new ViewEmployeeWindow();
            viewEmployeeWindow.ShowDialog();
        }

        private void btn_details_Click(object sender, RoutedEventArgs e)
        {
            ViewDetailsWindow viewDetailsWindow = new ViewDetailsWindow();
            viewDetailsWindow.ShowDialog();
        }

        private void btn_orders_Click(object sender, RoutedEventArgs e)
        {
            ViewAllOrdersWindow viewAllOrdersWindow = new ViewAllOrdersWindow();
            viewAllOrdersWindow.ShowDialog();
        }

        private void btn_AddOrders_Click(object sender, RoutedEventArgs e)
        {
            CreateOrderWindow createOrderWindow = new CreateOrderWindow();
            bool? result = createOrderWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {
                MessageBox.Show("Заказ создан", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btn_AddPerforms_Click(object sender, RoutedEventArgs e)
        {
            PerformanceWindow performanceWindow = new PerformanceWindow();
            bool? result = performanceWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {
                MessageBox.Show("Заказ закрыт", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //this.DialogResult = true;
        }
    }
}
