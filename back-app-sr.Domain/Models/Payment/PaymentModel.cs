namespace back_app_sr.Domain.Models.Payment;

public class PaymentModel
{
    public Guid Id { get; set; } 
    public Guid RegisterId { get; set; } // Here we can use the TabId,QuickSellId or ExternalSellId
    public string PaymentType { get; set; } 
    public bool IsChangeRequested { get; set; }
    public decimal Amount { get; set; }
    public decimal Changevalue { get; set; }
}