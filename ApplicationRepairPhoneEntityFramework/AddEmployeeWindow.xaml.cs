using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;

namespace ApplicationRepairPhoneEntityFramework
{
    /// <summary>
    /// Логика взаимодействия для AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {

        bool flagFIO = false;
        bool flagPosition = false;
        bool flagSeriesNumber = false;
        bool flagAddress = false;
        bool flagPhoneNumber = false;
        bool flagLogin = false;
        bool flagPassword = false;



        ArrayList arrayPositions = new ArrayList();

        public bool FlagFIO
        {
            get { return flagFIO; }
            set
            {
                flagFIO = value;
                if (flagFIO && flagPosition && flagSeriesNumber && flagAddress && flagPhoneNumber && flagLogin && flagPassword)
                {
                    btn_Add_Employee.IsEnabled = true;
                }
                else
                {
                    btn_Add_Employee.IsEnabled = false;

                }
            }

        }

        public bool FlagPosition
        {
            get { return flagPosition; }
            set { flagPosition = value; }

        }

        public bool FlagSeriesNumber
        {
            get { return flagSeriesNumber; }
            set
            {
                flagSeriesNumber = value;
                if (flagFIO && flagPosition && flagSeriesNumber && flagAddress && flagPhoneNumber && flagLogin && flagPassword)
                {
                    btn_Add_Employee.IsEnabled = true;
                }
                else
                {
                    btn_Add_Employee.IsEnabled = false;

                }
            }

        }

        public bool FlagAddress
        {
            get { return flagAddress; }
            set
            {
                flagAddress = value;
                if (flagFIO && flagPosition && flagSeriesNumber && flagAddress && flagPhoneNumber && flagLogin && flagPassword)
                {
                    btn_Add_Employee.IsEnabled = true;
                }
                else
                {
                    btn_Add_Employee.IsEnabled = false;

                }
            }

        }

        public bool FlagPhoneNumber
        {
            get { return flagPhoneNumber; }
            set
            {
                flagPhoneNumber = value;
                if (flagFIO && flagPosition && flagSeriesNumber && flagAddress && flagPhoneNumber && flagLogin && flagPassword)
                {
                    btn_Add_Employee.IsEnabled = true;
                }
                else
                {
                    btn_Add_Employee.IsEnabled = false;

                }
            }

        }

        public bool FlagLogin
        {
            get { return flagLogin; }
            set
            {
                flagLogin = value;
                if (flagFIO && flagPosition && flagSeriesNumber && flagAddress && flagPhoneNumber && flagLogin && flagPassword)
                {
                    btn_Add_Employee.IsEnabled = true;
                }
                else
                {
                    btn_Add_Employee.IsEnabled = false;

                }
            }

        }

        public bool FlagPassword
        {
            get { return flagPassword; }
            set
            {
                flagPassword = value;
                if (flagFIO && flagPosition && flagSeriesNumber && flagAddress && flagPhoneNumber && flagLogin && flagPassword)
                {
                    btn_Add_Employee.IsEnabled = true;
                }
                else
                {
                    btn_Add_Employee.IsEnabled = false;

                }
            }

        }



        public string ID_Employee { get; set; }
        string fio;
        public string Fio
        {
            get { return fio; }
            set { fio = value; }
        }


        public string password_Employee;
        public string Password_Employee
        {
            get { return password_Employee; }
            set { password_Employee = value; }

        }

        int position;
        public int Position
        {
            get { return position; }
            set { position = value; }

        }
        string PositionName { get; set; }
        string seriesNumber;
        public string SeriesNumber
        {
            get { return seriesNumber; }
            set { seriesNumber = value; }
        }

        string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        string numberPhone;
        public string NumberPhone
        {
            get { return numberPhone; }
            set { numberPhone = value; }

        }
        public DateTime? EmploymentDate { get; set; }
        public AddEmployee()
        {
            InitializeComponent();


            GetPositions();
            async void GetPositions()
            {
                arrayPositions = await DataOperations.GetActivePositions();

                cmbx_Position_Employee.ItemsSource = arrayPositions;


            }
        }

        private async void btn_Add_Employee_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ID_Employee = txbx_Login_Employee.Text.Trim();
                Password_Employee = txbx_Passwor_Employee.Text.Trim();
                Fio = txbx_FIO_Employee.Text.Trim();

                Position = Int32.Parse(cmbx_Position_Employee.SelectedValue.ToString()!);
                PositionName = cmbx_Position_Employee.Text;
                SeriesNumber = txbx_Series_Number.Text.Trim();
                Address = txbx_Address.Text.Trim();
                NumberPhone = txbx_Phone_Number.Text.Trim();
                EmploymentDate = DateTime.Now;
                if (await DataOperations.InsertEmployee(ID_Employee, Password_Employee, Fio, Position, SeriesNumber, Address, NumberPhone, EmploymentDate))
                {
                    if (await SendEmail.SendEmailAsync(ID_Employee, "Пиьсмо от Сервсисного центра", SendEmail.AddEmployeeMail(Fio, PositionName, ID_Employee, Password_Employee, SeriesNumber, Address, NumberPhone)))
                        MessageBox.Show("Письмо сотруднику успешно отправлено!", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show("При отправке письма произошла ошибка. Проверьте интернет подключение!", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.DialogResult = true;
                }
                else
                    this.DialogResult = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void txbx_FIO_Employee_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_FIO_Employee.Text == String.Empty) 
            {
                FlagFIO = false;
                lb_FIO.Opacity = 0;
                lb_FIO.Content = "";
            }
            else if (!Regex.IsMatch(txbx_FIO_Employee.Text.Trim(), @"^[А-ЯA-Z][а-яa-z\-]{0,}\s[А-ЯA-Z][а-яa-z\-]{1,}(\s[А-ЯA-Z][а-яa-z\-]{1,})?$"))
            {
                FlagFIO = false;
                lb_FIO.Opacity = 1;
                lb_FIO.Content = "Некорректное ФИО";
                lb_FIO.Background = Brushes.Red;

            }
            else
            {
                FlagFIO = true;
                lb_FIO.Opacity = 1;
                lb_FIO.Content = "Данные корректны";
                lb_FIO.Background = Brushes.Green;

            }
        }

        private void cmbx_Position_Employee_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            FlagPosition = true;
        }

        private void txbx_Series_Number_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_Series_Number.Text == String.Empty) 
            {
                FlagSeriesNumber = false;

                lb_SeriesNumber.Opacity = 0;
                lb_SeriesNumber.Content = "";
            }
            else if (!Regex.IsMatch(txbx_Series_Number.Text.Trim(), @"^[0-9]{4}\s[0-9]{6}$"))
            {
                FlagSeriesNumber = false;
                lb_SeriesNumber.Opacity = 1;
                lb_SeriesNumber.Content = "Некорректная СИ пасспорта";
                lb_SeriesNumber.Background = Brushes.Red;
            }
            else
            {
                FlagSeriesNumber = true;
                lb_SeriesNumber.Opacity = 1;
                lb_SeriesNumber.Content = "Данные корректны";
                lb_SeriesNumber.Background = Brushes.Green;

            }
        }

        private void txbx_Address_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_Address.Text == String.Empty)
            {
                txbx_Address.MaxLength = 50;

                FlagAddress = false;
                lb_Address.Opacity = 0;
                lb_Address.Content = "";
            }
            else
            {
                FlagAddress = true;
                lb_Address.Opacity = 1;
                lb_Address.Content = "Данные корректны";
                lb_Address.Background = Brushes.Green;

            }
        }

        private void txbx_Phone_Number_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_Phone_Number.Text == String.Empty) 
            {
                FlagPhoneNumber = false;
                lb_PhoneNumber.Content = "";
                lb_PhoneNumber.Opacity = 0;
            }
            else if (!Regex.IsMatch(txbx_Phone_Number.Text.Trim(), @"^((\+7|7|8)+([0-9]){10})$"))
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

        private void txbx_Login_Employee_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_Login_Employee.Text == String.Empty) 
            {
                FlagLogin = false;
                lb_Login.Content = "";
                lb_Login.Opacity = 0;
            }
            else if (!Regex.IsMatch(txbx_Login_Employee.Text.Trim(), @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$"))
            {
                FlagLogin = false;
                lb_Login.Opacity = 1;
                lb_Login.Content = "Некорректный электронный адрес";
                lb_Login.Background = Brushes.Red;
            }
            else
            {
                FlagLogin = true;
                lb_Login.Opacity = 1;
                lb_Login.Content = "Данные корректны";
                lb_Login.Background = Brushes.Green;

            }
        }

        private void txbx_Passwor_Employee_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_Passwor_Employee.Text == String.Empty) 
            {
                FlagPassword = false;
                lb_Password.Content = "";
                lb_Password.Opacity = 0;
            }
            else if (!Regex.IsMatch(txbx_Passwor_Employee.Text.Trim(), @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$"))
            {
                FlagPassword = false;
                lb_Password.Opacity = 1;
                lb_Password.Content = "Некорректный пароль";
                lb_Password.Background = Brushes.Red;
            }
            else
            {
                FlagPassword = true;
                lb_Password.Opacity = 1;
                lb_Password.Content = "Данные корректны";
                lb_Password.Background = Brushes.Green;

            }
        }
    }
}
