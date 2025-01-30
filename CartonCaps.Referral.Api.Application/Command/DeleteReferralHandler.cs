using CartonCaps.Referral.Api.Contracts.Command;
using CartonCaps.Referral.Infrastructure.Abstractions;
using MediatR;

namespace CartonCaps.Referral.Api.Application.Command
{
    public class DeleteReferralHandler : IRequestHandler<DeleteReferralRequest, Unit>
    {
        private readonly IReferralCommandRepository _referralCommandRepository;

        public DeleteReferralHandler(IReferralCommandRepository referralCommandRepository)
        {
            _referralCommandRepository = referralCommandRepository;
        }
        public async Task<Unit> Handle(DeleteReferralRequest request, CancellationToken cancellationToken)
        {
            await _referralCommandRepository.DeleteReferralAsync(request.ReferralId);
            return Unit.Value;
        }

    }
}
