using System.ComponentModel.DataAnnotations;

namespace back_app_sr.Domain.Models.Items;

public class ItemModel
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Value { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    
    public ItemModel(string name, decimal value, string description)
    {
        Name = name;
        Value = value;
        Description = description;
        IsActive = true;
    }
}