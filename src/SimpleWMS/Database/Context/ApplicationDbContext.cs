using Microsoft.EntityFrameworkCore;
using SimpleWMS.Database.Entities;

namespace SimpleWMS.Database.Context
{
    public class ApplicationDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=wms.db");
        }

        public virtual DbSet<Product> Product { get; set; }

        public virtual DbSet<InventoryItem> InventoryItem { get; set; }

        public virtual DbSet<StockInOut> StockInOut { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Product 초기 데이터 설정
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Description = "A high-performance laptop" },
                new Product { Id = 2, Name = "Smartphone", Description = "An innovative smartphone" }
            );

            // InventoryItem 초기 데이터 설정
            modelBuilder.Entity<InventoryItem>().HasData(
                new InventoryItem { Id = 1, ProductId = 1, Barcode = "01-0001", Quantity = 130,Location = "A0001"},
                new InventoryItem { Id = 2, ProductId = 2, Barcode = "02-0002", Quantity = 200, Location = "B0001"}
            );

            // StockInOut 초기 데이터 설정 (이 부분은 StockInOut 클래스의 구조에 따라 달라질 수 있습니다.)
            modelBuilder.Entity<StockInOut>().HasData(
                new StockInOut { Id = 1, InventoryItemId = 1, PreviousQuantity = 100, AfterQuantity = 130, TransactionType = StockTransactionType.StockIn , ChangeInQuantity = 30, Date = new DateTime(2024, 1, 1, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                new StockInOut { Id = 2, InventoryItemId = 2, PreviousQuantity = 200, AfterQuantity = 100, TransactionType = StockTransactionType.StockOut , ChangeInQuantity = -100,Date = new DateTime(2024,2,1,11,00,00)}
            );
        }
    }
}
