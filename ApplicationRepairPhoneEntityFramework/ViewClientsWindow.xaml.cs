using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ApplicationRepairPhoneEntityFramework
{
    /// <summary>
    /// Логика взаимодействия для DirectorViewClientsWindow.xaml
    /// </summary>
    public partial class DirectorViewClientsWindow : Window
    {
        ArrayList allClients = new ArrayList();

        bool flagFio = false;
        bool flagSeriesNumber = false;
        bool flagPhoneNumber = false;
        bool flagEmail = true;

        public bool FlagFIO
        {
            get { return flagFio; }
            set { flagFio = value;  
                if(flagFio && flagSeriesNumber && flagPhoneNumber && flagEmail)
                    btn_Update_Client.IsEnabled = true;
                else
                    btn_Update_Client.IsEnabled=false;
            
            }
        }

        public bool FlagSeriesNumber
        {
            get { return flagSeriesNumber; }
            set { flagSeriesNumber = value;
                if (flagFio && flagSeriesNumber && flagPhoneNumber && flagEmail)
                    btn_Update_Client.IsEnabled = true;
                else
                    btn_Update_Client.IsEnabled = false;
            }
        }

        public bool FlagPhoneNumber
        {
            get { return flagPhoneNumber; }
            set { flagPhoneNumber = value;
                if (flagFio && flagSeriesNumber && flagPhoneNumber && flagEmail)
                    btn_Update_Client.IsEnabled = true;
                else
                    btn_Update_Client.IsEnabled = false;
            }
        }
        public bool FlagEmail
        {
            get { return flagEmail; }
            set
            {
                flagEmail = value;
                if (flagFio && flagSeriesNumber && flagPhoneNumber && flagEmail)
                    btn_Update_Client.IsEnabled = true;
                else
                    btn_Update_Client.IsEnabled = false;
            }
        }




        public Guid ID_Client { get; set; }
        public string FIO { get; set; }
        public string SerialNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DirectorViewClientsWindow()
        {
            InitializeComponent();
            GetAllClients();
            async void GetAllClients()
            {
                allClients = await DataOperations.GetAllClients();
                dataGridClients.ItemsSource = allClients;


            }
        }

        private async void btn_Add_Client_Click(object sender, RoutedEventArgs e)
        {

            AddClientWindow addClientWindow = new AddClientWindow();
            bool? result = addClientWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {

                dataGridClients.ItemsSource = await DataOperations.GetAllClients();
                MessageBox.Show("Новый клиент успешно добавлен", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Information);

            }

        }

        private async void txbx_search_client_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string search = txbx_search_client.Text;
            dataGridClients.ItemsSource = await DataOperations.SearchClients(search);
        }

        private void dataGridClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = dataGridClients.SelectedItem;
            if (item != null)
            {
                string ID_Client = (dataGridClients.SelectedCells[0].Column.GetCellContent(item) as TextBlock)!.Text;
                string fio = (dataGridClients.SelectedCells[1].Column.GetCellContent(item) as TextBlock)!.Text;
                string serialNumber = (dataGridClients.SelectedCells[2].Column.GetCellContent(item) as TextBlock)!.Text;
                string numberPhone = (dataGridClients.SelectedCells[3].Column.GetCellContent(item) as TextBlock)!.Text;
                string email = (dataGridClients.SelectedCells[5].Column.GetCellContent(item) as TextBlock)!.Text;

                txbx_Id_Client.Text = ID_Client;
                txbx_fio.Text = fio;
                txbx_series_number.Text = serialNumber;
                txbx_phone_number.Text = numberPhone;
                txbx_email.Text = email;
            }
            else
            {
                txbx_Id_Client.Text = String.Empty;
                txbx_fio.Text = String.Empty;
                txbx_series_number.Text = String.Empty;
                txbx_phone_number.Text = String.Empty;
                txbx_email.Text = String.Empty;

            }
        }

        private async void btn_Update_Client_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ID_Client = Guid.Parse(txbx_Id_Client.Text);
                FIO = txbx_fio.Text.Trim();
                SerialNumber = txbx_series_number.Text.Trim();
                PhoneNumber = txbx_phone_number.Text.Trim();
                Email = txbx_email.Text.Trim();
                await DataOperations.UpdateClient(ID_Client, FIO, SerialNumber, PhoneNumber, Email);
                dataGridClients.ItemsSource = await DataOperations.GetAllClients();
                MessageBox.Show($"Клиент {ID_Client} обновлен", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        private async void btn_Delete_Client_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ID_Client = Guid.Parse(txbx_Id_Client.Text);
                await DataOperations.RemoveClient(ID_Client);
                dataGridClients.ItemsSource = await DataOperations.GetAllClients();
                MessageBox.Show($"Клиент {ID_Client} удален", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void txbx_Id_Client_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_Id_Client.Text != String.Empty)
            {
                btn_Delete_Client.IsEnabled = true;
            }
            else
            {

                btn_Delete_Client.IsEnabled = false;
            }
        }

        private void txbx_fio_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_fio.Text == String.Empty) 
            {
                FlagFIO = false;
                txbx_fio.BorderBrush = Brushes.Gray;

            }
            else if (!Regex.IsMatch(txbx_fio.Text.Trim(), @"^[А-ЯA-Z][а-яa-z\-]{0,}\s[А-ЯA-Z][а-яa-z\-]{1,}(\s[А-ЯA-Z][а-яa-z\-]{1,})?$"))
            {
                FlagFIO = false;
                txbx_fio.BorderBrush = Brushes.Red;

            }
            else
            {
                FlagFIO = true;
                txbx_fio.BorderBrush = Brushes.Green;

            }
        }

        private void txbx_series_number_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_series_number.Text == String.Empty) 
            {
                FlagSeriesNumber = false;
                txbx_series_number.BorderBrush = Brushes.Gray;
            }
            else if (!Regex.IsMatch(txbx_series_number.Text.Trim(), @"^[0-9]{4}\s[0-9]{6}$"))
            {
                FlagSeriesNumber = false;
                txbx_series_number.BorderBrush = Brushes.Red;
            }
            else
            {
                FlagSeriesNumber = true;
                txbx_series_number.BorderBrush = Brushes.ForestGreen;

            }
        }

        private void txbx_phone_number_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_phone_number.Text == String.Empty) 
            {
                FlagPhoneNumber = false;
                txbx_phone_number.BorderBrush = Brushes.Gray;
            }
            else if (!Regex.IsMatch(txbx_phone_number.Text.Trim(), @"^((\+7|7|8)+([0-9]){10})$"))
            {
                FlagPhoneNumber = false;
                txbx_phone_number.BorderBrush = Brushes.Red;
            }
            else
            {
                FlagPhoneNumber = true;
                txbx_phone_number.BorderBrush = Brushes.Green;

            }
        }

        private void txbx_email_SelectionChanged(object sender, RoutedEventArgs e)
        {

            if (txbx_email.Text == String.Empty) 
            { 
                txbx_email.BorderBrush = Brushes.Gray;
            }
            else if (!Regex.IsMatch(txbx_email.Text.Trim(), @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$"))
            {
                FlagEmail = false;
                txbx_email.BorderBrush = Brushes.Red;
            }
            else
            {
                FlagEmail = true;
                txbx_email.BorderBrush = Brushes.Green;

            }
        }
    }
}
