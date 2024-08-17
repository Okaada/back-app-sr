using back_app_sr.Domain.Models.Payment;

namespace back_app_sr.Domain.Models.Deliver;

public class DeliveryRegisterModel //Has a similar function than Tab
{
    public Guid Id { get; set; }
    public string Address { get; set; } //for instance we are going to use just an string, later we will add an class
    public string Name { get; set; }
    public decimal Amount  { get; set; }
    public DateTime DeliveryTime { get; set; }
    
    public IReadOnlyCollection<PaymentModel> Payments { get; set; }
    
}