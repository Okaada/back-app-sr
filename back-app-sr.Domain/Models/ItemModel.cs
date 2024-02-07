using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_app_sr.Domain.Models;

public class ItemModel
{
    [Key]
    public int ItemId { get; set; }
    public string Name { get; private set; }
    public decimal Value { get; private set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public int? CategoryItemId { get; set; }
    public CategoryItemModel Category { get; set; }

    public ItemModel(string name, decimal value, string description, int? categoryItemId)
    {
        Name = name;
        Value = value;
        Description = description;
        CategoryItemId = categoryItemId;
        IsActive = true;
    }
}