using Microsoft.EntityFrameworkCore;
using SimpleWMS.Database.Context;
using SimpleWMS.Database.Entities;

namespace SimpleWMS.Mdels.Repository;

public class WarehouseRepository
{
    private readonly ApplicationDbContext _db;

    public WarehouseRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public List<Product> GetProducts()
    {
        return _db.Product.ToList();
    }

    public List<InventoryItem> GetInventoryItems()
    {
        return _db.InventoryItem.ToList();
    }

    public InventoryItem? GetInventoryItem(int inventoryItemId)
    {
        return _db.InventoryItem
            .FirstOrDefault(x => x.Id == inventoryItemId);
    }

    public List<StockInOut> GetStockInOuts(string? productName = null, string? barcode = null,
        StockTransactionType? type = null)
    {
        var query = _db.StockInOut
            .Include(x=>x.InventoryItem)
            .ThenInclude(x=>x.Product)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(productName))
        {
            query = query.Where(s => s.InventoryItem.Product.Name == productName);
        }

        if (!string.IsNullOrWhiteSpace(barcode))
        {
            query = query.Where(s => s.InventoryItem.Barcode == barcode);
        }

        if (type.HasValue)
        {
            query = query.Where(s => s.TransactionType == type.Value);
        }

        return query.ToList();
    }

    public void InsertStockInOut(StockInOut stockData)
    {
        _db.StockInOut.Add(stockData);
        _db.SaveChanges();
    }

    public void UpdateInventory(InventoryItem ivt, int stockDataAfterQuantity)
    {
        var data = _db.InventoryItem.Attach(ivt);
        ivt.Quantity = stockDataAfterQuantity;
        _db.Entry(ivt).Property(x => x.Quantity).IsModified = true;
        _db.SaveChanges();
    }
}
