using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для ViewEmployeeWindow.xaml
    /// </summary>
    public partial class ViewEmployeeWindow : Window
    {
        ArrayList allEmployees = new ArrayList();
        ArrayList allPosition = new ArrayList();

        bool flagPassword = false;
        bool flagFio = false;
        bool flagSeriesNumber = false;
        bool flagAddress = false;
        bool flagPhoneNumber = false;

        public bool FlagPassword 
        {
            get { return flagPassword; }
            set { flagPassword = value;
                if (flagPassword && flagFio  && flagSeriesNumber && flagAddress && flagPhoneNumber)
                    btn_Update_Device.IsEnabled = true;
                else
                    btn_Update_Device.IsEnabled = false;
            }
        
        }

        public bool FlagFio
        {
            get { return flagFio; }
            set
            {
                flagFio = value;
                if (flagPassword && flagFio && flagSeriesNumber && flagAddress && flagPhoneNumber)
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
                if (flagPassword && flagFio  && flagSeriesNumber && flagAddress && flagPhoneNumber)
                    btn_Update_Device.IsEnabled = true;
                else
                    btn_Update_Device.IsEnabled = false;
            }

        }

        public bool FlagAddress
        {
            get { return flagAddress; }
            set
            {
                flagAddress = value;
                if (flagPassword && flagFio && flagSeriesNumber && flagAddress && flagPhoneNumber)
                    btn_Update_Device.IsEnabled = true;
                else
                    btn_Update_Device.IsEnabled = false;
            }

        }

        public bool FlagPhoneNumber
        {
            get { return flagPhoneNumber; }
            set
            {
                flagPhoneNumber = value;
                if (flagPassword && flagFio && flagSeriesNumber && flagAddress && flagPhoneNumber)
                    btn_Update_Device.IsEnabled = true;
                else
                    btn_Update_Device.IsEnabled = false;
            }

        }


        public string ID_Employee { get; set; }
        public string Password { get; set; }
        public string FIO { get; set; }
        public int Position { get; set; }
        public string PositionName { get; set; }
        public string SeriesNumber { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }


        public ViewEmployeeWindow()
        {
            InitializeComponent();
            GetAllEmployee();
            async void GetAllEmployee() 
            {
                allEmployees = await DataOperations.GetAllEmployeesView();
                allPosition = await DataOperations.GetAllPositions();
                dataGridEmployees.ItemsSource = allEmployees;
                cmbx_position.ItemsSource = allPosition;
            
            }
        }

        private async void btn_Add_Employee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee();
            bool? result = addEmployee.ShowDialog();
            if (result.HasValue && result.Value) 
            { 
                dataGridEmployees.ItemsSource = await DataOperations.GetAllEmployeesView();
                MessageBox.Show("Новый сотрудник добавлен.", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private async void txbx_search_employee_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string search = txbx_search_employee.Text;
            dataGridEmployees.ItemsSource = await DataOperations.SearchEmployeesView(search);
        }

        private void dataGridEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = dataGridEmployees.SelectedItem;
            if (item != null)
            {
                string ID_Device = (dataGridEmployees.SelectedCells[0].Column.GetCellContent(item) as TextBlock)!.Text;
                string password = (dataGridEmployees.SelectedCells[1].Column.GetCellContent(item) as TextBlock)!.Text;
                string fio = (dataGridEmployees.SelectedCells[2].Column.GetCellContent(item) as TextBlock)!.Text;
                string position = (dataGridEmployees.SelectedCells[3].Column.GetCellContent(item) as TextBlock)!.Text;
                string SeriesNumber = (dataGridEmployees.SelectedCells[4].Column.GetCellContent(item) as TextBlock)!.Text;
                string address = (dataGridEmployees.SelectedCells[5].Column.GetCellContent(item) as TextBlock)!.Text;
                string PhoneNumber = (dataGridEmployees.SelectedCells[6].Column.GetCellContent(item) as TextBlock)!.Text;

                txbx_Id_Employee.Text = ID_Device;
                txbx_Password.Text = password;
                txbx_FIO.Text = fio;
                txbx_SeriesNumber.Text = SeriesNumber;
                txbx_address.Text = address;
                txbx_phoneNumber.Text = PhoneNumber;
                cmbx_position.Text = position;
            }
            else 
            {
                txbx_Id_Employee.Text = String.Empty;
                txbx_Password.Text = String.Empty;
                txbx_FIO.Text = String.Empty;
                txbx_SeriesNumber.Text = String.Empty;
                txbx_address.Text = String.Empty;
                txbx_phoneNumber.Text = String.Empty;
                cmbx_position.Text = String.Empty;
                txbx_search_employee.Text = String.Empty;

            }
        }

        private async void btn_Update_Device_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ID_Employee = txbx_Id_Employee.Text;
                Password = txbx_Password.Text;
                FIO = txbx_FIO.Text;
                SeriesNumber = txbx_SeriesNumber.Text;
                Address = txbx_address.Text;
                PhoneNumber = txbx_phoneNumber.Text;
                Position = Int32.Parse(cmbx_position.SelectedValue.ToString());
                PositionName = cmbx_position.Text;
                await DataOperations.UpdateEmployee(ID_Employee, Password, FIO, SeriesNumber, Address, PhoneNumber, Position);
                dataGridEmployees.ItemsSource = await DataOperations.GetAllEmployeesView();
                if(await SendEmail.SendEmailAsync(ID_Employee, "Пиьсмо от Сервсисного центра", SendEmail.UpdateEmployeeMail(FIO, PositionName, ID_Employee, Password, SeriesNumber, Address, PhoneNumber)))
                    MessageBox.Show("Письмо сотруднику успешно отправлено!", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("При отправке письма произошла ошибка. Проверьте интернет подключение!", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show($"Сотрудник {ID_Employee} обновлен.", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Information);
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
                ID_Employee = txbx_Id_Employee.Text;
                FIO = txbx_FIO.Text;
                await DataOperations.RemoveEmployee(ID_Employee);
                dataGridEmployees.ItemsSource = await DataOperations.GetAllEmployeesView();
                MessageBox.Show($"Сотрудник {FIO} удален!", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void txbx_Id_Employee_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if(txbx_Id_Employee.Text != String.Empty)
                btn_Delete_Device.IsEnabled = true;
            else
                btn_Delete_Device.IsEnabled=false;
        }

        private void txbx_Password_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_Password.Text == String.Empty)
            {
                FlagPassword = false;
                txbx_Password.BorderBrush = Brushes.Gray;

            }
            else if (!Regex.IsMatch(txbx_Password.Text.Trim(), @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$"))
            {
                FlagPassword = false;
                txbx_Password.BorderBrush = Brushes.Red;
            }
            else
            {
                FlagPassword = true;
                txbx_Password.BorderBrush = Brushes.Green;

            }

        }

        private void txbx_FIO_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_FIO.Text == String.Empty) 
            {
                FlagFio = false;
                txbx_FIO.BorderBrush = Brushes.Gray;

            }
            else if (!Regex.IsMatch(txbx_FIO.Text.Trim(), @"^[А-ЯA-Z][а-яa-z\-]{0,}\s[А-ЯA-Z][а-яa-z\-]{1,}(\s[А-ЯA-Z][а-яa-z\-]{1,})?$"))
            {
                FlagFio = false;
                txbx_FIO.BorderBrush = Brushes.Red;

            }
            else
            {
                FlagFio = true;
                txbx_FIO.BorderBrush = Brushes.Green;

            }
        }

        private void txbx_SeriesNumber_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_SeriesNumber.Text == String.Empty) 
            {
                FlagSeriesNumber = false;
                txbx_SeriesNumber.BorderBrush = Brushes.Gray;

            }
            else if (!Regex.IsMatch(txbx_SeriesNumber.Text.Trim(), @"^[0-9]{4}\s[0-9]{6}$"))
            {
                FlagSeriesNumber = false;
                txbx_SeriesNumber.BorderBrush = Brushes.Red;

            }
            else
            {
                FlagSeriesNumber = true;
                txbx_SeriesNumber.BorderBrush = Brushes.Green;

            }
        }

        private void txbx_address_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_Password.Text == String.Empty)
            {
                FlagAddress = false;
                txbx_address.BorderBrush = Brushes.Gray;
            }
            else
            {
                FlagAddress = true;
                txbx_address.BorderBrush = Brushes.Green;
            }
        }

        private void txbx_phoneNumber_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_phoneNumber.Text == String.Empty)
            {
                FlagPhoneNumber = false;
                txbx_phoneNumber.BorderBrush = Brushes.Gray;

            }
            else if (!Regex.IsMatch(txbx_phoneNumber.Text.Trim(), @"^((\+7|7|8)+([0-9]){10})$"))
            {
                FlagPhoneNumber = false;
                txbx_phoneNumber.BorderBrush = Brushes.Red;
            }
            else
            {
                FlagPhoneNumber = true;
                txbx_phoneNumber.BorderBrush = Brushes.Green;

            }
        }
    }
}
