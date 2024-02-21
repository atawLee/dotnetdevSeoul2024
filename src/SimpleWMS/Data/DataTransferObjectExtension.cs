using SimpleWMS.Database.Entities;

namespace SimpleWMS.Data;

public static class DataTransferObjectExtension
{
    public static StockHistoryDTO ToDTO(this StockInOut stock)
    {
        return new StockHistoryDTO(
            stock.Id, 
            stock.InventoryItem?.Product?.Name ?? "??", 
            stock.InventoryItemId,
            stock.InventoryItem?.Barcode ?? "??",  
            stock.InventoryItem?.Location ?? "",
            stock.ChangeInQuantity, 
            stock.TransactionType.ToString(),
            (int)stock.TransactionType, 
            stock.Date);
    }

    public static StockInOut ToDatabaseEntity(this StockCommandDTO stock ,int previousQuantity)
    {
        return new()
        {
            Id = 0,
            InventoryItemId = stock.InventoryId,
            PreviousQuantity = previousQuantity,
            AfterQuantity = previousQuantity + stock.Quantity,
            ChangeInQuantity = stock.Quantity,
            TransactionType = (StockTransactionType)stock.Type ,
            Date = DateTime.Now
        };
    }
}
