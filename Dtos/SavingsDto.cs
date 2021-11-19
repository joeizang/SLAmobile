using System.Text.Json.Serialization;

namespace SLAMobileApi.Dtos;

public class CreateSavingsInputModel
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
        
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
        
    [JsonPropertyName("interest")]
    public double InterestRate { get; set; }
        
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; } // percentage of monthly income

    [JsonPropertyName("savingFrequency")]
    public string SavingFrequency { get; set; } = string.Empty;

    [JsonPropertyName("startDate")]
    public DateTimeOffset StartDate { get; set; }
    
    [JsonPropertyName("withdrawalDate")]
    public DateTimeOffset WithdrawalDate { get; set; }
}

public class CreateSavingsResponse
{
    public CreateSavingsResponse(string message, string title)
    {
        Message = message;
        Title = title;
    }
    public string Message { get; }

    public string Title { get; }
}