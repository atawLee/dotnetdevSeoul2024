using SimpleWMS.Database.Entities;

namespace SimpleWMS.Data;

public record StockHistoryDTO(
    int ProductId,
    string ProductName,
    int InventoryId,
    string Barcode,
    string Location,
    int Quantity,
    string StockTransactionTypeText,
    int StockTransactionType,
    DateTime StockDateTime );

public record StockCommandDTO(int InventoryId ,int Quantity, StockTransactionType Type);