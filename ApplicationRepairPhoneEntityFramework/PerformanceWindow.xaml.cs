using RepaifPhoneDB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
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
        Dictionary<Guid, int> IdQuantityDetails = new Dictionary<Guid, int>();
        decimal MultiPrice = 0;
        public bool ChBox { get; set; } = true;

        public PerformanceWindow()
        {
            InitializeComponent();
            txbx_ID_Performance.Text = Guid.NewGuid().ToString();


            using (ApplicationContext db = new ApplicationContext())
            {
                var details = from detail in db.stockDetails
                              select detail;


                foreach (var detail in details)
                {
                    arrayDetails.Add(detail);

                }
                DataGridDetails.ItemsSource = arrayDetails;

            }



        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    string description_rapair = txbx_Description.Text;
                    decimal workPrice = decimal.Parse(txbx_Price_Work.Text);
                    decimal detailsPrice = decimal.Parse(txbx_PriceAllDetails.Text);
                    decimal discount = decimal.Parse(txbx_Discount.Text);
                    decimal finalPrice = decimal.Parse(txbx_FinalPrice.Text);
                    DateTime? datePerformance = DatePerformance.SelectedDate;

                    Performance detail = new Performance
                    { ID_Performance = Guid.Parse(txbx_ID_Performance.Text), Description_Repair = description_rapair, Work_Price = workPrice, Detail_Price = detailsPrice, Discount = discount, Final_Price = finalPrice, Date_Performance = datePerformance };
                    db.Add(detail);

                    Relationship relationships;

                    foreach (var IdQuantityDetailsNum in IdQuantityDetails)
                    {

                        relationships = new Relationship() { ID_Performance = Guid.Parse(txbx_ID_Performance.Text), ID_Detail = IdQuantityDetailsNum.Key };
                        db.Add(relationships);
                    }


                    foreach (var IsQuantityDetailsNum in IdQuantityDetails)
                    {
                        var stockDetail = db.stockDetails.
                            Where(c => c.ID_Detail == IsQuantityDetailsNum.Key)
                            .FirstOrDefault();
                        stockDetail.QuantityStock -= IsQuantityDetailsNum.Value;
                        if (stockDetail.QuantityStock < 0)
                        {
                            throw new Exception("На складе нет столько деталей");

                        }

                    }


                    db.SaveChanges();


                    MessageBox.Show("Данные загружены");

                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void DataGridDetails_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {



        }

        private void DataGridDetails_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void DataGridDetails_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void DataGridDetails_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {


        }

        private void OnChecked(object sender, RoutedEventArgs e)
        {
            try
            {
                var checkBoxValue = this.DataGridDetails.Columns[0].GetCellContent(this.DataGridDetails.SelectedItem);
                if (checkBoxValue != null)
                {


                    CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

                    object item = DataGridDetails.SelectedItem;
                    string ID_Detail = (DataGridDetails.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                    Guid ID = Guid.Parse(ID_Detail);
                    int Quantity = Int32.Parse((DataGridDetails.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text.Trim());
                    decimal UnitPrice = decimal.Parse((DataGridDetails.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text);

                    Thread.CurrentThread.CurrentCulture = temp_culture;


                    IdQuantityDetails.Add(ID, Quantity);

                    MultiPrice += Quantity * UnitPrice;
                    txbx_PriceAllDetails.Text = MultiPrice.ToString();
                }
            }
            catch (FormatException fex)
            {
                MessageBox.Show("Поле (Необходимое количество) должно содержать целочисленное значение");

            }
            catch (ArgumentException) 
            {
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }

        private void UnChecked(object sender, RoutedEventArgs e)
        {
            try
            {
                var checkBoxValue = this.DataGridDetails.Columns[0].GetCellContent(this.DataGridDetails.SelectedItem);
                if (checkBoxValue != null)
                {
                    CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    object item = DataGridDetails.SelectedItem;
                    string ID_Detail = (DataGridDetails.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                    Guid ID = Guid.Parse(ID_Detail);
                    int Quantity = Int32.Parse((DataGridDetails.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text.Trim());
                    decimal UnitPrice = decimal.Parse((DataGridDetails.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text);
                    Thread.CurrentThread.CurrentCulture = temp_culture;

                    MultiPrice -= Quantity * UnitPrice;
                    txbx_PriceAllDetails.Text = MultiPrice.ToString();

                    IdQuantityDetails.Remove(ID);
                }
            }
            catch (FormatException fex)
            {
                MessageBox.Show("Поле (Необходимое количество) должно содержать целочисленное значение");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }



        }

    }
}
