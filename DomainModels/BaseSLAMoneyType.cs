using System.ComponentModel.DataAnnotations;

namespace SLAMobileApi.DomainModels
{
    public abstract class SlaBaseMoneyType
    {
        public SlaBaseMoneyType()
        {
            Id = $"{Guid.NewGuid():N}{DateTimeOffset.UtcNow.LocalDateTime.Ticks.ToString()}";
        }
        [Required]
        [StringLength(200)]
        public string Id { get; set; }

        [Required] [StringLength(150)] public string Name { get; set; } = string.Empty;

        [StringLength(150)] public string Description { get; set; } = string.Empty;
        
        [Required]
        public double InterestRate { get; set; }
        
        [Required]
        public decimal Amount { get; set; } // percentage of monthly income
        
        [Required]
        public decimal EstimatedInterest { get; set; }
        
        [Required]
        public DateTimeOffset StartDate { get; set; }
        
        [Required]
        public DateTimeOffset WithdrawalDate { get; set; } // --> WithdrawalDate
        
        public string UserId { get; set; } = string.Empty;
        
        public string CowryWiseId { get; set; } = string.Empty;
        
        public string CowryWiseProductId { get; set; } = string.Empty;
        
        public decimal TargetAmount { get; set; }
        
        public DateTimeOffset CreatedAt { get; set; }

    }
}