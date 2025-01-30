using CartonCaps.Referral.Api.Contracts.Dtos;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace CartonCaps.Referral.Api.Contracts.Query
{
    public sealed class GetReferralsRequest : IRequest<IEnumerable<ReferralDto>>
    {
        [SwaggerSchema(Description = "User's unique code to refer friends.")]
        public required string ReferralCode { get; set; }

        [SwaggerSchema(Description = "If implementing paging, how many referrees to return at a time")]
        public int? PageSize { get; set; }

        [SwaggerSchema(Description = "If implementing paging, which page to load")]
        public int? PageStart { get; set; }
    }
}
