namespace Core.Domain;

public class SrnpPrice
{
    public int Id { get; set; }
    public int PriceCategory { get; set; }
    public string[]? Numbers { get; set; }
    public string? Price { get; set; }
    public string? PriceInMci { get; set; }
    public bool IsSameLetter { get; set; }
}