using System.ComponentModel.DataAnnotations;

namespace SLAMobileApi.DomainModels
{
    public class Challenge : SlaBaseMoneyType
    {
        [Required]
        public int Duration { get; set; }
        [Required]
        public decimal MonthlyIncome { get; set; }

        public ProductType ProductType { get; set; } = ProductType.Challenge;
        
        public double IncomePercentage { get; set; }

        public bool ChallengeAccepted { get; set; }
        
        // public string InvestmentType { get; set; } // --> fundsInvested
    }
}