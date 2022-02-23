using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepaifPhoneDB;


namespace ApplicationRepairPhoneEntityFramework
{
    public class ApplicationContext : DbContext
    {

        // public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Device> Devices => Set<Device>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Order_Status> order_Statuses => Set<Order_Status>();
        public DbSet<Performance> performances => Set<Performance>();
        public DbSet<Position> positions => Set<Position>();
        public DbSet<StockDetails> stockDetails => Set<StockDetails>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Relationship> Relationships => Set<Relationship>();


        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {



            builder.Entity<Relationship>().HasKey(table => new
            {
                table.ID_Performance,
                table.ID_Detail
            });

            builder
                .Entity<Order>()
                .HasOne(o => o.Per)
                .WithOne(p => p.Order)
                .HasForeignKey<Performance>(p=>p.OrderKey);

            Order_Status orderRegistered = new Order_Status { ID_Status = Guid.NewGuid(), Name_Status = "Заказ зарегестрирован" };
            Order_Status orderInProgress = new Order_Status { ID_Status = Guid.NewGuid(), Name_Status = "Заказ выполняется" };
            Order_Status orderCompleted = new Order_Status { ID_Status = Guid.NewGuid(), Name_Status = "Заказ выполнен" };

            Position storekeeper = new Position {ID_Position =  Guid.NewGuid(), Name_Position = "Стажер"};
            Position master = new Position {ID_Position = Guid.NewGuid(), Name_Position = "Мастер" };
            Position HeadMaster = new Position {ID_Position = Guid.NewGuid(), Name_Position = "Старший мастер" };


            builder.Entity<Order_Status>().HasData(orderRegistered, orderInProgress, orderCompleted);
            builder.Entity<Position>().HasData(storekeeper, master, HeadMaster);
        }



        
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(@"Server=GURREX\SQLEXPRESS;Database=RepairPhone;Trusted_Connection=True;TrustServerCertificate=true;");
        }

    }
}
