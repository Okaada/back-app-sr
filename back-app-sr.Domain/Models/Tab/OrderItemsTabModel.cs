namespace back_app_sr.Domain.Models.Tab;

public class OrderItemsTabModel
{
    public Guid Id { get; set; }
    public Guid TabId { get; set; }
    public int ItemId { get; set; }
    public int Quantity { get; set; }
}