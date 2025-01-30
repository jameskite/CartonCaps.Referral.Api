using CartonCaps.Referral.Api.Contracts.Dtos;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace CartonCaps.Referral.Api.Contracts.Query
{
    public class GetReferralRequest : IRequest<ReferralDto?>
    {
        [SwaggerSchema(Description = "Unique referral key")]
        public required string ReferralId { get; set; }
    }
}
