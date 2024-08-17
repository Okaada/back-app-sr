namespace back_app_sr.Domain.Models.Items;

public class ItemOrderAdditionalModel
{
    public Guid Id { get; set; }
    public int ItemId { get; set; }
    public ItemModel Item { get; set; }
    public int Quantity { get; set; }
    public int AdditionalId { get; set; }
    public AdditionalModel AdditionalModel { get; set; }
}