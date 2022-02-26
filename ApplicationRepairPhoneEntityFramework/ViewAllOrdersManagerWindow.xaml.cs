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
using System.Collections;

namespace ApplicationRepairPhoneEntityFramework
{
    /// <summary>
    /// Логика взаимодействия для ViewAllOrdersManagerWindow.xaml
    /// </summary>
    public partial class ViewAllOrdersManagerWindow : Window
    {
        ArrayList RegisteredOrder = new ArrayList();
        ArrayList WorkingOrder = new ArrayList();
        ArrayList CompletedOrder = new ArrayList();
        public Guid ID_Order { get; set; }
        public ViewAllOrdersManagerWindow()
        {
            InitializeComponent();
            GetData();
            async void GetData()
            {
                RegisteredOrder = await DataOperations.GetStatusOrdersViewMasterWindow(1);
                WorkingOrder = await DataOperations.GetStatusOrdersViewMasterWindow(2);
                CompletedOrder = await DataOperations.GetStatusOrdersViewMasterWindow(3);
                DataGridOrders.ItemsSource = RegisteredOrder;
                DataGridWorkingOrder.ItemsSource = WorkingOrder;
                DataGridCompleteOrder.ItemsSource = CompletedOrder;
            }
        }

        private async void txbx_search_orders_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string search = txbx_search_orders.Text;
            DataGridOrders.ItemsSource = await DataOperations.SearchOrdersMasterWindow(1, search);
        }

        private async void btn_change_status_Click(object sender, RoutedEventArgs e)
        {
            await DataOperations.UpdateStatus(ID_Order, 5);
            DataGridOrders.ItemsSource = await DataOperations.GetStatusOrdersViewMasterWindow(1);
            DataGridWorkingOrder.ItemsSource = await DataOperations.GetStatusOrdersViewMasterWindow(2);
            MessageBox.Show("Заказ отменен", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void DataGridOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object itemOrder = DataGridOrders.SelectedItem;
            if (itemOrder != null)
            {
                ID_Order = Guid.Parse((DataGridOrders.SelectedCells[1].Column.GetCellContent(itemOrder) as TextBlock)!.Text);
                btn_change_status.IsEnabled = true;

            }
            else
            {
                btn_change_status.IsEnabled = false;


            }
        }

        private async void txbx_search_workingOrder_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string search = txbx_search_workingOrder.Text;
            DataGridWorkingOrder.ItemsSource = await DataOperations.SearchOrdersMasterWindow(2, search);
        }

        private async void txbx_search_completeOrder_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string search = txbx_search_completeOrder.Text;
            DataGridCompleteOrder.ItemsSource = await DataOperations.SearchOrdersMasterWindow(3, search);
        }
    }
}
