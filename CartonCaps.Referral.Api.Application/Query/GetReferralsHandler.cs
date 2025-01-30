using CartonCaps.Referral.Api.Contracts.Dtos;
using CartonCaps.Referral.Api.Contracts.Query;
using CartonCaps.Referral.Infrastructure.Abstractions;
using MediatR;

namespace CartonCaps.Referral.Api.Application.Query
{
    public class GetReferralsHandler : IRequestHandler<GetReferralsRequest, IEnumerable<ReferralDto>>
    {
        private readonly IReferralQueryRepository _referralQueryRepository;
        public GetReferralsHandler(IReferralQueryRepository referralQueryRepository)
        {
            _referralQueryRepository = referralQueryRepository;
        }
        public Task<IEnumerable<ReferralDto>> Handle(GetReferralsRequest request, CancellationToken cancellationToken)
        {
            var result = _referralQueryRepository.GetReferrals(request.ReferralCode, request?.PageSize, request?.PageStart);
            return result;
        }
    }
}
