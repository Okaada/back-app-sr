namespace back_app_sr.Domain.Models;

public class Delivery
{
    public Guid DeliveryId { get; set; }
    public Guid TabId { get; set; }
    public Tab Tab { get; set; }
    public string Name { get; set; }
    public string Telephone { get; set; }
    public string Address { get; set; }
}