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

                if (await DataOperations.InsertDetails(ID_Detail, Name_Detail, Unit_Price, Quantity, FullPrice))
                    this.DialogResult = true;
                else
                    this.DialogResult = false;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Error);
            
            }
        }

        private void txbx_Unit_Price_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_Unit_Price.Text == String.Empty) 
            {
                FlagPrice = false;
                lb_UnitPrice.Opacity = 0;
                FullPrice = 0;
                txbx_FullPrice.Text = FullPrice.ToString();
                lb_UnitPrice.Content = "";

            }
            else if (Regex.IsMatch(txbx_Unit_Price.Text, @"^\d+(\,\d{1,2})?$"))
            {
                Decimal.TryParse(txbx_Unit_Price.Text, out decimal price);
                Int32.TryParse(txbx_Quantity.Text, out int quantity);
                Unit_Price = price;
                Quantity = quantity;
                FullPrice = Unit_Price * Quantity;
                txbx_FullPrice.Text = FullPrice.ToString();
                lb_UnitPrice.Opacity = 1;
                lb_UnitPrice.Content = "Данные корректны";
                lb_UnitPrice.Background = Brushes.Green;
                FlagPrice = true;
            }
            else
            {
                lb_UnitPrice.Opacity = 1;
                lb_UnitPrice.Content = "Принимает только числа";
                lb_UnitPrice.Background = Brushes.Red;
                FlagPrice = false;
                FullPrice = 0;
                txbx_FullPrice.Text = FullPrice.ToString();

            }
        }

        private void txbx_Quantity_SelectionChanged(object sender, RoutedEventArgs e)
        {

            if (txbx_Unit_Price.Text == String.Empty) 
            {
                FlagQuantity = false;
                lb_Quantity.Opacity = 0;
                FullPrice = 0;
                txbx_FullPrice.Text = FullPrice.ToString();
                lb_Quantity.Content = "";

            }
            else if (Regex.IsMatch(txbx_Quantity.Text, @"[0-9]$"))
            {
                Decimal.TryParse(txbx_Unit_Price.Text, out decimal price);
                Int32.TryParse(txbx_Quantity.Text, out int quantity);
                Unit_Price = price;
                Quantity = quantity;
                FullPrice = Unit_Price * Quantity;
                txbx_FullPrice.Text = FullPrice.ToString();
                lb_Quantity.Opacity = 1;
                lb_Quantity.Content = "Данные корректны";
                lb_Quantity.Background = Brushes.Green;
                FlagQuantity = true;

            }
            else
            {
                lb_Quantity.Opacity = 1;
                lb_Quantity.Content = "Принимает только целые числа";
                lb_Quantity.Background = Brushes.Red;
                FlagQuantity = false;
                FullPrice = 0;
                txbx_FullPrice.Text = FullPrice.ToString();
            }
            
        }

        private void txbx_Name_Detail_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_Name_Detail.Text == String.Empty) 
            {
                FlagName = false;
                lb_Name.Opacity = 0;
                lb_Name.Content = "";

            }
            else if (txbx_Name_Detail.Text != String.Empty)
            {
                txbx_Name_Detail.Opacity = 1;

                FlagName = true;
                lb_Name.Opacity = 1;
                lb_Name.Content = "Данные корректны";
                lb_Name.Background = Brushes.Green;

            }
            else
            {
                txbx_Name_Detail.Opacity = 0;
                FlagName = false;

            }
        }
    }
}
