namespace back_app_sr.Domain.Models;

public class AdditionalModel
{
    public int AdditionalId { get; set; }
    public string Name { get; set; }
    public decimal Value { get; set; }

    public AdditionalModel(int additionalId)
    {
        AdditionalId = additionalId;
    }
    
    public AdditionalModel(string name, decimal value)
    {
        Name = name;
        Value = value;
    }
}