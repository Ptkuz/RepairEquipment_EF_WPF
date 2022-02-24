using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;

namespace ApplicationRepairPhoneEntityFramework
{
    /// <summary>
    /// Логика взаимодействия для AddDetailsWindow.xaml
    /// </summary>
    public partial class AddDetailsWindow : Window
    {
        bool flagName = false;
        bool flagPrice = false;
        bool flagQuantity = false;

        public bool FlagName 
        {
            get { return flagName; }
            set { 
                flagName = value;
                if (flagName && flagPrice && flagQuantity)
                    btn_Add_Details.IsEnabled = true;
                else
                    btn_Add_Details.IsEnabled = false;

            }
        
        }

        public bool FlagPrice 
        {
            get { return flagPrice; }
            set { 
                flagPrice = value;
                if (flagName && flagPrice && flagQuantity)
                    btn_Add_Details.IsEnabled = true;
                else
                    btn_Add_Details.IsEnabled = false;
            }
        
        }

        public bool FlagQuantity
        {
            get { return flagQuantity; }
            set { 
                flagQuantity = value;
                if (flagName && flagPrice && flagQuantity)
                    btn_Add_Details.IsEnabled = true;
                else
                    btn_Add_Details.IsEnabled = false;

            }
        }



        public Guid ID_Detail { get; set; }
        public string Name_Detail { get; set; }
        public decimal Unit_Price { get; set; }
        public int Quantity { get; set; }
        public decimal FullPrice { get; set; }



        public AddDetailsWindow()
        {
            InitializeComponent();
            ID_Detail = Guid.NewGuid();
            txbx_ID_Detail.Text = ID_Detail.ToString();
        }

        private async void btn_Add_Details_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ID_Detail = Guid.Parse(txbx_ID_Detail.Text);
                Name_Detail = txbx_Name_Detail.Text;
                Unit_Price = Decimal.Parse(txbx_Unit_Price.Text);
                Quantity = Int32.Parse(txbx_Quantity.Text);
                FullPrice = Decimal.Parse(txbx_FullPrice.Text);

                await DataOperations.InsertDetails(ID_Detail, Name_Detail, Unit_Price, Quantity, FullPrice);
                MessageBox.Show("Детали добавлены на склад", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Error);
            
            }
        }

        private void txbx_Unit_Price_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txbx_Unit_Price.Text, @"[0-9]$"))
            {
                Decimal.TryParse(txbx_Unit_Price.Text, out decimal price);
                Int32.TryParse(txbx_Quantity.Text, out int quantity);
                Unit_Price = price;
                Quantity = quantity;
                FullPrice = Unit_Price * Quantity;
                txbx_FullPrice.Text = FullPrice.ToString();
                lb_UnitPrice.Content = "Данные корректны";
                lb_UnitPrice.Background = Brushes.Green;
                FlagPrice = true;
            }
            else 
            {
                lb_UnitPrice.Content = "Принимает только числа";
                lb_UnitPrice.Background = Brushes.Red;
                FlagPrice = false;

            }
        }

        private void txbx_Quantity_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_Unit_Price.Text != String.Empty || txbx_Quantity.Text != null)
            {
                if (Regex.IsMatch(txbx_Quantity.Text, @"[0-9]$"))
                {
                    Decimal.TryParse(txbx_Unit_Price.Text, out decimal price);
                    Int32.TryParse(txbx_Quantity.Text, out int quantity);
                    Unit_Price = price;
                    Quantity = quantity;
                    FullPrice = Unit_Price * Quantity;
                    txbx_FullPrice.Text = FullPrice.ToString();
                    lb_Quantity.Content = "Данные корректны";
                    lb_Quantity.Background = Brushes.Green;
                    FlagQuantity = true;

                }
                else 
                {
                    lb_Quantity.Content = "Принимает только целые числа";
                    lb_Quantity.Background = Brushes.Red;
                    FlagQuantity= false;
                }
            }
        }

        private void txbx_Name_Detail_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_Name_Detail.Text != String.Empty)
            {

                FlagName = true;
                lb_Name.Content = "Данные корректны";
                lb_Name.Background = Brushes.Green;

            }
            else 
            { 
                FlagName=false;
                lb_Name.Content = "Данные некорректны";
                lb_Name.Background = Brushes.Red;

            }
        }
    }
}
