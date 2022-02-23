﻿using System.ComponentModel.DataAnnotations;

namespace RepaifPhoneDB
{
    public class Performance
    {
        [Key]
        public Guid ID_Performance { get; set; }
        public string? Description_Repair { get; set; }
        public decimal Work_Price { get; set; }
        decimal detail_Price;
        public decimal Detail_Price
        {
            get { return detail_Price; }
            set { detail_Price = value; }
        }
        decimal discount;
        public decimal Discount
        {
            get { return discount; }
            set { discount = value; }
        }
        decimal final_Price;
        public decimal Final_Price
        {
            get { return final_Price; }
            set { final_Price = value; }
        }
        public DateTime? Date_Performance { get; set; }
        public Guid OrderKey { get; set; }
        public Order? Order { get; set; }

        //public PerformanceStockDetails PerformanceStockDetails { get; set; } = new();
        //public List<StockDetails> StockDetails { get; set; } = new();   
    }
}
