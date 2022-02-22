using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ApplicationRepairPhoneEntityFramework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (ApplicationContext db = new ApplicationContext())
            {
                ArrayList arrayClients = new ArrayList();
                ArrayList arrayEmployee = new ArrayList();
                ArrayList arrayOrders = new ArrayList();

                var employees = db.Employees.Join(db.positions,
                    e => e.ID_Position,
                    p => p.ID_Position,
                    (e, p) => new
                    {
                        FIO = e.FIO,
                        Series_Number_Password = e.Series_Number_Password,
                        Name_Position = p.Name_Position
                    });

                foreach (var employee in employees) 
                { 
                    arrayEmployee.Add(employee);
                }
                DataGridEmployees.ItemsSource = arrayEmployee;





                var clients = from client in db.Clients 
                              select client;


                foreach (var client in clients)
                {
                    arrayClients.Add(client);

                }
                DataGridClients.ItemsSource = arrayClients;


                var orders = from order in db.Orders
                             join device in db.Devices on order.ID_Device equals device.ID_Device
                             join client in db.Clients on order.ID_Client equals client.ID_Client
                             join employee in db.Employees on order.ID_Employee equals employee.ID_Employee
                             join status in db.order_Statuses on order.ID_Status equals status.ID_Status
                             join performance in db.performances on order.ID_Performance equals performance.ID_Performance
                             select new
                             {
                                 Name_Device = device.Name,
                                 FIO_Client = client.FIO,
                                 FIO_Employee = employee.FIO,
                                 Status = status.Name_Status,
                                 PerformanceRepair = performance.Description_Repair,
                                 PerformanceDate = performance.Date_Performance,
                                 OrderDate = order.Date_Order
                             };

                foreach (var order in orders) 
                { 
                    arrayOrders.Add(order);
                }
                DataGridOrders.ItemsSource = arrayOrders;







            }
        }


       

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            { 
            
                db.SaveChanges();
            }
            
        }
    }
}
