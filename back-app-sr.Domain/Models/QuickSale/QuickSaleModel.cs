namespace back_app_sr.Domain.Models.QuickSale;

public class QuickSaleModel
{
    public Guid QuickSaleId { get; set; }
    public decimal Total { get; set; }
    public ICollection<QuickSaleItemModel> QuickSaleItems { get; set; }
}