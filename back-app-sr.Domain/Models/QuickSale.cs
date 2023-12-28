namespace back_app_sr.Domain.Models;

public class QuickSale
{
    public Guid QuickSaleId { get; set; }
    public decimal Total { get; set; }
    public ICollection<QuickSaleItem> QuickSaleItems { get; set; }
}