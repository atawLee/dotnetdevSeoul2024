using SimpleWMS.Data;
using SimpleWMS.Database.Entities;
using SimpleWMS.Mdels;
using SimpleWMS.Mdels.Repository;

namespace SimpleWMS.Models.Services;

public class WareHouseManagementService
{
    private readonly WarehouseRepository _warehouseRepository;
    private readonly UnitOfWork _unitOfWork;

    public WareHouseManagementService(WarehouseRepository warehouseRepository, UnitOfWork unitOfWork)
    {
        _warehouseRepository = warehouseRepository;
        _unitOfWork = unitOfWork;
    }

    public List<Product> GetAllProducts()
    {
        return _warehouseRepository.GetProducts();
    }

    public List<InventoryItem> GetAllInventoryItems()
    {
        return _warehouseRepository.GetInventoryItems();
    }

    public InventoryItem? GetInventoryItemById(int inventoryItemId)
    {
        return _warehouseRepository.GetInventoryItem(inventoryItemId);
    }

    public List<StockHistoryDTO> GetStockInOutsFiltered(string? productName = null, string? barcode = null, StockTransactionType? type = null)
    {
        return _warehouseRepository.GetStockInOuts(productName, barcode, type).Select(dbentity => dbentity.ToDTO())
            .ToList();
    }

    public void InsertStockInOut(StockCommandDTO dto, int quantityChange, StockTransactionType transactionType)
    {
        try
        {
            _unitOfWork.BeginTransaction();
            var inventory = _warehouseRepository.GetInventoryItem(dto.InventoryId)
                            ?? throw new Exception("잘못된 요청.");

            quantityChange = transactionType == StockTransactionType.StockOut ? -Math.Abs(quantityChange) : Math.Abs(quantityChange);
            var stockData = dto.ToDatabaseEntity(inventory.Quantity);
            
            _warehouseRepository.InsertStockInOut(stockData);
            _warehouseRepository.UpdateInventory(inventory, stockData.AfterQuantity);
            _unitOfWork.CommitTransaction();
        }
        catch (Exception e)
        {
            _unitOfWork.RollbackTransaction();
            throw new Exception("등록 실패");
        }
        
    }
}
