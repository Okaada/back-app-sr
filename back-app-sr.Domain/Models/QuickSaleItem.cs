namespace back_app_sr.Domain.Models;

public class QuickSaleItem
{
    public Guid QuickSaleItemId { get; set; }
    public QuickSale QuickSale { get; set; }
    public Guid QuickSaleId { get; set; }
    public int ItemId { get; set; }
    public Item Item { get; set; }
}