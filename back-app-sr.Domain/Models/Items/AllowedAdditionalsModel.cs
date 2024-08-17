namespace back_app_sr.Domain.Models.Items;

public class AllowedAdditionalsModel
{
    public Guid Id { get; private set; }
    public int ItemId { get; set; }
    public ItemModel Item { get; set; }
    public int AdditionalId { get; set; }
    public AdditionalModel AdditionalModel { get; set; }

    public AllowedAdditionalsModel(Guid allowedId, int itemId, int additionalId)
    {
        Id = allowedId;
        ItemId = itemId;
        AdditionalId = additionalId;
    }

    private AllowedAdditionalsModel(){}
}
