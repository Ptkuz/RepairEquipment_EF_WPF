using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace ApplicationRepairPhoneEntityFramework
{
    /// <summary>
    /// Логика взаимодействия для ViewMasterOrderWindow.xaml
    /// </summary>
    public partial class ViewMasterOrderWindow : Window
    {
        ArrayList RegisteredOrder = new ArrayList();
        ArrayList WorkingOrder = new ArrayList();
        ArrayList CompletedOrder = new ArrayList();
        public Guid ID_Order { get; set; }
        public string Email { get; private set; }
        public string Fio { get; private set; }

        string login;
        public ViewMasterOrderWindow(string login)
        {
            InitializeComponent();
            this.login = login;
            GetData();
            async void GetData()
            {
                RegisteredOrder = await DataOperations.GetStatusOrdersViewMasterWindow(1, login);
                WorkingOrder = await DataOperations.GetStatusOrdersViewMasterWindow(2, login);
                CompletedOrder = await DataOperations.GetStatusOrdersViewMasterWindow(3, login);
                DataGridOrders.ItemsSource = RegisteredOrder;
                DataGridWorkingOrder.ItemsSource = WorkingOrder;
                DataGridCompleteOrder.ItemsSource = CompletedOrder;
            }

        }

        private void btn_change_status_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void txbx_search_orders_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string search = txbx_search_orders.Text;
            DataGridOrders.ItemsSource = await DataOperations.SearchOrdersMasterWindow(1, login, search);
        }

        private async void txbx_search_workingOrder_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string search = txbx_search_workingOrder.Text;
            DataGridWorkingOrder.ItemsSource = await DataOperations.SearchOrdersMasterWindow(2, login, search);
        }

        private async void txbx_search_completeOrder_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string search = txbx_search_completeOrder.Text;
            DataGridCompleteOrder.ItemsSource = await DataOperations.SearchOrdersMasterWindow(3, login, search);
        }

        private async void btn_change_status_Click_1(object sender, RoutedEventArgs e)
        {
            await DataOperations.UpdateStatus(ID_Order, 2);
            object item = DataGridOrders.SelectedItem;
            Email = (DataGridOrders.SelectedCells[5].Column.GetCellContent(item) as TextBlock)!.Text.Trim();
            Fio = (DataGridOrders.SelectedCells[3].Column.GetCellContent(item) as TextBlock)!.Text.Trim();
            DataGridOrders.ItemsSource = await DataOperations.GetStatusOrdersViewMasterWindow(1, login);
            DataGridWorkingOrder.ItemsSource = await DataOperations.GetStatusOrdersViewMasterWindow(2, login);

            MessageBox.Show("Заказ переведен в статус исполнения", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Information);
            if (Email != String.Empty)
                if(await SendEmail.SendEmailAsync(Email, "Пиьсмо от Сервсисного центра", SendEmail.ChangeStatusOrder(Fio, ID_Order.ToString(), "Заказ выполняется")))
                    MessageBox.Show("Письмо клиенту успешно отправлено!", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("При отправке письма произошла ошибка. Проверьте интернет подключение!", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private async void btn_change_status_2_Click(object sender, RoutedEventArgs e)
        {
            await DataOperations.UpdateStatus(ID_Order, 3);
            object item = DataGridWorkingOrder.SelectedItem;
            Email = (DataGridWorkingOrder.SelectedCells[5].Column.GetCellContent(item) as TextBlock)!.Text.Trim();
            Fio = (DataGridWorkingOrder.SelectedCells[3].Column.GetCellContent(item) as TextBlock)!.Text.Trim();
            DataGridWorkingOrder.ItemsSource = await DataOperations.GetStatusOrdersViewMasterWindow(2, login);
            DataGridCompleteOrder.ItemsSource = await DataOperations.GetStatusOrdersViewMasterWindow(3, login);

            MessageBox.Show("Заказ выполнен", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Information);
            if (Email != String.Empty)
                if(await SendEmail.SendEmailAsync(Email, "Пиьсмо от Сервсисного центра", SendEmail.ChangeStatusOrder(Fio, ID_Order.ToString(), "Заказ выполнен")))
                    MessageBox.Show("Письмо клиенту успешно отправлено!", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("При отправке письма произошла ошибка. Проверьте интернет подключение!", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void DataGridWorkingOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object itemOrder = DataGridWorkingOrder.SelectedItem;
            if (itemOrder != null)
            {
                ID_Order = Guid.Parse((DataGridWorkingOrder.SelectedCells[1].Column.GetCellContent(itemOrder) as TextBlock)!.Text);
                btn_change_status_2.IsEnabled = true;

            }
            else
            {
                btn_change_status_2.IsEnabled = false;


            }
        }
    }
}
