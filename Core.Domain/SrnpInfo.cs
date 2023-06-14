namespace Core.Domain;

public class SrnpInfo
{
    public int Id { get; set; }
    public string[]? GrnzType { get; set; }
    public string? Regex { get; set; }
    public int Number { get; set; }
    public int Series { get; set; }
    public int Region { get; set; }
    public int GovCode { get; set; }
    public string? Color { get; set; }
    public string[]? TypePerson { get; set; }
    public string[]? TechCategory { get; set; }
    public string[]? SrnpCode { get; set; }
    public Dictionary<string,string>? SrnpTypeCode { get; set; } 
    public int SrnpCount { get; set; }
}