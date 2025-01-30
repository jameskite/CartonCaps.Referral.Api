using CartonCaps.Referral.Api.Contracts.Enumerations;

namespace CartonCaps.Referral.Api.Contracts.Dtos
{
    public sealed class UpdateReferralDto
    {
        public required string ReferralCode { get; set; }
        public Status Status { get; set; }
        public string? Name { get; set; }
    }
}
