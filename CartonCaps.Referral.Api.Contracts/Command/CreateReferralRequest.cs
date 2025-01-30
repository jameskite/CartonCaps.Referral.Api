using CartonCaps.Referral.Api.Contracts.Dtos;
using MediatR;

namespace CartonCaps.Referral.Api.Contracts.Command
{
    public sealed class CreateReferralRequest : IRequest<ReferralDto>
    {
        public required string ReferralCode { get; set; }

    }
}
