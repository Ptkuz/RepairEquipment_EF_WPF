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
            Database.EnsureDeleted();
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

            


            builder.Entity<Order_Status>().HasData(
            new Order_Status[]
            {
                new Order_Status { ID_Status = 1, Name_Status = "Заказ зарегестрирован" },
                new Order_Status { ID_Status = 2, Name_Status = "Заказ выполняется"},
                new Order_Status {ID_Status = 3, Name_Status = "Заказ выполнен" },
                new Order_Status { ID_Status = 4, Name_Status = "Заказ закрыт"},
                new Order_Status { ID_Status = 5, Name_Status = "Заказ отменен"}
            });

            builder.Entity<Position>().HasData(
            new Position[]
            {
                new Position {  ID_Position = 1, Name_Position = "Стажер" },
                new Position { ID_Position = 2, Name_Position = "Мастер"},
                new Position {ID_Position = 3, Name_Position = "Старший мастер"},
                new Position { ID_Position = 4, Name_Position = "Менеджер" },
                new Position { ID_Position = 5, Name_Position = "Директор" },
               new Position { ID_Position = 6, Name_Position = "Уволен" }
            });

            builder.Entity<Employee>().HasData(new Employee { ID_Employee = "Gurrex", Password = "GurrexPassword", FIO = "Тимоходцев Павел Евгеньевич", ID_Position = 5, Series_Number_Password = "3219 008001", Address = "Москва", Phone_Number = "89512289628", EmploymentDate = DateTime.Now });


        }



        
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(@"Server=GURREX\SQLEXPRESS;Database=RepairPhone;Trusted_Connection=True;TrustServerCertificate=true;");
        }

    }
}
