using CartonCaps.Referral.Api.Contracts.Dtos;
using CartonCaps.Referral.Api.Contracts.Enumerations;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace CartonCaps.Referral.Api.Contracts.Command
{
    public sealed class UpdateReferralRequest : IRequest<ReferralDto>
    {
        [SwaggerSchema(Description = "User's unique code to refer friends.")]
        public string ReferralId { get; }

        [SwaggerSchema(Description = "User's unique code to refer friends.")]
        public string ReferralCode { get; }

        [SwaggerSchema(Description = "User's unique code to refer friends.")]
        public Status Status { get; }

        [SwaggerSchema(Description = "User's unique code to refer friends.")]
        public string? Name { get; }

        public UpdateReferralRequest(string referralId, string referralCode, Status status, string? name)
        {
            ReferralId = referralId;
            ReferralCode = referralCode;
            Status = status;
            if (name != null) Name = name;

        }
    }
}
