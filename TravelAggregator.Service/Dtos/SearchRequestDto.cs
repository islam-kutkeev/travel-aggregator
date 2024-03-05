namespace TravelAggregator.Service.Dtos;

public class SearchRequestDto
{
    public DateTimeOffset? FromDate { get; set; }
    public DateTimeOffset? ToDate { get; set; }
    public float? MinPrice { get; set; }
    public float? MaxPrice { get; set; }
    public int? MinLayovers { get; set; }
    public int? MaxLayovers { get; set; }
    public string? Company { get; set; }
    public string? SortBy { get; set; }
}
