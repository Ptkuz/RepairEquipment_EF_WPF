using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ApplicationRepairPhoneEntityFramework
{
    /// <summary>
    /// Логика взаимодействия для PerformanceWindow.xaml
    /// </summary>

    public partial class PerformanceWindow : Window
    {

        ArrayList arrayDetails = new ArrayList();
        ArrayList arrayOrders = new ArrayList();
        Dictionary<Guid, int> IdQuantityDetails = new Dictionary<Guid, int>();
        decimal MultiPrice = 0;
        bool flagDescription = false;
        bool flagPriceWork = false;
        bool flagDate = false;


        public Guid ID_Performance { get; set; }
        string description_repair;
        public string DescriptionRepair
        {
            get { return description_repair; }
            set
            {
                description_repair = value;
                if (flagDescription && flagPriceWork && flagDate)
                    Btn_Insert_Detail.IsEnabled = true;
                else
                    Btn_Insert_Detail.IsEnabled = false;


            }
        }

        decimal work_price;
        public decimal WorkPrice
        {
            get { return work_price; }
            set
            {
                work_price = value;
                if (flagDescription && flagPriceWork && flagDate)
                    Btn_Insert_Detail.IsEnabled = true;
                else
                    Btn_Insert_Detail.IsEnabled = false;
            }
        }

        decimal details_Price;
        public decimal DetailsPrice
        {
            get { return details_Price; }
            set { details_Price = value; }
        }

        decimal discount = 0;
        public decimal Discount
        {
            get { return discount; }
            set { discount = value; }
        }
        decimal finalPrice;
        public decimal FinalPrice
        {
            get { return finalPrice; }
            set { finalPrice = value; }
        }

        DateTime? date_performance;
        public DateTime? DatePerformance
        {
            get { return date_performance; }
            set
            {
                date_performance = value;
                if (flagDescription && flagPriceWork && flagDate)
                    Btn_Insert_Detail.IsEnabled = true;
                else
                    Btn_Insert_Detail.IsEnabled = false;
            }
        }
        Guid id_Order;
        public Guid ID_Order
        {
            get { return id_Order; }
            set
            {
                id_Order = value;
                
            }


        }


        public PerformanceWindow()
        {
            InitializeComponent();
            ID_Performance = Guid.NewGuid();
            txbx_ID_Performance.Text = ID_Performance.ToString();

            GetData();
            async void GetData()
            {
                arrayDetails = await DataOperations.GetAllDetails();
                arrayOrders = await DataOperations.GetAllOrders();
                DataGridDetails.ItemsSource = arrayDetails;
                ListBoxOrders.ItemsSource = arrayOrders;
            }






        }



        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                DescriptionRepair = txbx_Description.Text.Trim();
                WorkPrice = Decimal.Parse(txbx_Price_Work.Text.Trim());
                if (txbx_PriceAllDetails.Text.Trim() == String.Empty)
                    DetailsPrice = 0;
                else
                    DetailsPrice = Decimal.Parse(txbx_PriceAllDetails.Text.Trim());

                if (txbx_Discount.Text.Trim() == String.Empty)
                    Discount = 0;
                else
                    Discount = Decimal.Parse(txbx_Discount.Text.Trim());

                FinalPrice = Decimal.Parse(txbx_FinalPrice.Text.Trim());
                DatePerformance = DatePerformanceDP.SelectedDate;
                if (ListBoxOrders.SelectedValue == null) 
                {
                    throw new NullReferenceException();
                }
                ID_Order = Guid.Parse(ListBoxOrders.SelectedValue.ToString()!);


                await DataOperations.InsertStockDetails(ID_Performance, DescriptionRepair, WorkPrice, DetailsPrice, Discount, FinalPrice, DatePerformance, IdQuantityDetails, ID_Order);

                MessageBox.Show("Данные загружены", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Information);


            }
            catch (NullReferenceException) 
            {
                MessageBox.Show("Вы не выбрали заказ для добавления исполнения", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                MessageBox.Show("В данный заказ уже добавлено исполнение", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }



        private void OnChecked(object sender, RoutedEventArgs e)
        {
            try
            {
                var checkBoxValue = this.DataGridDetails.Columns[0].GetCellContent(this.DataGridDetails.SelectedItem);
                if (checkBoxValue != null)
                {

                    DataGridDetails.Columns[6].IsReadOnly = true;

                    //DataGridDetails.SelectedIndex = 0;

                    CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

                    object item = DataGridDetails.SelectedItem;
                    string ID_Detail = (DataGridDetails.SelectedCells[1].Column.GetCellContent(item) as TextBlock)!.Text;
                    Guid ID = Guid.Parse(ID_Detail);
                    int Quantity = Int32.Parse((DataGridDetails.SelectedCells[6].Column.GetCellContent(item) as TextBlock)!.Text.Trim());
                    decimal UnitPrice = decimal.Parse((DataGridDetails.SelectedCells[3].Column.GetCellContent(item) as TextBlock)!.Text);

                    Thread.CurrentThread.CurrentCulture = temp_culture;


                    IdQuantityDetails.Add(ID, Quantity);

                    MultiPrice += Quantity * UnitPrice;
                    txbx_PriceAllDetails.Text = MultiPrice.ToString();
                }
            }
            catch (FormatException)
            {
                //MessageBox.Show("Поле (Необходимое количество) должно содержать целочисленное значение");

            }
            catch (ArgumentException)
            {
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Error);

            }


        }

        private void UnChecked(object sender, RoutedEventArgs e)
        {
            try
            {
                var checkBoxValue = this.DataGridDetails.Columns[0].GetCellContent(this.DataGridDetails.SelectedItem);
                if (checkBoxValue != null)
                {
                    DataGridDetails.Columns[6].IsReadOnly = false;

                    CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    object item = DataGridDetails.SelectedItem;
                    string ID_Detail = (DataGridDetails.SelectedCells[1].Column.GetCellContent(item) as TextBlock)!.Text;
                    Guid ID = Guid.Parse(ID_Detail);
                    int Quantity = Int32.Parse((DataGridDetails.SelectedCells[6].Column.GetCellContent(item) as TextBlock)!.Text.Trim());
                    decimal UnitPrice = decimal.Parse((DataGridDetails.SelectedCells[3].Column.GetCellContent(item) as TextBlock)!.Text);
                    Thread.CurrentThread.CurrentCulture = temp_culture;

                    MultiPrice -= Quantity * UnitPrice;
                    txbx_PriceAllDetails.Text = MultiPrice.ToString();

                    IdQuantityDetails.Remove(ID);
                }
            }
            catch (FormatException)
            {
                //MessageBox.Show("Поле (Необходимое количество) должно содержать целочисленное значение");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Error);

            }



        }

        private void DataGridDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridDetails.Columns[6].IsReadOnly = false;
        }

        private void txbx_Price_Work_SelectionChanged(object sender, RoutedEventArgs e)
        {
            try
            {

                if (txbx_Price_Work.Text != String.Empty)
                {
                    flagPriceWork = true;
                    WorkPrice = Decimal.Parse(txbx_Price_Work.Text);
                    FinalPrice = WorkPrice + DetailsPrice;
                    txbx_FinalPrice.Text = FinalPrice.ToString();
                    chbx_CheckDiscount.IsEnabled = true;
                    txbx_Price_Work.MaxLength = 5;

                }
                else if (txbx_Price_Work.Text == String.Empty)
                {
                    flagPriceWork = false;
                    WorkPrice = 0;
                    FinalPrice = WorkPrice + DetailsPrice;
                    txbx_FinalPrice.Text = FinalPrice.ToString();
                    chbx_CheckDiscount.IsEnabled = false;
                    chbx_CheckDiscount.IsChecked = false;

                    txbx_Discount.Clear();

                }
            }
            catch (FormatException)
            {
                txbx_Price_Work.Clear();
                MessageBox.Show("Вводимая строка принимает только числовые значения!", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


        }

        private void txbx_PriceAllDetails_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_PriceAllDetails.Text != String.Empty)
            {
                DetailsPrice = Decimal.Parse(txbx_PriceAllDetails.Text);
                FinalPrice = WorkPrice + DetailsPrice;
                txbx_FinalPrice.Text = FinalPrice.ToString();
            }
        }

        private void txbx_Discount_SelectionChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txbx_Discount.Text != String.Empty && txbx_Discount.Text != "0")
                {
                    Discount = Decimal.Parse(txbx_Discount.Text);
                    FinalPrice = ((DetailsPrice + WorkPrice) - (((DetailsPrice + WorkPrice) * Discount) / 100));
                    txbx_FinalPrice.Text = FinalPrice.ToString();
                    txbx_Discount.MaxLength = 2;

                }
                else if (txbx_Discount.Text == String.Empty || txbx_Discount.Text == "0")
                {
                    Discount = 0;
                    FinalPrice = WorkPrice + DetailsPrice;
                    txbx_FinalPrice.Text = FinalPrice.ToString();
                }

            }
            catch (FormatException)
            {
                txbx_Discount.Clear();
                MessageBox.Show("Вводимая строка принимает только числовые значения!", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void chbx_CheckDiscount_Checked(object sender, RoutedEventArgs e)
        {
            txbx_Discount.IsEnabled = true;
        }

        private void chbx_CheckDiscount_Unchecked(object sender, RoutedEventArgs e)
        {
            txbx_Discount.Clear();
            txbx_Discount.IsEnabled = false;

        }

        private void txbx_Description_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_Description.Text != String.Empty)
            {
                flagDescription = true;
                DescriptionRepair = txbx_Description.Text;
                txbx_Description.MaxLength = 500;

            }
            else if (txbx_Description.Text == String.Empty)
            {
                flagDescription = false;
                DescriptionRepair = txbx_Description.Text;

            }
        }

        private void DatePerformanceDP_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DatePerformanceDP.SelectedDate != null)
            {
                flagDate = true;
                DatePerformance = DatePerformanceDP.SelectedDate;
            }
            else if (DatePerformanceDP.SelectedDate == null)
            {
                flagDate = false;
            }

        }

        private async void txbx_search_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string search = txbx_search.Text.Trim();
            ListBoxOrders.ItemsSource = await DataOperations.SearchOrders(search);
        }





        
    }
}
