using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace CartonCaps.Referral.Api.Contracts.Command
{
    public class DeleteReferralRequest : IRequest<Unit>
    {
        [SwaggerSchema(Description = "The key for the referral to delete")]
        public required string ReferralId { get; set; }
    }
}
