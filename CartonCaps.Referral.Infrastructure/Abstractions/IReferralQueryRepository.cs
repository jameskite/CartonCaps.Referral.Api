using CartonCaps.Referral.Api.Contracts.Dtos;

namespace CartonCaps.Referral.Infrastructure.Abstractions
{
    public interface IReferralQueryRepository
    {
        Task<IEnumerable<ReferralDto>> GetReferrals(string referralCode, int? pageSize, int? pageStart);
        Task<ReferralDto?> GetReferral(string referralId);
    }
}
