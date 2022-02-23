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


        public static async Task<Order_Status> GetStatusOrder()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Order_Status? status = await db.order_Statuses.FirstOrDefaultAsync(p => p.Name_Status == "Заказ зарегестрирован");

                return status;

            }



        }


        public async static Task<ArrayList> GetAllDetails()
        {
            ArrayList allDetails = new ArrayList();
            using (ApplicationContext db = new ApplicationContext())
            {
                await Task.Delay(0);
                var details = from detail in db.stockDetails
                              select detail;


                foreach (var detail in details)
                    allDetails.Add(detail);

                return allDetails;

            }


        }

        public async static Task<ArrayList> GetAllOrders()
        {
            ArrayList allOrders = new ArrayList();
            using (ApplicationContext db = new ApplicationContext())
            {
                await Task.Delay(0);
                var orders = from order in db.Orders
                             select order;

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

        public async static Task<ArrayList> SearchOrders(string searchingID)
        {
            ArrayList searchOrders = new ArrayList();
            using (ApplicationContext db = new ApplicationContext())
            {
                await Task.Delay(0);
                var orders = from order in db.Orders
                             where EF.Functions.Like(order.ID_Order.ToString(), $"%{searchingID}%")
                             select order;
                foreach (var order in orders)
                    searchOrders.Add(order);

                return searchOrders;

            }


        }



        public async static Task InsertStockDetails
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


                await db.SaveChangesAsync();
            }



        }

        public async static Task InsertOrder(Guid id_Order, Guid idClient, Guid id_Device, Guid id_Employee, Guid id_Status, DateTime? dateOrder)
        {

            using (ApplicationContext db = new ApplicationContext())
            {
                Order order = new Order() { ID_Order = id_Order, ID_Client = idClient, ID_Device = id_Device, ID_Employee = id_Employee, ID_Status = id_Status, Date_Order = dateOrder };
                db.Add(order);
                await db.SaveChangesAsync();


            }

        }





    }
}
