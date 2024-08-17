using back_app_sr.Domain.Models.Items;

namespace back_app_sr.Domain.Models.QuickSale;

public class QuickSaleItemModel
{
    public Guid QuickSaleItemId { get; set; }
    public QuickSaleModel QuickSaleModel { get; set; }
    public Guid QuickSaleId { get; set; }
    public int ItemId { get; set; }
    public ItemModel Item { get; set; }
}