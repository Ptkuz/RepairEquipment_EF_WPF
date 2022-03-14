using System;
using System.Collections;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Excel = Microsoft.Office.Interop.Excel;
using Syncfusion.UI.Xaml.Grid.Converter;
using Syncfusion.XlsIO;
using Microsoft.Office.Interop.Excel;

namespace ApplicationRepairPhoneEntityFramework
{
    /// <summary>
    /// Логика взаимодействия для ViewAllOrdersWindow.xaml
    /// </summary>
    public partial class ViewAllOrdersWindow : System.Windows.Window
    {
        ArrayList allOrders = new ArrayList();
        ArrayList allPerformance = new ArrayList();
        ArrayList allStatus = new ArrayList();

        public string ID_Order { get; set; }
        public string Status { get; set; }
        public int StatusValue { get; set; }
        public Guid ID_OrderValue { get; set; }
        public string Email { get; private set; }
        public string Fio { get; private set; }

        public ViewAllOrdersWindow()
        {
            InitializeComponent();
            
            btn_Excel.IsEnabled = false;
            GetOrders();
            async void GetOrders()
            {
                allOrders = await DataOperations.GetAllOrdersViewAllOrdersWindow();
                allPerformance = await DataOperations.GetAllPerformanceViewAllOrdersWindow();
                allStatus = await DataOperations.GetAllStatus();
                DataGridOrders.ItemsSource = allOrders;
                DataGridPerformance.ItemsSource = allPerformance;
                cmbx_status.ItemsSource = allStatus;



            }

        }

        private void DataGridOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            object itemOrder = DataGridOrders.SelectedItem;
            if (itemOrder != null)
            {
                ID_Order = (DataGridOrders.SelectedCells[1].Column.GetCellContent(itemOrder) as TextBlock)!.Text;
                Status = (DataGridOrders.SelectedCells[2].Column.GetCellContent(itemOrder) as TextBlock)!.Text;
                cmbx_status.Text = Status;
                btn_change_status.IsEnabled = true;

            }
            else
            {
                btn_change_status.IsEnabled = false;


            }

            for (int i = 0; i < DataGridPerformance.Items.Count; i++)
            {
                DataGridPerformance.ScrollIntoView(DataGridPerformance.Items[i]);
                DataGridRow row = (DataGridRow)DataGridPerformance.ItemContainerGenerator.ContainerFromIndex(i);
                TextBlock cellContent = DataGridPerformance.Columns[1].GetCellContent(row) as TextBlock;
                if (cellContent != null && cellContent.Text.ToLower().Equals(ID_Order.ToLower()))
                {
                    object item = DataGridPerformance.Items[i];
                    DataGridPerformance.SelectedItem = item;
                    DataGridPerformance.ScrollIntoView(item);
                    row.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                    break;
                }
            }
        }

        private async void txbx_search_orders_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string search = txbx_search_orders.Text;
            DataGridOrders.ItemsSource = await DataOperations.SearchOrdersViewAllOrdersWindow(search);
        }

        private void DataGridPerformance_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridPerformance != null)
                btn_Excel.IsEnabled = true;
            object itemPerf = DataGridPerformance.SelectedItem;
            if (itemPerf != null)
                ID_Order = (DataGridPerformance.SelectedCells[1].Column.GetCellContent(itemPerf) as TextBlock)!.Text;

            for (int i = 0; i < DataGridOrders.Items.Count; i++)
            {
                DataGridOrders.ScrollIntoView(DataGridOrders.Items[i]);
                DataGridRow row = (DataGridRow)DataGridOrders.ItemContainerGenerator.ContainerFromIndex(i);
                TextBlock cellContent = DataGridOrders.Columns[1].GetCellContent(row) as TextBlock;
                if (cellContent != null && cellContent.Text.ToLower().Equals(ID_Order.ToLower()))
                {
                    object item = DataGridOrders.Items[i];
                    DataGridOrders.SelectedItem = item;
                    DataGridOrders.ScrollIntoView(item);
                    row.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                    break;
                }
            }


        }

        private async void txbx_search_performance_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string search = txbx_search_performance.Text;
            DataGridPerformance.ItemsSource = await DataOperations.SearchPerformanceViewAllOrdersWindow(search);
        }

        private async void btn_change_status_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (Status == "Заказ выполняется" && (cmbx_status.Text == "Заказ зарегестрирован"))
                {
                    throw new Exception("Новый статус заказа не может быть ниже нынешнего");
                }
                else if ((Status == "Заказ отменен"))
                {

                    throw new Exception("Нельзя менять статус отмененного заказа");
                }

                else if ((Status == "Заказ закрыт" || Status == "Заказ выполняется" || Status == "Заказ выполнен") && cmbx_status.Text == "Заказ отменен")
                {

                    throw new Exception("Нельзя отменить заказ на данном этапе выполнения");
                }
                else if (Status == "Заказ выполнен" && (cmbx_status.Text == "Заказ зарегестрирован" || cmbx_status.Text == "Заказ выполняется"))
                {
                    throw new Exception("Новый статус заказа не может быть ниже нынешнего");
                }
                else if (Status == "Заказ закрыт" && (cmbx_status.Text == "Заказ зарегестрирован" || cmbx_status.Text == "Заказ выполняется" || cmbx_status.Text == "Заказ выполнен"))
                {
                    throw new Exception("Новый статус заказа не может быть ниже нынешнего");
                }
                else if (Status == cmbx_status.Text)
                {
                    MessageBox.Show("Статус заказа не изменен", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;

                }



                ID_OrderValue = Guid.Parse(ID_Order);
                StatusValue = Int32.Parse(cmbx_status.SelectedValue.ToString());
                await DataOperations.UpdateStatus(ID_OrderValue, StatusValue);
                object item = DataGridOrders.SelectedItem;
                Email = (DataGridOrders.SelectedCells[6].Column.GetCellContent(item) as TextBlock)!.Text.Trim();
                Fio = (DataGridOrders.SelectedCells[3].Column.GetCellContent(item) as TextBlock)!.Text.Trim();
                DataGridOrders.ItemsSource = await DataOperations.GetAllOrdersViewAllOrdersWindow();

                MessageBox.Show("Статус заказа изменен", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Information);
                if (Email != String.Empty)
                    if (await SendEmail.SendEmailAsync(Email, "Пиьсмо от Сервсисного центра", SendEmail.ChangeStatusOrder(Fio, ID_Order.ToString(), cmbx_status.Text)))
                        MessageBox.Show("Письмо клиенту успешно отправлено!", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show("При отправке письма произошла ошибка. Проверьте интернет подключение!", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true; 
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            for (int j = 0; j < DataGridPerformance.Columns.Count; j++) 
            {
                Excel.Range myRange = (Excel.Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true; 
                sheet1.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = DataGridPerformance.Columns[j].Header;
            }
            for (int i = 0; i < DataGridPerformance.Columns.Count; i++)
            { //www.yazilimkodlama.com
                for (int j = 0; j < DataGridPerformance.Items.Count; j++)
                {
                    TextBlock b = DataGridPerformance.Columns[i].GetCellContent(DataGridPerformance.Items[j]) as TextBlock;
                    Excel.Range myRange = (Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }
        }

        private async void datepicker1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridPerformance.ItemsSource = await DataOperations.GetPerformancePeriodDateViewAllOrdersWindow(datepicker1.SelectedDate, datepicker2.SelectedDate);

        }

        private async void datepicker2_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridPerformance.ItemsSource = await DataOperations.GetPerformancePeriodDateViewAllOrdersWindow(datepicker1.SelectedDate, datepicker2.SelectedDate);
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            datepicker1.SelectedDate = null;
            datepicker2.SelectedDate = null;
            DataGridPerformance.ItemsSource = await DataOperations.GetAllPerformanceViewAllOrdersWindow();
        }

        
    }
}
