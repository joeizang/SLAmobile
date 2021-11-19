using System.ComponentModel.DataAnnotations;

namespace SLAMobileApi.DomainModels
{
    public class Stash : SlaBaseMoneyType
    {
        [Required]
        public int Duration { get; set; }

        public ProductType ProductType { get; set; } = ProductType.Stash;
    }
}