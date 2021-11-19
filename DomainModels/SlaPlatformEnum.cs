using System.ComponentModel;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SLAMobileApi.DomainModels
{
    [JsonConverter(typeof(EnumToStringConverter<ProductType>))]
    public enum ProductType
    {
        [Description("challenge")]
        Challenge,
        [Description("stash")]
        Stash,
        [Description("savings")]
        Savings
    }

    [JsonConverter(typeof(EnumToStringConverter<SavingsFrequency>))]
    public enum SavingsFrequency
    {
        [Description("daily")]
        Daily,
        [Description("weekly")]
        Weekly,
        [Description("monthly")]
        Monthly
    }
}