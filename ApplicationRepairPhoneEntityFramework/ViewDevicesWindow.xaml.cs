using System;
using System.Collections;
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
    /// Логика взаимодействия для ViewDevicesWindow.xaml
    /// </summary>
    public partial class ViewDevicesWindow : Window
    {
        ArrayList allDevices = new ArrayList();

        bool flagName = false;
        bool flagSeriesNumber = false;
        bool flagDescription = false;
        bool flagManufacturer = false;
        bool flagMoodel = false;



        public bool FkagName
        {
            get { return flagName; }
            set
            {
                flagName = value;
                if (flagName && flagSeriesNumber && flagSeriesNumber && flagDescription && flagManufacturer && flagMoodel)
                    btn_Update_Device.IsEnabled = true;
                else
                    btn_Update_Device.IsEnabled = false;

            }
        }

        public bool FlagSeriesNumber
        {
            get { return flagSeriesNumber; }
            set
            {
                flagSeriesNumber = value;
                if (flagName && flagSeriesNumber && flagSeriesNumber && flagDescription && flagManufacturer && flagMoodel)
                    btn_Update_Device.IsEnabled = true;
                else
                    btn_Update_Device.IsEnabled = false;
            }
        }

        public bool FlagDescription
        {
            get { return flagDescription; }
            set
            {
                flagDescription = value;
                if (flagName && flagSeriesNumber && flagSeriesNumber && flagDescription && flagManufacturer && flagMoodel)
                    btn_Update_Device.IsEnabled = true;
                else
                    btn_Update_Device.IsEnabled = false;
            }
        }

        public bool FlagManufacturer
        {
            get { return flagManufacturer; }
            set
            {
                flagManufacturer = value;
                if (flagName && flagSeriesNumber && flagSeriesNumber && flagDescription && flagManufacturer && flagMoodel)
                    btn_Update_Device.IsEnabled = true;
                else
                    btn_Update_Device.IsEnabled = false;
            }
        }

        public bool FlagMoodel
        {
            get { return flagMoodel; }
            set
            {
                flagMoodel = value;
                if (flagName && flagSeriesNumber && flagSeriesNumber && flagDescription && flagManufacturer && flagMoodel)
                    btn_Update_Device.IsEnabled = true;
                else
                    btn_Update_Device.IsEnabled = false;
            }
        }




        public Guid ID_Device { get; set; }
        public string NameDevice { get; set; }
        public string SeriesNumber { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }


        public ViewDevicesWindow()
        {
            InitializeComponent();
            GetAllDevices();
            async void GetAllDevices()
            {
                allDevices = await DataOperations.GetAllDevices();
                dataGridDevices.ItemsSource = allDevices;


            }
        }

        private async void btn_Add_Device_Click(object sender, RoutedEventArgs e)
        {
            AddDeviceWindow addDevicesWindow = new AddDeviceWindow();
            bool? result = addDevicesWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {

                dataGridDevices.ItemsSource = await DataOperations.GetAllDevices();
                MessageBox.Show("Новое оборудование успешно добавлено", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Information);

            }


        }

        private async void txbx_search_device_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string search = txbx_search_device.Text;
            dataGridDevices.ItemsSource = await DataOperations.SearchDevices(search);
        }

        private void dataGridDevices_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = dataGridDevices.SelectedItem;
            if (item != null)
            {
                string ID_Device = (dataGridDevices.SelectedCells[0].Column.GetCellContent(item) as TextBlock)!.Text;
                string NameDevice = (dataGridDevices.SelectedCells[1].Column.GetCellContent(item) as TextBlock)!.Text;
                string sesiesNumber = (dataGridDevices.SelectedCells[2].Column.GetCellContent(item) as TextBlock)!.Text;
                string description = (dataGridDevices.SelectedCells[3].Column.GetCellContent(item) as TextBlock)!.Text;
                string manufacturer = (dataGridDevices.SelectedCells[4].Column.GetCellContent(item) as TextBlock)!.Text;
                string model = (dataGridDevices.SelectedCells[5].Column.GetCellContent(item) as TextBlock)!.Text;

                txbx_Id_Device.Text = ID_Device;
                txbx_Name.Text = NameDevice;
                txbx_serielNumber.Text = sesiesNumber;
                txbx_description.Text = description;
                txbx_manufacturer.Text = manufacturer;
                txbx_model.Text = model;
            }
            else
            {
                txbx_Id_Device.Text = String.Empty;
                txbx_Name.Text = String.Empty;
                txbx_serielNumber.Text = String.Empty;
                txbx_description.Text = String.Empty;
                txbx_manufacturer.Text = String.Empty;
                txbx_model.Text = String.Empty;
                txbx_search_device.Text = String.Empty;

            }
        }

        private async void btn_Update_Device_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                ID_Device = Guid.Parse(txbx_Id_Device.Text);
                NameDevice = txbx_Name.Text.Trim();
                SeriesNumber = txbx_serielNumber.Text.Trim();
                Description = txbx_description.Text.Trim();
                Manufacturer = txbx_manufacturer.Text.Trim();
                Model = txbx_model.Text.Trim();
                await DataOperations.UpdateDevice(ID_Device, NameDevice, SeriesNumber, Description, Manufacturer, Model);
                dataGridDevices.ItemsSource = await DataOperations.GetAllDevices();
                MessageBox.Show($"Оборудование {ID_Device} обновлено", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private async void btn_Delete_Device_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ID_Device = Guid.Parse(txbx_Id_Device.Text);
                await DataOperations.RemoveDevice(ID_Device);
                dataGridDevices.ItemsSource = await DataOperations.GetAllDevices();
                MessageBox.Show($"Оборудование {ID_Device} удалено", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void txbx_Id_Device_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_Id_Device.Text != String.Empty)
                btn_Delete_Device.IsEnabled = true;
            else
                btn_Delete_Device.IsEnabled = false;
            
        }

        private void txbx_Name_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_Name.Text == String.Empty)
            {
                FkagName = false;
                txbx_Name.BorderBrush = Brushes.Gray;

            }
            else
            {
                FkagName = true;
                txbx_Name.BorderBrush = Brushes.Green;

            }
        }

        private void txbx_serielNumber_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_serielNumber.Text == String.Empty)
            {
                FlagSeriesNumber = false;
                txbx_serielNumber.BorderBrush = Brushes.Gray;

            }
            else
            {
                FlagSeriesNumber = true;
                txbx_serielNumber.BorderBrush = Brushes.Green;

            }
        }

        private void txbx_description_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_description.Text == String.Empty)
            {
                FlagDescription = false;
                txbx_description.BorderBrush = Brushes.Gray;

            }
            else
            {
                FlagDescription = true;
                txbx_description.BorderBrush = Brushes.Green;

            }
        }

        private void txbx_manufacturer_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_manufacturer.Text == String.Empty)
            {
                FlagManufacturer = false;
                txbx_manufacturer.BorderBrush = Brushes.Gray;

            }
            else
            {
                FlagManufacturer = true;
                txbx_manufacturer.BorderBrush = Brushes.Green;

            }
        }

        private void txbx_model_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_model.Text == String.Empty)
            {
                FlagMoodel = false;
                txbx_model.BorderBrush = Brushes.Gray;

            }
            else
            {
                FlagMoodel = true;
                txbx_model.BorderBrush = Brushes.Green;

            }
        }
    }
}
