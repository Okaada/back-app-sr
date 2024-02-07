using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_app_sr.Domain.Models;

public class CategoryItemModel
{
    [Key]
    public int CategoryItemId { get; set; }
    public string Name { get; private set; }

    public CategoryItemModel(string name)
    {
        Name = name;
    }
    
    public ICollection<ItemModel> Items { get; set; }
}