using CartonCaps.Referral.Api.Contracts.Enumerations;

namespace CartonCaps.Referral.Api.Contracts.Dtos
{
    public sealed class ReferralDto
    {
        public required string ReferralId { get; set; }
        public required string ReferralCode { get; set; }
        public required string ReferralLink { get; set; }
        public Status Status { get; set; }
        public string? Name { get; set; }

    }
}
