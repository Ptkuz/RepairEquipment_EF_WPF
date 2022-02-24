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



        ArrayList arrayPositions = new ArrayList();

        public bool FlagFIO
        {
            get { return flagFIO; }
            set { 
                flagFIO = value;
                if (flagFIO && flagPosition && flagSeriesNumber && flagAddress && flagPhoneNumber)
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
            set { 
                flagSeriesNumber = value;
                if (flagFIO && flagPosition && flagSeriesNumber && flagAddress && flagPhoneNumber)
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
            set { 
                flagAddress = value;
                if (flagFIO && flagPosition && flagSeriesNumber && flagAddress && flagPhoneNumber)
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
            set { 
                flagPhoneNumber = value;
                if (flagFIO && flagPosition && flagSeriesNumber && flagAddress && flagPhoneNumber)
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
                arrayPositions = await DataOperations.GetAllPositions();

                cmbx_Position_Employee.ItemsSource = arrayPositions;
            
            
            }
        }

        private async void btn_Add_Employee_Click(object sender, RoutedEventArgs e)
        {
            ID_Employee = txbx_Login_Employee.Text.Trim();
            Password_Employee = txbx_Passwor_Employee.Text.Trim();
            Fio = txbx_FIO_Employee.Text.Trim();
            
            Position = Int32.Parse(cmbx_Position_Employee.SelectedValue.ToString()!);
            SeriesNumber = txbx_Series_Number.Text.Trim();
            Address = txbx_Address.Text.Trim();
            NumberPhone = txbx_Phone_Number.Text.Trim();
            EmploymentDate = DateTime.Now;
            await DataOperations.InsertEmployee(ID_Employee, Password_Employee, Fio, Position, SeriesNumber, Address, NumberPhone, EmploymentDate);
            MessageBox.Show("Новый сотрудник добавлен", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void txbx_FIO_Employee_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_FIO_Employee.Text == String.Empty || !Regex.IsMatch(txbx_FIO_Employee.Text.Trim(), @"^[А-ЯA-Z][а-яa-z\-]{0,}\s[А-ЯA-Z][а-яa-z\-]{1,}(\s[А-ЯA-Z][а-яa-z\-]{1,})?$"))
            {
                FlagFIO = false;
                lb_FIO.Content = "Некорректное ФИО";
                lb_FIO.Background = Brushes.Red;

            }
            else 
            {
                FlagFIO = true;
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
            if (txbx_Series_Number.Text == String.Empty || !Regex.IsMatch(txbx_Series_Number.Text.Trim(), @"^[0-9]{4}\s[0-9]{6}$"))
            {
                FlagSeriesNumber = false;
                lb_SeriesNumber.Content = "Некорректная СИ пасспорта";
                lb_SeriesNumber.Background = Brushes.Red;
            }
            else 
            {
                FlagSeriesNumber = true;
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
                lb_Address.Content = "Некорректный адрес";
                lb_Address.Background = Brushes.Red;
            }
            else
            {
                FlagAddress = true;
                lb_Address.Content = "Данные корректны";
                lb_Address.Background = Brushes.Green;

            }
        }

        private void txbx_Phone_Number_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_Phone_Number.Text == String.Empty || !Regex.IsMatch(txbx_Phone_Number.Text.Trim(), @"^((\+7|7|8)+([0-9]){10})$"))
            {
                FlagPhoneNumber = false;
                lb_PhoneNumber.Content = "Некорректный номер телефона";
                lb_PhoneNumber.Background = Brushes.Red;
            }
            else
            {
                FlagPhoneNumber = true;
                lb_PhoneNumber.Content = "Данные корректны";
                lb_PhoneNumber.Background = Brushes.Green;

            }
        }
    }
}
