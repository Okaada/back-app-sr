namespace back_app_sr.Domain.Models;

public class Tab
{
    public Guid TabId { get; set; }
    public int TableNumber { get; set; }
    public string Status { get; set; }
    public decimal Total { get; set; }
    public string TabType { get; set; }

    public ICollection<Order> Orders { get; set; }
    public ICollection<TabPayment> Payments { get; set; }
    public Delivery Delivery { get; set; }
}