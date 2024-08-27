using back_app_sr.Domain.Models.Payment;

namespace back_app_sr.Domain.Models.Tab;

public class TabModel
{
    public Guid Id { get; private set; }
    public int TableNumber { get; private set; }
    public TabStatusEnum Status { get; private set; }
    public decimal Total { get; private set; }
    public string Name { get; private set; }
    public ICollection<PaymentModel> Payments { get; private set; }

    public TabModel(int tableNumber, string name)
    {
        Id = Guid.NewGuid();
        TableNumber = tableNumber;
        Status = TabStatusEnum.Aberta;
        Payments = new List<PaymentModel>();
        Total = 0;
        Name = name;
    }

    public void UpdateTab(string name, string status, int table)
    {
        Name = name;
        TableNumber = table;
        if (Enum.TryParse(status, out TabStatusEnum orderStatus))
            Status = orderStatus;
        else
            throw new ArgumentException("Status inválido");

    }
}