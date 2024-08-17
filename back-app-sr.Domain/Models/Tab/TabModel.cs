using back_app_sr.Domain.Models.Payment;

namespace back_app_sr.Domain.Models.Tab;

public class TabModel
{
    public Guid Id { get; set; }
    public int TableNumber { get; set; }
    public TabStatusEnum Status { get; set; }
    public decimal Total { get; set; }
    public ICollection<PaymentModel> Payments { get; set; }
    
    public TabModel(int tableNumber)
    {
        Id = Guid.NewGuid();
        TableNumber = tableNumber;
        Status = TabStatusEnum.Opened;
        Payments = new List<PaymentModel>();
        Total = 0;
    }
}