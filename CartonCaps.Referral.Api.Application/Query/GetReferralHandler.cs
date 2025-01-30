using CartonCaps.Referral.Api.Contracts.Dtos;
using CartonCaps.Referral.Api.Contracts.Query;
using CartonCaps.Referral.Infrastructure.Abstractions;
using MediatR;

namespace CartonCaps.Referral.Api.Application.Query
{
    public class GetReferralHandler : IRequestHandler<GetReferralRequest, ReferralDto?>
    {
        private readonly IReferralQueryRepository _referralQueryRepository;
        public GetReferralHandler(IReferralQueryRepository referralQueryRepository)
        {
            _referralQueryRepository = referralQueryRepository;
        }
        public Task<ReferralDto?> Handle(GetReferralRequest request, CancellationToken cancellationToken)
        {
            return _referralQueryRepository.GetReferral(request.ReferralId);
        }
    }
}
