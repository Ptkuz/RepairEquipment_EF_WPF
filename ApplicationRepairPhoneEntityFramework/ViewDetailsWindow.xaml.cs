using System;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ApplicationRepairPhoneEntityFramework
{
    /// <summary>
    /// Логика взаимодействия для ViewDetailsWindow.xaml
    /// </summary>
    public partial class ViewDetailsWindow : Window
    {
        ArrayList allDetails = new ArrayList();

        bool flagName = false;
        bool flagUnitPrice = false;
        bool flagQuantity = false;

        public bool FlagName
        {
            get { return flagName; }
            set
            {
                flagName = value;
                if (flagName && flagUnitPrice && flagQuantity)
                    btn_Update_Detail.IsEnabled = true;
                else
                    btn_Update_Detail.IsEnabled = false;
            }

        }

        public bool FlagUnitPrice
        {
            get { return flagUnitPrice; }
            set
            {
                flagUnitPrice = value;
                if (flagName && flagUnitPrice && flagQuantity)
                    btn_Update_Detail.IsEnabled = true;
                else
                    btn_Update_Detail.IsEnabled = false;

            }

        }

        public bool FlagQuantity
        {
            get { return flagQuantity; }
            set
            {
                flagQuantity = value;
                if (flagName && flagUnitPrice && flagQuantity)
                    btn_Update_Detail.IsEnabled = true;
                else
                    btn_Update_Detail.IsEnabled = false;

            }

        }

        public Guid ID_Detail { get; set; }
        public string NameDetail { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal FullPrice { get; set; }

        public ViewDetailsWindow()
        {
            InitializeComponent();
            GetAllDetails();
            async void GetAllDetails()
            {
                allDetails = await DataOperations.GetAllDetailsView();
                dataGridDetails.ItemsSource = allDetails;

            }
        }

        private async void btn_Add_Detail_Click(object sender, RoutedEventArgs e)
        {
            AddDetailsWindow addDetailsWindow = new AddDetailsWindow();
            bool? result = addDetailsWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {
                dataGridDetails.ItemsSource = await DataOperations.GetAllDetails();
                MessageBox.Show("Новая деталь добавлена", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private async void txbx_search_detail_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string search = txbx_search_detail.Text;
            dataGridDetails.ItemsSource = await DataOperations.SearchDetails(search);
        }

        private void dataGridDetails_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                object item = dataGridDetails.SelectedItem;
                if (item != null)
                {
                    string ID_Detail = (dataGridDetails.SelectedCells[0].Column.GetCellContent(item) as TextBlock)!.Text;
                    string nameDetail = (dataGridDetails.SelectedCells[1].Column.GetCellContent(item) as TextBlock)!.Text;
                    string unit_Price = (dataGridDetails.SelectedCells[2].Column.GetCellContent(item) as TextBlock)!.Text;
                    string quantity = (dataGridDetails.SelectedCells[3].Column.GetCellContent(item) as TextBlock)!.Text;
                    string fullPrice = (dataGridDetails.SelectedCells[4].Column.GetCellContent(item) as TextBlock)!.Text;

                    decimal d = decimal.Parse(unit_Price, CultureInfo.InvariantCulture);
                    decimal df = decimal.Parse(fullPrice, CultureInfo.InvariantCulture);



                    txbx_Id_Detail.Text = ID_Detail;
                    txbx_Name.Text = nameDetail;
                    txbx_UnitPrice.Text = d.ToString();
                    txbx_quantity.Text = quantity;
                    txbx_FullPrice.Text = df.ToString();

                }
                else
                {
                    txbx_Id_Detail.Text = String.Empty;
                    txbx_Name.Text = String.Empty;
                    txbx_UnitPrice.Text = String.Empty;
                    txbx_quantity.Text = String.Empty;
                    txbx_FullPrice.Text = String.Empty;
                    txbx_search_detail.Text = String.Empty;

                }
            }
            catch (Exception ex) 
            {

                
            }
        }

        private async void btn_Update_Detail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ID_Detail = Guid.Parse(txbx_Id_Detail.Text);
                NameDetail = txbx_Name.Text.Trim();
                UnitPrice = Decimal.Parse(txbx_UnitPrice.Text.Trim());
                Quantity = Int32.Parse(txbx_quantity.Text.Trim());
                FullPrice = Decimal.Parse(txbx_FullPrice.Text.Trim());

                await DataOperations.UpdateDetail(ID_Detail, NameDetail, UnitPrice, Quantity, FullPrice);
                dataGridDetails.ItemsSource = await DataOperations.GetAllDetailsView();
                MessageBox.Show($"Деталь {ID_Detail} обнавлена", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private async void btn_Delete_Detail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ID_Detail = Guid.Parse(txbx_Id_Detail.Text);
                await DataOperations.RemoveDetail(ID_Detail);
                dataGridDetails.ItemsSource = await DataOperations.GetAllDetailsView();
                MessageBox.Show($"Деталь {ID_Detail} удалена", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void txbx_Id_Detail_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_Id_Detail.Text != String.Empty)
                btn_Delete_Detail.IsEnabled = true;
            else
                btn_Delete_Detail.IsEnabled = false;
        }

        private void txbx_Name_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_Name.Text != String.Empty)
            {
                FlagName = true;
                txbx_Name.BorderBrush = Brushes.Green;
            }
            else
            {
                FlagName = false;
                txbx_Name.BorderBrush = Brushes.Gray;
            }
        }

        private void txbx_UnitPrice_SelectionChanged(object sender, RoutedEventArgs e)
        {



            if (txbx_UnitPrice.Text == String.Empty) 
            {
                txbx_UnitPrice.BorderBrush = Brushes.Gray;
                FlagUnitPrice = false;
                FullPrice = 0;
                txbx_FullPrice.Text = FullPrice.ToString();

            }
            else if (Regex.IsMatch(txbx_UnitPrice.Text, @"^\d+(\,\d{1,2})?$"))
            {
                Decimal.TryParse(txbx_UnitPrice.Text, out decimal price);
                Int32.TryParse(txbx_quantity.Text, out int quantity);
                UnitPrice = price;
                Quantity = quantity;
                FullPrice = UnitPrice * Quantity;
                txbx_FullPrice.Text = FullPrice.ToString();
                txbx_UnitPrice.BorderBrush = Brushes.Green;
                FlagUnitPrice = true;
            }
            else
            {
                txbx_UnitPrice.BorderBrush = Brushes.Red;
                FlagUnitPrice = false;
                FullPrice = 0;
                txbx_FullPrice.Text = FullPrice.ToString();

            }
        }

        private void txbx_quantity_SelectionChanged(object sender, RoutedEventArgs e)
        {

            if (txbx_quantity.Text == String.Empty) 
            {

                txbx_quantity.BorderBrush = Brushes.Gray;
                FlagQuantity = false;
                FullPrice = 0;
                txbx_FullPrice.Text = FullPrice.ToString();

            }
            else if (Regex.IsMatch(txbx_quantity.Text, @"[0-9]$"))
            {
                Decimal.TryParse(txbx_UnitPrice.Text, out decimal price);
                Int32.TryParse(txbx_quantity.Text, out int quantity);
                UnitPrice = price;
                Quantity = quantity;
                FullPrice = UnitPrice * Quantity;
                txbx_FullPrice.Text = FullPrice.ToString();
                txbx_quantity.BorderBrush = Brushes.Green;
                FlagQuantity = true;

            }
            else
            {
                txbx_quantity.BorderBrush = Brushes.Red;
                FlagQuantity = false;
                FullPrice = 0;
                txbx_FullPrice.Text = FullPrice.ToString();
            }
            
        }
    }
}
