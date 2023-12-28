namespace back_app_sr.Domain.Models;

public class Order
{
    public Guid OrderId { get; set; }
    public int ItemId { get; set; }
    public int AdditionalId { get; set; }
    public string Observation { get; set; }
    public int Quantity { get; set; }
    public Guid TabId { get; set; }
    public Tab Tab { get; set; }
}