namespace back_app_sr.Domain.Models.Deliver;

public class ExternalOrderItensModel
{
    public Guid Id { get; set; }
    public Guid DeliveryRegisterId { get; set; }
    public int ItemId { get; set; }
    public int Quantity { get; set; }
}