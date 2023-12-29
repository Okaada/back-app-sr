namespace back_app_sr.Domain.Models;

public class TabPayment
{
    public Guid TabPaymentId { get; set; }
    public Guid TabId { get; set; }
    public TabModel TabModel { get; set; }
    public string PaymentType { get; set; } 
    public bool IsChangeRequested { get; set; }
    public decimal Amount { get; set; }
    public decimal Change { get; set; }
}