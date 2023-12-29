namespace back_app_sr.Domain.Models;

public class DeliveryModel
{
    public Guid DeliveryId { get; set; }
    public Guid TabId { get; set; }
    public TabModel TabModel { get; set; }
    public string Name { get; set; }
    public string Telephone { get; set; }
    public string Address { get; set; }
    
    public DeliveryModel(Guid tabId, string name, string telephone, string address)
    {
        DeliveryId = Guid.NewGuid();
        TabId = tabId;
        Name = name;
        Telephone = telephone;
        Address = address;
    }
}