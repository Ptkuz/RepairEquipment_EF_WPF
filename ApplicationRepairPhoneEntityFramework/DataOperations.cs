using Microsoft.EntityFrameworkCore;
using RepaifPhoneDB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationRepairPhoneEntityFramework
{
    public static class DataOperations
    {

        public async static  Task<string> Autorization(string login, string password) 
        {
            using (ApplicationContext db = new ApplicationContext()) 
            {
                await Task.Delay(0);
                var user = db.Employees.Join(db.positions,
                    e => e.ID_Position,
                    p => p.ID_Position,
                    (e,p) => new

                    {
                        Login = e.ID_Employee,
                        Password = e.Password,
                        Position = p.Name_Position


                    }).Where(n => n.Login == login && n.Password == password).FirstOrDefault();
                string position = user.Position;

                return position;
            }
        
        
        }


        public static async Task<Order_Status> GetStatusOrder()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Order_Status? status = await db.order_Statuses.FirstOrDefaultAsync(p => p.Name_Status == "Заказ зарегестрирован");

                return status!;

            }



        }

        public async static Task<ArrayList> GetAllPositions() 
        {
            ArrayList allPositions = new ArrayList();
            using (ApplicationContext db = new ApplicationContext()) 
            {
                await Task.Delay(0);
                var positions = from position in db.positions
                                select position;

                foreach(var position in positions)
                    allPositions.Add(position);

                return allPositions;
            }
        
        }


        public async static Task<ArrayList> GetAllDetails()
        {
            ArrayList allDetails = new ArrayList();
            using (ApplicationContext db = new ApplicationContext())
            {
                await Task.Delay(0);
                var details = from detail in db.stockDetails where detail.QuantityStock >0
                              select detail;


                foreach (var detail in details)
                    allDetails.Add(detail);

                return allDetails;

            }


        }

        public async static Task<ArrayList> GetAllOrdersPerformanceWindow()
        {
            ArrayList allOrders = new ArrayList();
            using (ApplicationContext db = new ApplicationContext())
            {
                await Task.Delay(0);
                var orders = from order in db.Orders
                              where order.ID_Status == 1
                             join employee in db.Employees on order.ID_Employee equals employee.ID_Employee 
                             join client in db.Clients on order.ID_Client equals client.ID_Client
                             join device in db.Devices on order.ID_Device equals device.ID_Device
                             orderby order.Date_Order
                             select new
                             { 
                                 DateOrder = order.Date_Order,
                                 ID_Order = order.ID_Order,
                                 ClientName = client.FIO,
                                 DeviceName = device.Name,
                                 SeriesNumber = device.Serial_Number,
                                 EmployeeName = employee.FIO,
                             };


                foreach (var order in orders)
                    allOrders.Add(order);

                return allOrders;
            }


        }

        public async static Task<ArrayList> GetAllClients()
        {
            ArrayList allClients = new ArrayList();
            using (ApplicationContext db = new ApplicationContext())
            {
                await Task.Delay(0);
                var clients = from client in db.Clients
                              orderby client.DateAdded
                              select client;
                foreach (var client in clients)
                    allClients.Add(client);

                return allClients;
            }

        }

        public async static Task<ArrayList> GetAllDevices()
        {
            ArrayList allDevices = new ArrayList();
            using (ApplicationContext db = new ApplicationContext())
            {
                await Task.Delay(0);
                var devices = from device in db.Devices
                              orderby device.DateAdded
                              select device;
                foreach (var client in devices)
                    allDevices.Add(client);

                return allDevices;
            }


        }

        public async static Task<ArrayList> GetAllEmployees()
        {
            ArrayList allEmployees = new ArrayList();
            using (ApplicationContext db = new ApplicationContext())
            {
                await Task.Delay(0);
                var employees = from e in db.Employees
                                join p in db.positions on e.ID_Position equals p.ID_Position
                                where p.Name_Position == "Мастер" || p.Name_Position == "Старший мастер" || p.Name_Position == "Стажер"
                                select new
                                {
                                    ID_Employee = e.ID_Employee,
                                    FIO = e.FIO,
                                    Position = p.Name_Position,
                                    Phone_Number = e.Phone_Number
                                };

                foreach (var client in employees)
                    allEmployees.Add(client);

                return allEmployees;
            }


        }

        
        public async static Task<ArrayList> SearchOrders(string seachingOrder)
        {
            ArrayList searchOrders = new ArrayList();
            using (ApplicationContext db = new ApplicationContext()) 
            {
                await Task.Delay(0);
                var orders = from order in db.Orders 
                             
                             where order.ID_Status == 1
                             join employee in db.Employees on order.ID_Employee equals employee.ID_Employee 
                             join client in db.Clients on order.ID_Client equals client.ID_Client
                             join device in db.Devices on order.ID_Device equals device.ID_Device
                             orderby order.Date_Order
                             //where EF.Functions.Like(order.ID_Order.ToString(), $"%{seachingOrder}%")
                             //where EF.Functions.Like(employee.FIO!.ToString(), $"%{seachingOrder}%")
                             //where EF.Functions.Like(client.FIO!.ToString(), $"%{seachingOrder}%")
                             //where EF.Functions.Like(device.Name!.ToString(), $"%{seachingOrder}%")
                             //where EF.Functions.Like(device.Serial_Number!.ToString(), $"%{seachingOrder}%")
                             select new
                             {
                                 DateOrder = order.Date_Order,
                                 ID_Order = order.ID_Order.ToString(),
                                 ClientName = client.FIO,
                                 DeviceName = device.Name,
                                 SeriesNumber = device.Serial_Number,
                                 EmployeeName = employee.FIO
                             };

                var search = orders.Where(n=>
                    EF.Functions.Like(n.ID_Order!, $"%{seachingOrder}%") ||
                    EF.Functions.Like(n.ClientName!, $"%{seachingOrder}%") ||
                    EF.Functions.Like(n.DeviceName!, $"%{seachingOrder}%") ||
                    EF.Functions.Like(n.SeriesNumber!, $"%{seachingOrder}%") ||
                    EF.Functions.Like(n.EmployeeName, $"%{seachingOrder}%")
                );

                foreach(var order in search)
                    searchOrders.Add(order);

                return searchOrders;


            }
        }


        public async static Task<ArrayList> SearchClients(string seachingClient)
        {
            ArrayList searchClients = new ArrayList();
            using (ApplicationContext db = new ApplicationContext())
            {
                await Task.Delay(0);
                var clients = db.Clients.OrderBy(p => p.DateAdded)
                    .Where(n =>
                    EF.Functions.Like(n.FIO!, $"%{seachingClient}%") ||
                    EF.Functions.Like(n.Series_Number_Passport!, $"%{seachingClient}%") ||
                    EF.Functions.Like(n.Phone_Number!, $"%{seachingClient}%"));

                foreach (var client in clients)
                    searchClients.Add(client);
                return searchClients;
            }


        }

        public async static Task<ArrayList> SearchDevices(string seachingDevice)
        {
            ArrayList searchDevices = new ArrayList();
            using (ApplicationContext db = new ApplicationContext())
            {
                await Task.Delay(0);
                var devices = db.Devices.OrderBy(p => p.DateAdded)
                    .Where(n =>
                    EF.Functions.Like(n.Name!, $"%{seachingDevice}%") ||
                    EF.Functions.Like(n.Serial_Number!, $"%{seachingDevice}%"));

                foreach (var device in devices)
                    searchDevices.Add(device);
                return searchDevices;
            }


        }


        public async static Task<ArrayList> SearchEmployees(string seachingEmployee)
        {
            ArrayList searchEmployees = new ArrayList();
            using (ApplicationContext db = new ApplicationContext())
            {
                await Task.Delay(0);
                var employees = db.Employees.Join(db.positions,
                    e => e.ID_Position,
                    p => p.ID_Position,
                    (e,p) => new
                    {
                        ID_Employee = e.ID_Employee,
                        FIO = e.FIO,
                        Position = p.Name_Position,
                        Phone_Number = e.Phone_Number

                    }).Where(n=>
                    EF.Functions.Like(n.FIO!, $"%{seachingEmployee}%") ||
                    EF.Functions.Like(n.Position!, $"%{seachingEmployee}%"  
                    )
                    );

                var SearchEmployees = employees.Where(n=>n.Position=="Мастер" || n.Position=="Старший мастер" || n.Position == "Стажер");

                foreach (var employee in SearchEmployees)
                    searchEmployees.Add(employee);
                return searchEmployees;
            }


        }

        


        public async static Task InsertPerformance
            (Guid ID_Perf, string description_rapair, decimal workPrice, decimal detailsPrice,
            decimal discount, decimal finalPrice, DateTime? datePerformance,
            Dictionary<Guid, int> IdQuantityDetails, Guid id_Order)
        {

            using (ApplicationContext db = new ApplicationContext())
            {

                Performance detail = new Performance
                { ID_Performance = ID_Perf, Description_Repair = description_rapair, Work_Price = workPrice, Detail_Price = detailsPrice, Discount = discount, Final_Price = finalPrice, Date_Performance = datePerformance, OrderKey = id_Order };
                db.Add(detail);

                Relationship relationships;

                foreach (var IdQuantityDetailsNum in IdQuantityDetails)
                {

                    relationships = new Relationship() { ID_Performance = ID_Perf, ID_Detail = IdQuantityDetailsNum.Key };
                    db.Add(relationships);
                }


                foreach (var IsQuantityDetailsNum in IdQuantityDetails)
                {



                    var stockDetail = db.stockDetails.
                        Where(c => c.ID_Detail == IsQuantityDetailsNum.Key)
                        .FirstOrDefault();
                    stockDetail.QuantityStock -= IsQuantityDetailsNum.Value;
                    stockDetail.FullPrice = stockDetail.FullPrice - (IsQuantityDetailsNum.Value* stockDetail.Unit_Price);
                    
                    
                    if (IsQuantityDetailsNum.Value == 0)
                    {
                        throw new Exception($"Вы отметили деталь ({stockDetail.Name_Detail}), но не ввели количество!");

                    }
                    if (stockDetail.QuantityStock < 0)
                    {
                        throw new Exception($"На складе нет столько деталей! - ({stockDetail.Name_Detail})");

                    }
                    if (IsQuantityDetailsNum.Value < 0)
                    {
                        throw new Exception($"Количество деталей ({stockDetail.Name_Detail}) не может быть отрицательным! ");

                    }


                }

                // Изменяем статус ордера
                var order = db.Orders.
                    Where(c => c.ID_Order == id_Order)
                    .FirstOrDefault();
                order.ID_Status = 3;

                // Ограничение по дате
                var dateOrder = db.Orders.Where(c => c.ID_Order == id_Order && c.Date_Order > datePerformance).FirstOrDefault();

                if (dateOrder != null) 
                {
                    throw new Exception($"Исполнение не может быть раньше даты регистрации заказа. Заказ: ({dateOrder.Date_Order}) Исполнение: ({datePerformance})");
                }


                
                


                await db.SaveChangesAsync();
            }



        }

        public async static Task InsertOrder(Guid id_Order, Guid idClient, Guid id_Device, string id_Employee, int id_Status, DateTime? dateOrder)
        {

            using (ApplicationContext db = new ApplicationContext())
            {
                Order order = new Order() { ID_Order = id_Order, ID_Client = idClient, ID_Device = id_Device, ID_Employee = id_Employee, ID_Status = id_Status, Date_Order = dateOrder };
                db.Add(order);
                await db.SaveChangesAsync();


            }

        }

        public async static Task InsertEmployee(string id_Employee, string password_employee, string fio, int id_position, string series_number_passport, string address, string phone_Number, DateTime? employment_Date) 
        {

            using (ApplicationContext db = new ApplicationContext()) 
            {
                Employee employee = new Employee() { ID_Employee = id_Employee, Password = password_employee, FIO = fio, ID_Position = id_position, Series_Number_Password = series_number_passport, Address = address, Phone_Number = phone_Number, EmploymentDate = employment_Date };
                db.Add(employee);
                await db.SaveChangesAsync();
            }
        
        }

        public async static Task InsertDetails(Guid id_Detail, string name_detail, decimal unit_Price, int quantity, decimal full_Price) 
        {
            using (ApplicationContext db = new ApplicationContext()) 
            { 
                StockDetails stockDetails = new StockDetails() { ID_Detail = id_Detail, Name_Detail = name_detail, Unit_Price = unit_Price, QuantityStock = quantity, FullPrice = full_Price };
                db.Add(stockDetails);
                await db.SaveChangesAsync();
            }
        
        
        }





    }
}
