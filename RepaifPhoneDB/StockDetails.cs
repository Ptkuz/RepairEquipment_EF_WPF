using System.ComponentModel.DataAnnotations;

namespace RepaifPhoneDB
{
    public class StockDetails
    {
        [Key]
        public Guid ID_Detail { get; set; }
        public string? Name_Detail { get; set; }
        decimal unit_Price;
        public decimal Unit_Price
        {
            get { return unit_Price; }
            set { unit_Price = value; }
        }

        int quantityStock;
        public int QuantityStock
        {
            get { return quantityStock; }
            set { quantityStock = value; }
        }
        decimal fullPrice;
        public decimal FullPrice
        {
            get { return fullPrice; }
            set { fullPrice = quantityStock* unit_Price; }
        }

        public int? NeededQuantity { get; set; }

        public bool Choise { get; set; }

        

        //public List<Performance> Performances { get; set; } = new();

        //public PerformanceStockDetails PerformanceStockDetails { get; set; } = new();

    }
}
