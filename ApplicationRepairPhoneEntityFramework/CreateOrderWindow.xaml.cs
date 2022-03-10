using RepaifPhoneDB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ApplicationRepairPhoneEntityFramework
{

    public partial class CreateOrderWindow : Window
    {
        ArrayList arrayClients = new ArrayList();
        ArrayList arrayDevices = new ArrayList();
        ArrayList arrayEmployees = new ArrayList();

        public Guid ID_Order { get; set; }

        public Guid ID_Client { get; set; }
        public Guid ID_Device { get; set; }
        public string ID_Employee { get; set; }
        public int ID_Status { get; set; }
        public string Email { get; set; }
        public string FioClient { get; set; }
        public string Sereis_Number_Passport { get; private set; }
        public string PhoneNumberClient { get; private set; }
        public string Device_Name { get; private set; }
        public string Serial_Number { get; private set; }
        public string FioEmployee { get; private set; }
        public string Position { get; private set; }
        public string PhoneNumberEmployee { get; private set; }
        public DateTime? DateOrder { get; set; }



        public CreateOrderWindow()
        {
            InitializeComponent();
            ID_Order = Guid.NewGuid();
            txbx_ID_Order.Text = ID_Order.ToString();
            GetData();
            async void GetData()
            {
                arrayClients = await DataOperations.GetAllClients();
                arrayDevices = await DataOperations.GetAllDevices();
                arrayEmployees = await DataOperations.GetAllEmployees();

                dataGridClients.ItemsSource = arrayClients;
                dataGridDevices.ItemsSource = arrayDevices;
                dataGridEmployees.ItemsSource = arrayEmployees;


            }
        }

        private async void btn_Add_Order_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object itemClient = dataGridClients.SelectedItem;
                object itemDevice = dataGridDevices.SelectedItem;
                object itemEmployee = dataGridEmployees.SelectedItem;

                if (dataGridClients.SelectedItem == null)
                {
                    throw new Exception("Вы не выбрали клиента");

                }
                else if (dataGridDevices.SelectedItem == null)
                {
                    throw new Exception("Вы не выбрали оборудование");

                }
                else if (dataGridEmployees.SelectedItem == null)
                {
                    throw new Exception("Вы не выбрали сотрудника, который будет производить ремонт");

                }
                else
                {

                    ID_Client = Guid.Parse((dataGridClients.SelectedCells[0].Column.GetCellContent(itemClient) as TextBlock)!.Text);
                    ID_Device = Guid.Parse((dataGridDevices.SelectedCells[0].Column.GetCellContent(itemDevice) as TextBlock)!.Text);
                    ID_Employee = (dataGridEmployees.SelectedCells[0].Column.GetCellContent(itemEmployee) as TextBlock)!.Text;
                    Email = (dataGridClients.SelectedCells[4].Column.GetCellContent(itemClient) as TextBlock)!.Text;
                    FioClient = (dataGridClients.SelectedCells[1].Column.GetCellContent(itemClient) as TextBlock)!.Text;
                    Sereis_Number_Passport = (dataGridClients.SelectedCells[2].Column.GetCellContent(itemClient) as TextBlock)!.Text;
                    PhoneNumberClient = (dataGridClients.SelectedCells[3].Column.GetCellContent(itemClient) as TextBlock)!.Text;
                    Device_Name = (dataGridDevices.SelectedCells[1].Column.GetCellContent(itemDevice) as TextBlock)!.Text;
                    Serial_Number = (dataGridDevices.SelectedCells[2].Column.GetCellContent(itemDevice) as TextBlock)!.Text;
                    FioEmployee = (dataGridEmployees.SelectedCells[1].Column.GetCellContent(itemEmployee) as TextBlock)!.Text;
                    Position = (dataGridEmployees.SelectedCells[2].Column.GetCellContent(itemEmployee) as TextBlock)!.Text;
                    PhoneNumberEmployee = (dataGridEmployees.SelectedCells[3].Column.GetCellContent(itemEmployee) as TextBlock)!.Text;
                    Order_Status status = await DataOperations.GetStatusOrder();
                    ID_Status = status.ID_Status;
                    DateOrder = DateTime.Now;

                    if (await DataOperations.InsertOrder(ID_Order, ID_Client, ID_Device, ID_Employee, ID_Status, DateOrder))
                    {

                        var document = new CreateDocuments(@"Шаблон заказа клиента.docx", @"Документы заказы\Заказ.docx");

                        var items = new Dictionary<string, string>
                        {
                            { "ID_Order", ID_Order.ToString()},
                            { "Date_Order", DateOrder.ToString()},
                            { "Client_Fio", FioClient},
                            { "Series_Number_Passport",Sereis_Number_Passport },
                            { "Phone_Number_Client", PhoneNumberClient},
                            { "Email", Email},
                            { "Device_Name", Device_Name},
                            { "SerialNumber", Serial_Number},
                            { "Employee_Master", FioEmployee},
                            { "Position", Position},
                            { "Phone_Number_Employee", PhoneNumberEmployee}
                        };

                        document.Process(items);


                        if (Email != String.Empty)
                            if(await SendEmail.SendEmailAsync(Email, "Пиьсмо от Сервсисного центра", SendEmail.ChangeStatusOrder(FioClient, txbx_ID_Order.Text, 
                                "Заказ загерестрирован. \n К письму прикреплена электронная копия документа вашего заказа"), true, @"Документы заказы\Заказ.docx"))
                                MessageBox.Show("Письмо клиенту успешно отправлено!", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Information);
                            else
                                MessageBox.Show("При отправке письма произошла ошибка. Проверьте интернет подключение!", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Error);
                        this.DialogResult = true;
                    }
                    else
                        this.DialogResult = false;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Error);


            }






        }

        private async void txbx_searchClient_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string search = txbx_searchClient.Text;
            dataGridClients.ItemsSource = await DataOperations.SearchClients(search);
        }

        private async void txbx_searchDevice_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string search = txbx_searchDevice.Text;
            dataGridDevices.ItemsSource = await DataOperations.SearchDevices(search);
        }

        private async void txbx_searchEmployee_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string search = txbx_searchEmployee.Text;
            dataGridEmployees.ItemsSource = await DataOperations.SearchEmployees(search);

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow addClientWindow = new AddClientWindow();
            bool? result = addClientWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {
                dataGridClients.ItemsSource = await DataOperations.GetAllClients();
                MessageBox.Show("Новый клиент успешно добавлен", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Клиент не добавлен", "Приложение СЕРВИСНЫЙ ЦЕНТР: Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddDeviceWindow addDeviceWindow = new AddDeviceWindow();
            bool? result = addDeviceWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {
                dataGridDevices.ItemsSource = await DataOperations.GetAllDevices();
                MessageBox.Show("Новое оборудование успешно добавлено", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Оборудование не добавлено", "Приложение СЕРВИСНЫЙ ЦЕНТР: Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
