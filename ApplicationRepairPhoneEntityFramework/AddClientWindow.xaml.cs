using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;

namespace ApplicationRepairPhoneEntityFramework
{
    /// <summary>
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {

        bool flagFIO;
        bool flagSeriseNumber;
        bool flagPhoneNumber;
        bool flagEmail = true;

        public bool FlagFIO
        {
            get { return flagFIO; }
            set
            {
                flagFIO = value;
                if (flagFIO && flagSeriseNumber && flagPhoneNumber && flagEmail)
                    btn_Add_Client.IsEnabled = true;
                else
                    btn_Add_Client.IsEnabled = false;
            }
        }
        public bool FlagSeriseNumber
        {
            get { return flagSeriseNumber; }
            set
            {
                flagSeriseNumber = value;
                if (flagFIO && flagSeriseNumber && flagPhoneNumber && flagEmail)
                    btn_Add_Client.IsEnabled = true;
                else
                    btn_Add_Client.IsEnabled = false;
            }
        }
        public bool FlagPhoneNumber
        {
            get { return flagPhoneNumber; }
            set
            {
                flagPhoneNumber = value;
                if (flagFIO && flagSeriseNumber && flagPhoneNumber && flagEmail)
                    btn_Add_Client.IsEnabled = true;
                else
                    btn_Add_Client.IsEnabled = false;
            }
        }
        public bool FlagEmail 
        {

            get { return flagEmail; }
            set
            {
                flagEmail = value;
                if (flagFIO && flagSeriseNumber && flagPhoneNumber && flagEmail)
                    btn_Add_Client.IsEnabled = true;
                else
                    btn_Add_Client.IsEnabled = false;
            }
        }


        public Guid ID_Client { get; set; }
        public string FIO { get; set; }
        public string SeriesNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? DateAdded { get; set; }

        public AddClientWindow()
        {
            InitializeComponent();
            ID_Client = Guid.NewGuid();
            txbx_ID_Client.Text = ID_Client.ToString();
        }

        private async void btn_Add_Client_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FIO = txbx_Name_Client.Text;
                SeriesNumber = txbx_SeriesNumber.Text;
                PhoneNumber = txbx_PhoneNumber.Text;
                Email = txbx_Email.Text;
                DateAdded = DateTime.Now;



                if (await DataOperations.InsertClient(ID_Client, FIO, SeriesNumber, PhoneNumber, Email, DateAdded)) 
                    this.DialogResult = true;
                else
                    this.DialogResult = false;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        private void txbx_Name_Client_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_Name_Client.Text == String.Empty) 
            {
                FlagFIO = false;
                lb_Name.Opacity = 0;
            }
            else if (!Regex.IsMatch(txbx_Name_Client.Text.Trim(), @"^[А-ЯA-Z][а-яa-z\-]{0,}\s[А-ЯA-Z][а-яa-z\-]{1,}(\s[А-ЯA-Z][а-яa-z\-]{1,})?$"))
            {
                FlagFIO = false;
                lb_Name.Opacity = 1;
                lb_Name.Content = "Некорректное ФИО";
                lb_Name.Background = Brushes.Red;

            }
            else
            {
                FlagFIO = true;
                lb_Name.Opacity = 1;
                lb_Name.Content = "Данные корректны";
                lb_Name.Background = Brushes.Green;

            }
            
        }

        private void txbx_SeriesNumber_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_SeriesNumber.Text == String.Empty) 
            {
                FlagSeriseNumber = false;
                lb_SeriesNumber.Opacity = 0;
                lb_SeriesNumber.Content = "";
            }
            else if (!Regex.IsMatch(txbx_SeriesNumber.Text.Trim(), @"^[0-9]{4}\s[0-9]{6}$"))
            {
                FlagSeriseNumber = false;
                lb_SeriesNumber.Opacity = 1;
                lb_SeriesNumber.Content = "Некорректная СИ пасспорта";
                lb_SeriesNumber.Background = Brushes.Red;
            }
            else
            {
                FlagSeriseNumber = true;
                lb_SeriesNumber.Opacity = 1;
                lb_SeriesNumber.Content = "Данные корректны";
                lb_SeriesNumber.Background = Brushes.Green;

            }
        }

        private void txbx_PhoneNumber_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_PhoneNumber.Text == String.Empty) 
            {
                FlagPhoneNumber = false;
                lb_PhoneNumber.Opacity = 0;
                lb_PhoneNumber.Content = "";

            }
            else if (!Regex.IsMatch(txbx_PhoneNumber.Text.Trim(), @"^((\+7|7|8)+([0-9]){10})$"))
            {
                FlagPhoneNumber = false;
                lb_PhoneNumber.Opacity = 1;
                lb_PhoneNumber.Content = "Некорректный номер телефона";
                lb_PhoneNumber.Background = Brushes.Red;
            }
            else
            {
                FlagPhoneNumber = true;
                lb_PhoneNumber.Opacity = 1;
                lb_PhoneNumber.Content = "Данные корректны";
                lb_PhoneNumber.Background = Brushes.Green;

            }
        }

        private void txbx_Email_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_Email.Text == String.Empty) 
            {
                FlagEmail = false;
                lb_Email.Opacity = 0;
                lb_Email.Content = "";
            }
            else if (!Regex.IsMatch(txbx_Email.Text.Trim(), @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$"))
            {
                FlagEmail = false;
                lb_Email.Opacity = 1;
                lb_Email.Content = "Некорректный Email";
                lb_Email.Background = Brushes.Red;
            }
            else
            {
                FlagEmail = true;
                lb_Email.Opacity = 1;
                lb_Email.Content = "Данные корректны";
                lb_Email.Background = Brushes.Green;

            }
        }
    }
}
