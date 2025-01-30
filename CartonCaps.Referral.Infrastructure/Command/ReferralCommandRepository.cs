using CartonCaps.Referral.Infrastructure.Abstractions;

namespace CartonCaps.Referral.Infrastructure.Command
{
    public class ReferralCommandRepository : IReferralCommandRepository
    {

        public Task SaveReferralAsync(Api.Contracts.Dtos.ReferralDto newReferral)
        {
            // save new referral to persistence storage

            return Task.CompletedTask;
        }



        public Task DeleteReferralAsync(string referralId)
        {
            // remove the referral making call to persistence layer

            return Task.CompletedTask;
        }

    }
}
