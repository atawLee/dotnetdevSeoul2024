using System.ComponentModel.DataAnnotations;

namespace SimpleWMS.Database.Entities;

public class Product
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public virtual ICollection<InventoryItem> InventoryItems { get; set; }

    public Product()
    {
        InventoryItems = new HashSet<InventoryItem>();
    }
}
