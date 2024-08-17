namespace back_app_sr.Domain.Models.Items;

public class AdditionalModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Value { get; set; }
    
    public AdditionalModel(string name, decimal value)
    {
        Name = name;
        Value = value;
    }
}