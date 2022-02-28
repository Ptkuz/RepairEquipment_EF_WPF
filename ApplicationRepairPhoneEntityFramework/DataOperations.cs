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
        public static string[] Autorization(string login, string password)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var user = db.Employees.Join(db.positions,
                    e => e.ID_Position,
                    p => p.ID_Position,
                    (e, p) => new

                    {
                        Login = e.ID_Employee,
                        Password = e.Password,
                        Position = p.Name_Position,
                        FIO = e.FIO


                    }).Where(n => n.Login == login && n.Password == password).FirstOrDefault();
                string[] dataEmployee = new string[2] { user.Position, user.FIO };

                return dataEmployee;
            }


        }

        public async static Task<ArrayList> GetAllOrdersViewAllOrdersWindow()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                ArrayList orderConcrete = new ArrayList();
                await Task.Delay(0);
                var orders = from order in db.Orders
                             join employee in db.Employees on order.ID_Employee equals employee.ID_Employee
                             join client in db.Clients on order.ID_Client equals client.ID_Client
                             join device in db.Devices on order.ID_Device equals device.ID_Device
                             join status in db.order_Statuses on order.ID_Status equals status.ID_Status
                             orderby order.Date_Order
                             select new
                             {
                                 DateOrder = order.Date_Order,
                                 ID_Order = order.ID_Order,
                                 ClientName = client.FIO,
                                 ClientSeriesNumber = client.Series_Number_Passport,
                                 ClientPhoneNumber = client.Phone_Number,
                                 ClientEmail = client.Email,
                                 DeviceName = device.Name,
                                 SeriesNumber = device.Serial_Number,
                                 Description = device.Description,
                                 Manufactorer = device.Manufacturer,
                                 Model = device.Model,
                                 ID_Employee = employee.ID_Employee,
                                 EmployeeName = employee.FIO,
                                 EmployeePhoneNumber = employee.Phone_Number,
                                 Status = status.Name_Status

                             };


                foreach (var order in orders)
                    orderConcrete.Add(order);

                return orderConcrete;

            }
        }

        public async static Task<ArrayList> GetStatusOrdersViewMasterWindow(int id_status, string id_employee)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                ArrayList orderConcrete = new ArrayList();
                await Task.Delay(0);
                var orders = from order in db.Orders
                             join employee in db.Employees on order.ID_Employee equals employee.ID_Employee
                             join client in db.Clients on order.ID_Client equals client.ID_Client
                             join device in db.Devices on order.ID_Device equals device.ID_Device
                             join status in db.order_Statuses on order.ID_Status equals status.ID_Status
                             where order.ID_Status == id_status && order.ID_Employee == id_employee
                             orderby order.Date_Order
                             select new
                             {
                                 DateOrder = order.Date_Order,
                                 ID_Order = order.ID_Order,
                                 ClientName = client.FIO,
                                 ClientEmail = client.Email,
                                 ClientPhoneNumber = client.Phone_Number,
                                 DeviceName = device.Name,
                                 SeriesNumber = device.Serial_Number,
                                 Description = device.Description,
                                 Manufactorer = device.Manufacturer,
                                 Model = device.Model,
                                 Status = status.Name_Status

                             };


                foreach (var order in orders)
                    orderConcrete.Add(order);

                return orderConcrete;

            }
        }

        public async static Task<ArrayList> GetStatusOrdersViewMasterWindow(int id_status)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                ArrayList orderConcrete = new ArrayList();
                await Task.Delay(0);
                var orders = from order in db.Orders
                             join employee in db.Employees on order.ID_Employee equals employee.ID_Employee
                             join client in db.Clients on order.ID_Client equals client.ID_Client
                             join device in db.Devices on order.ID_Device equals device.ID_Device
                             join status in db.order_Statuses on order.ID_Status equals status.ID_Status
                             where order.ID_Status == id_status 
                             orderby order.Date_Order
                             select new
                             {
                                 DateOrder = order.Date_Order,
                                 ID_Order = order.ID_Order,
                                 ClientName = client.FIO,
                                 ClientPhoneNumber = client.Phone_Number,
                                 ClientEmail = client.Email,
                                 DeviceName = device.Name,
                                 SeriesNumber = device.Serial_Number,
                                 Description = device.Description,
                                 Manufactorer = device.Manufacturer,
                                 Model = device.Model,
                                 Status = status.Name_Status,
                                 FioEmployee = employee.FIO,
                                 PhoneEmployee = employee.Phone_Number,
                                 Position = employee.Position

                             };


                foreach (var order in orders)
                    orderConcrete.Add(order);

                return orderConcrete;

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
        public async static Task<ArrayList> GetAllStatus()
        {
            ArrayList allStatus = new ArrayList();
            using (ApplicationContext db = new ApplicationContext())
            {
                await Task.Delay(0);
                var statuses = from status in db.order_Statuses
                               select status;

                foreach (var status in statuses)
                    allStatus.Add(status);

                return allStatus;
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

                foreach (var position in positions)
                    allPositions.Add(position);

                return allPositions;
            }

        }

        public async static Task<ArrayList> GetActivePositions()
        {
            ArrayList allPositions = new ArrayList();
            using (ApplicationContext db = new ApplicationContext())
            {
                await Task.Delay(0);
                var positions = from position in db.positions
                                where position.ID_Position == 1 || position.ID_Position == 2 || position.ID_Position == 3 || position.ID_Position == 4  || position.ID_Position == 5
                                select position;

                foreach (var position in positions)
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
                var details = from detail in db.stockDetails
                              where detail.QuantityStock > 0
                              orderby detail.Name_Detail
                              select detail;


                foreach (var detail in details)
                    allDetails.Add(detail);

                return allDetails;

            }


        }


        public async static Task<ArrayList> GetAllDetailsView()
        {
            ArrayList allDetails = new ArrayList();
            using (ApplicationContext db = new ApplicationContext())
            {
                await Task.Delay(0);
                var details = from detail in db.stockDetails
                              orderby detail.Name_Detail
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
                             where order.ID_Status == 3
                             join employee in db.Employees on order.ID_Employee equals employee.ID_Employee
                             join client in db.Clients on order.ID_Client equals client.ID_Client
                             join device in db.Devices on order.ID_Device equals device.ID_Device
                             orderby order.Date_Order
                             select new
                             {
                                 DateOrder = order.Date_Order,
                                 ID_Order = order.ID_Order,
                                 ClientName = client.FIO,
                                 Email = client.Email,
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

        public async static Task<ArrayList> GetAllEmployeesView()
        {
            ArrayList allEmployees = new ArrayList();
            using (ApplicationContext db = new ApplicationContext())
            {
                await Task.Delay(0);
                var employees = from e in db.Employees
                                join p in db.positions on e.ID_Position equals p.ID_Position
                                select new
                                {
                                    ID_Employee = e.ID_Employee,
                                    Password = e.Password,
                                    FIO = e.FIO,
                                    ID_Position = p.ID_Position,
                                    Position = p.Name_Position,
                                    SeriesNumber = e.Series_Number_Password,
                                    Address = e.Address,
                                    Phone_Number = e.Phone_Number,
                                    DateEmployment = e.EmploymentDate
                                };

                foreach (var employee in employees)
                    allEmployees.Add(employee);

                return allEmployees;
            }


        }

        public async static Task<ArrayList> GetAllPerformanceViewAllOrdersWindow()
        {
            ArrayList allPerformance = new ArrayList();
            using (ApplicationContext db = new ApplicationContext())
            {
                await Task.Delay(0);
                var performances = from p in db.performances
                                   orderby p.Date_Performance
                                   select p;

                foreach (var performance in performances)
                    allPerformance.Add(performance);


            }

            return allPerformance;
        }


        public async static Task<ArrayList> SearchOrders(string seachingOrder)
        {
            ArrayList searchOrders = new ArrayList();
            using (ApplicationContext db = new ApplicationContext())
            {
                await Task.Delay(0);
                var orders = from order in db.Orders

                             where order.ID_Status == 3
                             join employee in db.Employees on order.ID_Employee equals employee.ID_Employee
                             join client in db.Clients on order.ID_Client equals client.ID_Client
                             join device in db.Devices on order.ID_Device equals device.ID_Device
                             orderby order.Date_Order
                             select new
                             {
                                 DateOrder = order.Date_Order,
                                 ID_Order = order.ID_Order.ToString(),
                                 ClientName = client.FIO,
                                 Email = client.Email,
                                 DeviceName = device.Name,
                                 SeriesNumber = device.Serial_Number,
                                 EmployeeName = employee.FIO
                             };

                var search = orders.Where(n =>
                    EF.Functions.Like(n.ID_Order!, $"%{seachingOrder}%") ||
                    EF.Functions.Like(n.ClientName!, $"%{seachingOrder}%") ||
                     EF.Functions.Like(n.Email!, $"%{seachingOrder}%") ||
                    EF.Functions.Like(n.DeviceName!, $"%{seachingOrder}%") ||
                    EF.Functions.Like(n.SeriesNumber!, $"%{seachingOrder}%") ||
                    EF.Functions.Like(n.EmployeeName, $"%{seachingOrder}%")
                );

                foreach (var order in search)
                    searchOrders.Add(order);

                return searchOrders;


            }
        }

        public async static Task<ArrayList> SearchOrdersViewAllOrdersWindow(string seachingOrder)
        {
            ArrayList searchOrders = new ArrayList();
            using (ApplicationContext db = new ApplicationContext())
            {
                await Task.Delay(0);
                var orders = from order in db.Orders
                             join employee in db.Employees on order.ID_Employee equals employee.ID_Employee
                             join client in db.Clients on order.ID_Client equals client.ID_Client
                             join device in db.Devices on order.ID_Device equals device.ID_Device
                             join status in db.order_Statuses on order.ID_Status equals status.ID_Status
                             orderby order.Date_Order
                             select new
                             {
                                 DateOrder = order.Date_Order,
                                 ID_Order = order.ID_Order.ToString(),
                                 ClientName = client.FIO,
                                 ClientSeriesNumber = client.Series_Number_Passport,
                                 ClientPhoneNumber = client.Phone_Number,
                                 ClientEmail = client.Email,
                                 DeviceName = device.Name,
                                 SeriesNumber = device.Serial_Number,
                                 Description = device.Description,
                                 Manufactorer = device.Manufacturer,
                                 Model = device.Model,
                                 ID_Employee = employee.ID_Employee,
                                 EmployeeName = employee.FIO,
                                 EmployeePhoneNumber = employee.Phone_Number,
                                 Status = status.Name_Status

                             };

                var search = orders.Where(n =>
                    EF.Functions.Like(n.ID_Order!, $"%{seachingOrder}%") ||
                    EF.Functions.Like(n.Status!, $"%{seachingOrder}%") ||
                    EF.Functions.Like(n.ClientName!, $"%{seachingOrder}%") ||
                    EF.Functions.Like(n.ClientSeriesNumber!, $"%{seachingOrder}%") ||
                    EF.Functions.Like(n.ClientPhoneNumber!, $"%{seachingOrder}%") ||
                    EF.Functions.Like(n.DeviceName!, $"%{seachingOrder}%") ||
                    EF.Functions.Like(n.SeriesNumber!, $"%{seachingOrder}%") ||
                     EF.Functions.Like(n.EmployeeName, $"%{seachingOrder}%") ||
                    EF.Functions.Like(n.ID_Employee, $"%{seachingOrder}%") ||
                    EF.Functions.Like(n.EmployeePhoneNumber, $"%{seachingOrder}%")
                );

                foreach (var order in search)
                    searchOrders.Add(order);

                return searchOrders;


            }
        }

        public async static Task<ArrayList> SearchOrdersMasterWindow(int id_status, string id_employee, string seachingOrder)
        {
            ArrayList searchOrders = new ArrayList();
            using (ApplicationContext db = new ApplicationContext())
            {
                await Task.Delay(0);
                var orders = from order in db.Orders
                             join employee in db.Employees on order.ID_Employee equals employee.ID_Employee
                             join client in db.Clients on order.ID_Client equals client.ID_Client
                             join device in db.Devices on order.ID_Device equals device.ID_Device
                             join status in db.order_Statuses on order.ID_Status equals status.ID_Status
                             where order.ID_Status == id_status && order.ID_Employee == id_employee
                             orderby order.Date_Order

                             select new
                             {
                                 DateOrder = order.Date_Order,
                                 ID_Order = order.ID_Order.ToString(),
                                 ClientName = client.FIO,
                                 ClientPhoneNumber = client.Phone_Number,
                                 ClientEmail = client.Email,
                                 DeviceName = device.Name,
                                 SeriesNumber = device.Serial_Number,
                                 Description = device.Description,
                                 Manufactorer = device.Manufacturer,
                                 Model = device.Model,
                                 Status = status.Name_Status

                             };

                var search = orders.Where(n =>
                    EF.Functions.Like(n.ID_Order!, $"%{seachingOrder}%") ||
                    EF.Functions.Like(n.Status!, $"%{seachingOrder}%") ||
                    EF.Functions.Like(n.ClientName!, $"%{seachingOrder}%") ||
                    EF.Functions.Like(n.ClientPhoneNumber!, $"%{seachingOrder}%") ||
                    EF.Functions.Like(n.ClientEmail!, $"%{seachingOrder}%") ||
                    EF.Functions.Like(n.DeviceName!, $"%{seachingOrder}%") ||
                    EF.Functions.Like(n.SeriesNumber!, $"%{seachingOrder}%")
                );

                foreach (var order in search)
                    searchOrders.Add(order);

                return searchOrders;


            }

        }

        public async static Task<ArrayList> SearchOrdersMasterWindow(int id_status, string seachingOrder)
        {
            ArrayList searchOrders = new ArrayList();
            using (ApplicationContext db = new ApplicationContext())
            {
                await Task.Delay(0);
                var orders = from order in db.Orders
                             join employee in db.Employees on order.ID_Employee equals employee.ID_Employee
                             join client in db.Clients on order.ID_Client equals client.ID_Client
                             join device in db.Devices on order.ID_Device equals device.ID_Device
                             join status in db.order_Statuses on order.ID_Status equals status.ID_Status
                             where order.ID_Status == id_status
                             orderby order.Date_Order

                             select new
                             {
                                 DateOrder = order.Date_Order,
                                 ID_Order = order.ID_Order.ToString(),
                                 ClientName = client.FIO,
                                 ClientPhoneNumber = client.Phone_Number,
                                 ClientEmail = client.Email,
                                 DeviceName = device.Name,
                                 SeriesNumber = device.Serial_Number,
                                 Description = device.Description,
                                 Manufactorer = device.Manufacturer,
                                 Model = device.Model,
                                 Status = status.Name_Status,
                                 FioEmployee = employee.FIO,
                                 PhoneEmployee = employee.Phone_Number,

                             };

                var search = orders.Where(n =>
                    EF.Functions.Like(n.ID_Order!, $"%{seachingOrder}%") ||
                    EF.Functions.Like(n.Status!, $"%{seachingOrder}%") ||
                    EF.Functions.Like(n.ClientName!, $"%{seachingOrder}%") ||
                    EF.Functions.Like(n.ClientPhoneNumber!, $"%{seachingOrder}%") ||
                    EF.Functions.Like(n.DeviceName!, $"%{seachingOrder}%") ||
                    EF.Functions.Like(n.SeriesNumber!, $"%{seachingOrder}%") ||
                     EF.Functions.Like(n.FioEmployee!, $"%{seachingOrder}%") 
                );

                foreach (var order in search)
                    searchOrders.Add(order);

                return searchOrders;


            }

        }

        public async static Task<ArrayList> SearchPerformanceViewAllOrdersWindow(string seachingOrder)
        {
            ArrayList searchPerf = new ArrayList();
            using (ApplicationContext db = new ApplicationContext())
            {
                await Task.Delay(0);


                var search = db.performances.OrderBy(n => n.Date_Performance).Where(n =>
                                     EF.Functions.Like(n.ID_Performance.ToString(), $"%{seachingOrder}%") ||
                                     EF.Functions.Like(n.OrderKey.ToString(), $"%{seachingOrder}%")

                    );




                foreach (var performance in search)
                    searchPerf.Add(performance);

                return searchPerf;


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
                    EF.Functions.Like(n.Phone_Number!, $"%{seachingClient}%") ||
                    EF.Functions.Like(n.Email!, $"%{seachingClient}%"));

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

        public async static Task<ArrayList> SearchDetails(string searchingDetale)
        {
            ArrayList searchDetails = new ArrayList();
            using (ApplicationContext db = new ApplicationContext())
            {
                await Task.Delay(0);
                var details = db.stockDetails.OrderBy(p => p.Name_Detail)
                    .Where(n =>
                    EF.Functions.Like(n.Name_Detail!, $"%{searchingDetale}%"));

                foreach (var detail in details)
                    searchDetails.Add(detail);
                return searchDetails;
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
                    (e, p) => new
                    {
                        ID_Employee = e.ID_Employee,
                        FIO = e.FIO,
                        Position = p.Name_Position,
                        Phone_Number = e.Phone_Number

                    }).Where(n =>
                     EF.Functions.Like(n.FIO!, $"%{seachingEmployee}%") ||
                    EF.Functions.Like(n.Position!, $"%{seachingEmployee}%") ||
                    EF.Functions.Like(n.ID_Employee!, $"%{seachingEmployee}%")

                    );

                var SearchEmployees = employees.Where(n => n.Position == "Мастер" || n.Position == "Старший мастер" || n.Position == "Стажер");

                foreach (var employee in SearchEmployees)
                    searchEmployees.Add(employee);
                return searchEmployees;
            }


        }


        public async static Task<ArrayList> SearchEmployeesView(string seachingEmployee)
        {
            ArrayList searchEmployees = new ArrayList();
            using (ApplicationContext db = new ApplicationContext())
            {
                await Task.Delay(0);
                var employees = db.Employees.Join(db.positions,
                    e => e.ID_Position,
                    p => p.ID_Position,
                    (e, p) => new
                    {
                        ID_Employee = e.ID_Employee,
                        Password = e.Password,
                        FIO = e.FIO,
                        ID_Position = p.ID_Position,
                        Position = p.Name_Position,
                        SeriesNumber = e.Series_Number_Password,
                        Address = e.Address,
                        Phone_Number = e.Phone_Number,
                        DateEmployment = e.EmploymentDate

                    }).Where(n =>
                    EF.Functions.Like(n.FIO!, $"%{seachingEmployee}%") ||
                    EF.Functions.Like(n.Position!, $"%{seachingEmployee}%") ||
                    EF.Functions.Like(n.ID_Employee!, $"%{seachingEmployee}%")

                    );



                foreach (var employee in employees)
                    searchEmployees.Add(employee);
                return searchEmployees;
            }


        }



        public async static Task<bool> InsertPerformance
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
                    stockDetail.FullPrice = stockDetail.FullPrice - (IsQuantityDetailsNum.Value * stockDetail.Unit_Price);


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
                order.ID_Status = 4;

                // Ограничение по дате
                var dateOrder = db.Orders.Where(c => c.ID_Order == id_Order && c.Date_Order > datePerformance).FirstOrDefault();

                if (dateOrder != null)
                {
                    throw new Exception($"Исполнение не может быть раньше даты регистрации заказа. Заказ: ({dateOrder.Date_Order}) Исполнение: ({datePerformance})");
                }






                await db.SaveChangesAsync();
            }
            return true;



        }

        public async static Task<bool> InsertOrder(Guid id_Order, Guid idClient, Guid id_Device, string id_Employee, int id_Status, DateTime? dateOrder)
        {

            using (ApplicationContext db = new ApplicationContext())
            {
                Order order = new Order() { ID_Order = id_Order, ID_Client = idClient, ID_Device = id_Device, ID_Employee = id_Employee, ID_Status = id_Status, Date_Order = dateOrder };
                db.Add(order);
                await db.SaveChangesAsync();


            }
            return true;

        }

        public async static Task<bool> InsertEmployee(string id_Employee, string password_employee, string fio, int id_position, string series_number_passport, string address, string phone_Number, DateTime? employment_Date)
        {

            using (ApplicationContext db = new ApplicationContext())
            {
                Employee employee = new Employee() { ID_Employee = id_Employee, Password = password_employee, FIO = fio, ID_Position = id_position, Series_Number_Password = series_number_passport, Address = address, Phone_Number = phone_Number, EmploymentDate = employment_Date };
                db.Add(employee);
                await db.SaveChangesAsync();
            }
            return true;


        }

        public async static Task<bool> InsertDetails(Guid id_Detail, string name_detail, decimal unit_Price, int quantity, decimal full_Price)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                StockDetails stockDetails = new StockDetails() { ID_Detail = id_Detail, Name_Detail = name_detail, Unit_Price = unit_Price, QuantityStock = quantity, FullPrice = full_Price };
                db.Add(stockDetails);
                await db.SaveChangesAsync();
            }
            return true;


        }

        public async static Task<bool> InsertDevice(Guid id_Device, string nameDevice, string serialNumber, string description, string manufacturer, string model, DateTime? dateAdded)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Device device = new Device() { ID_Device = id_Device, Name = nameDevice, Serial_Number = serialNumber, Description = description, Manufacturer = manufacturer, Model = model, DateAdded = dateAdded };
                db.Add(device);
                await db.SaveChangesAsync();

            }
            return true;
        }

        public async static Task<bool> InsertClient(Guid id_Client, string fio, string serialNumber, string phoneNumber, string email, DateTime? dateAdded)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Client client = new Client() { ID_Client = id_Client, FIO = fio, Series_Number_Passport = serialNumber, Phone_Number = phoneNumber, Email = email, DateAdded = dateAdded };
                db.Add(client);
                await db.SaveChangesAsync();

            }
            return true;
        }

        public async static Task UpdateClient(Guid id_Client, string fio, string seriesNumber, string phoneNumber, string email)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var updatedClient = await db.Clients.
                    Where(c => c.ID_Client == id_Client)
                    .FirstOrDefaultAsync();
                updatedClient.FIO = fio;
                updatedClient.Series_Number_Passport = seriesNumber;
                updatedClient.Phone_Number = phoneNumber;
                updatedClient.Email = email;

                await db.SaveChangesAsync();
            }

        }

        public async static Task UpdateDevice(Guid id_Device, string name, string serielNumber, string description, string manufacturer, string model)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var updatedDevice = await db.Devices
                    .Where(c => c.ID_Device == id_Device)
                    .FirstOrDefaultAsync();
                updatedDevice.Name = name;
                updatedDevice.Serial_Number = serielNumber;
                updatedDevice.Description = description;
                updatedDevice.Manufacturer = manufacturer;
                updatedDevice.Model = model;

                await db.SaveChangesAsync();
            }
        }

        public async static Task UpdateDetail(Guid id_detail, string nameDetail, decimal unitPrice, int quamtoty, decimal fullPrice)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var updatedDetail = await db.stockDetails
                    .Where(c => c.ID_Detail == id_detail)
                    .FirstOrDefaultAsync();
                updatedDetail.Name_Detail = nameDetail;
                updatedDetail.Unit_Price = unitPrice;
                updatedDetail.QuantityStock = quamtoty;
                updatedDetail.FullPrice = fullPrice;

                await db.SaveChangesAsync();
            }

        }

        public async static Task UpdateEmployee(string id_employee, string password, string fio, string seriesNumber, string address, string phoneNumber, int position)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var updatedEmployee = await db.Employees
                    .Where(c => c.ID_Employee == id_employee)
                    .FirstOrDefaultAsync();
                updatedEmployee.Password = password;
                updatedEmployee.FIO = fio;
                updatedEmployee.Series_Number_Password = seriesNumber;
                updatedEmployee.Address = address;
                updatedEmployee.Phone_Number = phoneNumber;
                updatedEmployee.ID_Position = position;

                await db.SaveChangesAsync();
            }


        }

        public async static Task UpdateStatus(Guid id_order, int id_status)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var updateOrder = await db.Orders
                    .Where(c => c.ID_Order == id_order)
                    .FirstOrDefaultAsync();
                updateOrder.ID_Status = id_status;

                await db.SaveChangesAsync();

            }

        }


        public async static Task RemoveClient(Guid id_client)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var removeClient = await db.Clients.
                    Where(c => c.ID_Client == id_client)
                    .FirstOrDefaultAsync();
                db.Remove(removeClient);
                await db.SaveChangesAsync();
            }
        }

        public async static Task RemoveDevice(Guid id_device)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var removeDevice = await db.Devices
                    .Where(c => c.ID_Device == id_device)
                    .FirstOrDefaultAsync();
                db.Remove(removeDevice);
                await db.SaveChangesAsync();
            }
        }

        public async static Task RemoveDetail(Guid id_detail)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var removeDetail = await db.stockDetails
                    .Where(c => c.ID_Detail == id_detail)
                    .FirstOrDefaultAsync();
                db.Remove(removeDetail);
                await db.SaveChangesAsync();

            }
        }

        public async static Task RemoveEmployee(string id_Employee)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var removeEmployee = await db.Employees
                    .Where(c => c.ID_Employee == id_Employee)
                    .FirstOrDefaultAsync();
                db.Remove(removeEmployee);
                await db.SaveChangesAsync();

            }
        }






    }
}
