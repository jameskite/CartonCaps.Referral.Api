using CartonCaps.Referral.Api.Contracts.Command;
using CartonCaps.Referral.Api.Contracts.Dtos;
using CartonCaps.Referral.Infrastructure.Abstractions;
using MediatR;

namespace CartonCaps.Referral.Api.Application.Command
{
    public class CreateReferralHandler : IRequestHandler<CreateReferralRequest, ReferralDto>
    {
        private readonly IReferralCommandRepository _referralCommandRepository;

        public CreateReferralHandler(IReferralCommandRepository referralCommandRepository)
        {
            _referralCommandRepository = referralCommandRepository;
        }

        public async Task<ReferralDto> Handle(CreateReferralRequest request, CancellationToken cancellationToken)
        {
            // generate key for new referral
            var shortId = GenerateShortGuid();

            // create new referral with code passed in 
            var newReferral = new ReferralDto()
            {
                ReferralId = shortId,
                ReferralCode = request.ReferralCode,
                ReferralLink = $"https://cartoncaps.link/{shortId}?referralCode={request.ReferralCode}",
                Status = Contracts.Enumerations.Status.New
            };

            // persist new referral
            await _referralCommandRepository.SaveReferralAsync(newReferral);

            return newReferral;
        }

        static string GenerateShortGuid()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray())
                .Replace("+", "")
                .Replace("/", "")
                .Replace("=", "")
                .Substring(0, 8); // Keeping it short
        }

    }
}
