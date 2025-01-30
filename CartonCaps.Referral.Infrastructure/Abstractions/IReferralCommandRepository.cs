using CartonCaps.Referral.Api.Contracts.Dtos;

namespace CartonCaps.Referral.Infrastructure.Abstractions
{
    public interface IReferralCommandRepository
    {
        Task SaveReferralAsync(ReferralDto newReferral);
        Task DeleteReferralAsync(string referralId);
    }
}
