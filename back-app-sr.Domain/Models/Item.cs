using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_app_sr.Domain.Models;

public class Item
{
    [Key]
    public int ItemId { get; set; }
    public string Name { get; set; }
    public decimal Value { get; set; }

    public Item(string name, decimal value)
    {
        Name = name;
        Value = value;
    }
}