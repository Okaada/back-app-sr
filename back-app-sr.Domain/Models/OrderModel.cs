namespace back_app_sr.Domain.Models;

public class OrderModel
{
    public Guid OrderId { get; set; }
    public int ItemId { get; set; }
    public int AdditionalId { get; set; }
    public string Observation { get; set; }
    public int Quantity { get; set; }
    public Guid TabId { get; set; }
    public TabModel TabModel { get; set; }

    public OrderModel(int itemId, int additionalId, string observation, int quantity, Guid tabId)
    {
        ItemId = itemId;
        AdditionalId = additionalId;
        Observation = observation;
        Quantity = quantity;
        TabId = tabId;
    }
}