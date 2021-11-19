using System.Text.Json.Serialization;

namespace SLAMobileApi.Dtos;

public class CreateChallengeInputModel
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
        
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
        
    [JsonPropertyName("interest")]
    public double InterestRate { get; set; }
        
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; } // percentage of monthly income

    [JsonPropertyName("complete")]
    public bool ChallengeAccepted { get; set; }
        
    [JsonPropertyName("duration")]
    public int Duration { get; set; }
        
    [JsonPropertyName("fundsInvested")]
    public string InvestmentType { get; set; } = string.Empty;
        
    [JsonPropertyName("monthyIncome")]
    public decimal MonthlyIncome { get; set; }
        
    [JsonPropertyName("estimatedInterest")]
    public decimal EstimatedInterest { get; set; }
    
    [JsonPropertyName("incomePercentage")]
    public double IncomePercentage { get; set; }
}

public class CreateChallengeResponse
{
    public CreateChallengeResponse(bool challengeAccepted, string message, decimal amountLocked, int duration)
    {
        ChallengeAccepted = challengeAccepted;
        Message = message ?? "No Message sent!";
        AmountLocked = amountLocked;
        Duration = duration;
    }
    public bool ChallengeAccepted { get; }

    public string Message { get; }

    public decimal AmountLocked { get; }

    public int Duration { get; }
}
    
public class ChallengeDashboardViewModel
{
    [JsonPropertyName("start")]
    public DateTimeOffset StartDate { get; set; }

    public DateTimeOffset WithdrawalDate { get; set; }

    public decimal InterestEarned { get; set; }

    public bool Active { get; set; }

    public List<ChallengeTransations> Transactions { get; set; } = new();

    public double PercentageInterest { get; set; }

    public int NumberOfDaysLeft { get; set; }
}

public class TopUp
{
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }

    [JsonPropertyName("topupDate")]
    public DateTimeOffset TopUpDate { get; set; }
}

public class Withdrawal
{
    [JsonPropertyName("amount")]
    public decimal AmountWithdrawn { get; set; }

    [JsonPropertyName("withdrawalDate")]
    public DateTimeOffset WithdrawalDate { get; set; }
}

public class ChallengeTransations
{
    public ChallengeTransations()
    {
        TopUps = new();
        Withdrawals = new();
    }
    public List<TopUp> TopUps { get; set; }

    public List<Withdrawal> Withdrawals { get; set; }
}