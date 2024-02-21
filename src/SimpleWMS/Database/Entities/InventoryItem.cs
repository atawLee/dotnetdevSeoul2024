using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleWMS.Database.Entities;

public class InventoryItem
{
    [Key]
    public int Id { get; set; }

    // Product 테이블의 기본 키를 참조하는 외래 키
    public int ProductId { get; set; }

    public string Barcode { get; set; }
    
    public string? Location { get; set; }

    public int Quantity { get; set; }

    // Product와의 관계를 나타내는 네비게이션 프로퍼티
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }

    public virtual ICollection<StockInOut> StockInOuts { get; set; }
}