using Core.Domain;

namespace Core.Application.DTOs;

public class SrnpResultDto
{
    
    public string? Srnp { get; set; }
    public string? SrnpType { get; set; }
    public string? SrnpNumber { get; set; }
    public string? SrnpSeries { get; set; }
    public string? SrnpRegion { get; set; }
    public string? SrnpGovCode { get; set; }
    public string? SrnpColor { get; set; }
    public int? SrnpPriceCategory { get; set; }
    public string? SrnpPriceInMci { get; set; }
    public string[]? TypePerson { get; set; }
    public string[]? TechCategory { get; set; }
    public string? SrnpCode { get; set; }
    public bool? IsForbiddenSeries { get; set; }
}