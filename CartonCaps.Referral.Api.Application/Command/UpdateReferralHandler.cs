using CartonCaps.Referral.Api.Contracts.Command;
using CartonCaps.Referral.Api.Contracts.Dtos;
using CartonCaps.Referral.Infrastructure.Abstractions;
using MediatR;

namespace CartonCaps.Referral.Api.Application.Command
{
    public class UpdateReferralHandler : IRequestHandler<UpdateReferralRequest, ReferralDto>
    {
        private readonly IReferralCommandRepository _referralCommandRepository;
        private readonly IReferralQueryRepository _referralQueryRepository;

        public UpdateReferralHandler(IReferralCommandRepository referralCommandRepository, IReferralQueryRepository referralQueryRepository)
        {
            _referralCommandRepository = referralCommandRepository;
            _referralQueryRepository = referralQueryRepository;
        }

        public async Task<ReferralDto> Handle(UpdateReferralRequest request, CancellationToken cancellationToken)
        {
            // look up existing referral by id
            var referral = await _referralQueryRepository.GetReferral(request.ReferralId);
            if (referral == null)
            {
                throw new Exception($"Referral with Id {request.ReferralId} does not exist");
            }

            // validate the referral code from link matches from link creation
            if (referral.ReferralCode != request.ReferralCode)
            {
                throw new Exception("The referral code in the link is not valid");
            }

            // Update the status
            referral.Status = request.Status;
            referral.Name = request.Name;

            // Persist change
            await _referralCommandRepository.SaveReferralAsync(referral);

            return referral;
        }
    }
}
