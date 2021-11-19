using System.ComponentModel.DataAnnotations;

namespace SLAMobileApi.DomainModels
{
    public class Savings : SlaBaseMoneyType
    {
        public ProductType ProductType { get; set; } = ProductType.Savings;
        [Required]
        public SavingsFrequency SavingsFrequency { get; set; }
    }
}