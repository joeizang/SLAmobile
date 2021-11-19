using System.Text.Json.Serialization;

namespace SLAMobileApi.Dtos;

public class CreateStashInputModel
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
        
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
        
    [JsonPropertyName("interest")]
    public double InterestRate { get; set; }
        
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; } // percentage of monthly income

    [JsonPropertyName("duration")]
    public int Duration { get; set; }

    [JsonPropertyName("withdrawalDate")]
    public DateTimeOffset WithdrawalDate { get; set; }
        
    [JsonPropertyName("estimatedInterest")]
    public decimal InterestEarned { get; set; }
}

public class CreateStashResponse
{
    public CreateStashResponse(string message)
    {
        Message = message;
    }
    public string Message { get; }
}