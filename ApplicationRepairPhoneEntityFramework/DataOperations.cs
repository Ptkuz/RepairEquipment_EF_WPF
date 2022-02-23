using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepaifPhoneDB;
using Microsoft.EntityFrameworkCore;

namespace ApplicationRepairPhoneEntityFramework
{
    public static class DataOperations
    {


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

        public async static Task<ArrayList> SearchOrders(string searchingID) 
        {
            ArrayList searchOrders = new ArrayList();
            using (ApplicationContext db = new ApplicationContext()) 
            {
                await Task.Delay(0);
                var orders = from order in db.Orders
                             where EF.Functions.Like(order.ID_Order.ToString(), $"%{searchingID}%")
                             select order;
                foreach(var order in orders)
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





    }
}
