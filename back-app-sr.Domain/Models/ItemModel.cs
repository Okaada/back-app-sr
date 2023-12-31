using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_app_sr.Domain.Models;

public class ItemModel
{
    [Key]
    public int ItemId { get; set; }
    public string Name { get; private set; }
    public decimal Value { get; private set; }

    public ItemModel(string name, decimal value)
    {
        Name = name;
        Value = value;
    }
}