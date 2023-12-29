namespace back_app_sr.Domain.Models;

public class TabModel
{
    public Guid TabId { get; set; }
    public int TableNumber { get; set; }
    public string Status { get; set; }
    public decimal Total { get; set; }
    public string TabType { get; set; }
    public ICollection<OrderModel> Orders { get; set; }
    public ICollection<TabPayment> Payments { get; set; }
    public DeliveryModel DeliveryModel { get; private set; }
    
    public TabModel(int tableNumber, string tabType)
    {
        TabId = Guid.NewGuid();
        TableNumber = tableNumber;
        Status = "Aberta";
        TabType = tabType;
        Orders = new List<OrderModel>();
        Payments = new List<TabPayment>();
        Total = 0;
    }
    
    public void SetDelivery(DeliveryModel deliveryModel)
    {
        DeliveryModel = deliveryModel;
    }
}