namespace back_app_sr.Domain.Models.Items;

public class AdditionalModel
{
    public int Id { get; set; }
    public string Name { get; private set; }
    public decimal Value { get; private set; }
    
    public AdditionalModel(string name, decimal value)
    {
        Name = name;
        Value = value;
    }

    public void UpdateAdditional(string name, decimal value)
    {
        Name = name;
        Value = value;
    }
}