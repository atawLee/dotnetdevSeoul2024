using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleWMS.Database.Entities;

public class StockInOut
{
    [Key]
    public int Id { get; set; }
    public int InventoryItemId { get; set; }
    public int PreviousQuantity { get; set; }
    public int AfterQuantity { get; set; }
    public int ChangeInQuantity { get; set; }

    public StockTransactionType TransactionType { get; set; }

    public DateTime Date { get; set; }

    [ForeignKey("InventoryItemId")]
    public virtual InventoryItem InventoryItem { get; set; }

}

public enum StockTransactionType
{
    StockIn,
    StockOut
}
