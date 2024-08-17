using System.ComponentModel.DataAnnotations;

namespace back_app_sr.Domain.Models.Items;

public class ItemModel
{
    [Key]
    public int Id { get; set; }
    public string Name { get; private set; }
    public decimal Value { get; private set; }
    public string Description { get; private set; }
    
    public ItemModel(string name, decimal value, string description)
    {
        Name = name;
        Value = value;
        Description = description;
    }
}