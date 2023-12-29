namespace back_app_sr_Application.Tab.DTO;

public class OrderDTO
{
    public int ItemId { get; set; }
    public int AdditionId { get; set; }
    public int Quantity { get; set; }
    public string Note { get; set; } = string.Empty;
}