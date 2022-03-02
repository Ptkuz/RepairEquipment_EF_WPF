using System;
using System.Windows;
using System.Windows.Media;

namespace ApplicationRepairPhoneEntityFramework
{
    /// <summary>
    /// Логика взаимодействия для AddDeviceWindow.xaml
    /// </summary>
    public partial class AddDeviceWindow : Window
    {
        bool flagName = false;
        bool flagSserialNumber = false;
        bool flagDsscription = false;
        bool flagManufacturer = false;
        bool flagModel = false;

        public bool FlagName
        {
            get { return flagName; }
            set
            {
                flagName = value;
                if (flagName && flagSserialNumber && flagDsscription && flagManufacturer && flagModel)
                    btn_Add_Device.IsEnabled = true;
                else
                    btn_Add_Device.IsEnabled = false;
            }
        }

        public bool FlagSerialNumber
        {
            get { return flagSserialNumber; }
            set
            {
                flagSserialNumber = value;
                if (flagName && flagSserialNumber && flagDsscription && flagManufacturer && flagModel)
                    btn_Add_Device.IsEnabled = true;
                else
                    btn_Add_Device.IsEnabled = false;
            }

        }

        public bool FlagDescription
        {
            get { return flagDsscription; }
            set
            {
                flagDsscription = value;
                if (flagName && flagSserialNumber && flagDsscription && flagManufacturer && flagModel)
                    btn_Add_Device.IsEnabled = true;
                else
                    btn_Add_Device.IsEnabled = false;
            }
        }

        public bool FlagManufactorer
        {
            get { return flagManufacturer; }
            set
            {
                flagManufacturer = value;
                if (flagName && flagSserialNumber && flagDsscription && flagManufacturer && flagModel)
                    btn_Add_Device.IsEnabled = true;
                else
                    btn_Add_Device.IsEnabled = false;
            }
        }

        public bool FlagModel
        {
            get { return flagModel; }
            set
            {
                flagModel = value;
                if (flagName && flagSserialNumber && flagDsscription && flagManufacturer && flagModel)
                    btn_Add_Device.IsEnabled = true;
                else
                    btn_Add_Device.IsEnabled = false;
            }

        }

        public Guid ID_Device { get; set; }
        public string? Name_Device { get; set; }
        public string? SerialNumber { get; set; }
        public string? Dsscription { get; set; }
        public string Manufactorer { get; set; }
        public string? Model { get; set; }
        public DateTime? DateAdded { get; set; }





        public AddDeviceWindow()
        {
            InitializeComponent();
            ID_Device = Guid.NewGuid();
            txbx_ID_Device.Text = ID_Device.ToString();

        }

        private async void btn_Add_Device_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Name_Device = txbx_Name_Device.Text;
                SerialNumber = txbx_Serial_Number.Text;
                Dsscription = txbx_Description.Text;
                Manufactorer = txbx_anufacturer.Text;
                Model = txbx_Model.Text;
                DateAdded = DateTime.Now;

                if (await DataOperations.InsertDevice(ID_Device, Name_Device, SerialNumber, Dsscription, Manufactorer, Model, DateAdded))
                    this.DialogResult = true;
                else
                    this.DialogResult = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void txbx_Name_Device_SelectionChanged(object sender, RoutedEventArgs e)
        {

            if (txbx_Name_Device.Text == String.Empty) 
            {
                FlagName = false;
                lb_Name.Opacity = 0;
                lb_Name.Content = "";

            }
            else if (txbx_Name_Device.Text != String.Empty)
            {
                FlagName = true;
                lb_Name.Opacity = 1;
                lb_Name.Content = "Данные корректны";
                lb_Name.Background = Brushes.Green;
            }
            else
            {
                lb_Name.Opacity = 0;
                FlagName = false;
            }
        }

        private void txbx_Serial_Number_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_Serial_Number.Text == String.Empty) 
            {
                FlagSerialNumber = false;
                lb_SerialNumber.Opacity = 0;
                lb_SerialNumber.Content = "";


            }
            else if (txbx_Serial_Number.Text != String.Empty)
            {
                FlagSerialNumber = true;
                lb_SerialNumber.Opacity = 1;
                lb_SerialNumber.Content = "Данные корректны";
                lb_SerialNumber.Background = Brushes.Green;
            }
            else
            {
                lb_SerialNumber.Opacity = 0;
                FlagSerialNumber = false;
            }

        }

        private void txbx_Description_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_Description.Text == String.Empty) 
            {
                FlagDescription = false;
                lb_Description.Opacity = 0;
                lb_Description.Content = "";
            }
            else if (txbx_Description.Text != String.Empty)
            {
                lb_Description.Opacity = 1;
                FlagDescription = true;
                lb_Description.Content = "Данные корректны";
                lb_Description.Background = Brushes.Green;
            }
            else
            {
                lb_Description.Opacity = 0;
                FlagDescription = false;
            }
        }

        private void txbx_anufacturer_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_anufacturer.Text == String.Empty) 
            {
                FlagManufactorer = false;
                lb_Manufacturer.Opacity = 0;
                lb_Manufacturer.Content = "";


            }
            else if (txbx_anufacturer.Text != String.Empty)
            {
                FlagManufactorer = true;
                lb_Manufacturer.Opacity = 1;
                lb_Manufacturer.Content = "Данные корректны";
                lb_Manufacturer.Background = Brushes.Green;
            }
            else
            {
                lb_Manufacturer.Opacity = 0;
                FlagManufactorer = false;

            }
        }

        private void txbx_Model_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_Model.Text == String.Empty) 
            {
                FlagModel = false;
                lb_Model.Opacity = 0;
                lb_Model.Content = "";

            }
            else if (txbx_Model.Text != String.Empty)
            {
                FlagModel = true;
                lb_Model.Opacity = 1;
                lb_Model.Content = "Данные корректны";
                lb_Model.Background = Brushes.Green;
            }
            else
            {
                lb_Model.Opacity = 0;
                FlagModel = false;
            }
        }
    }
}
