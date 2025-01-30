using CartonCaps.Referral.Api.Contracts.Dtos;
using CartonCaps.Referral.Api.Contracts.Enumerations;
using CartonCaps.Referral.Infrastructure.Abstractions;

namespace CartonCaps.Referral.Infrastructure.Query
{
    public class ReferralQueryRepository : IReferralQueryRepository
    {
        public Task<IEnumerable<ReferralDto>> GetReferrals(string referralCode, int? pageSize, int? pageStart)
        {
            // read data from persistence 

            IEnumerable<ReferralDto> referrals = new List<ReferralDto>
            {
                new ReferralDto { ReferralId = "A1B2C3D4", ReferralCode = referralCode, ReferralLink = "https://cartoncaps.link/A1B2C3D4?referralCode=X9Z7QK", Status = Status.New, Name = "Alice Johnson" },
                new ReferralDto { ReferralId = "E5F6G7H8", ReferralCode = referralCode, ReferralLink = "https://cartoncaps.link/E5F6G7H8?referralCode=3YTPW2", Status = Status.Pending, Name = "Bob Smith" },
                new ReferralDto { ReferralId = "I9J0K1L2", ReferralCode = referralCode, ReferralLink = "https://cartoncaps.link/I9J0K1L2?referralCode=Q5X4ND", Status = Status.Complete, Name = "Charlie Brown" },
                new ReferralDto { ReferralId = "M3N4O5P6", ReferralCode = referralCode, ReferralLink = "https://cartoncaps.link/M3N4O5P6?referralCode=7ZV8WR", Status = Status.Expired, Name = "Diana Prince" },
                new ReferralDto { ReferralId = "Q7R8S9T0", ReferralCode = referralCode, ReferralLink = "https://cartoncaps.link/Q7R8S9T0?referralCode=1TQK3P", Status = Status.New, Name = "Ethan Carter" },
                new ReferralDto { ReferralId = "U1V2W3X4", ReferralCode = referralCode, ReferralLink = "https://cartoncaps.link/U1V2W3X4?referralCode=B6NCZ8", Status = Status.Pending, Name = "Fiona Gallagher" },
                new ReferralDto { ReferralId = "Y5Z6A7B8", ReferralCode = referralCode, ReferralLink = "https://cartoncaps.link/Y5Z6A7B8?referralCode=PX9WR2", Status = Status.Complete, Name = "George Bailey" },
                new ReferralDto { ReferralId = "C9D0E1F2", ReferralCode = referralCode, ReferralLink = "https://cartoncaps.link/C9D0E1F2?referralCode=8VTQLK", Status = Status.Expired, Name = "Hannah Montana" },
                new ReferralDto { ReferralId = "G3H4I5J6", ReferralCode = referralCode, ReferralLink = "https://cartoncaps.link/G3H4I5J6?referralCode=5ZKXNP", Status = Status.New, Name = "Isaac Newton" },
                new ReferralDto { ReferralId = "K7L8M9N0", ReferralCode = referralCode, ReferralLink = "https://cartoncaps.link/K7L8M9N0?referralCode=W1B2QT", Status = Status.Pending, Name = "Julia Roberts" }
            };

            // return mock data for now
            return Task.FromResult(referrals);
        }

        public Task<ReferralDto?> GetReferral(string referralId)
        {
            // Connect to the persistence layer here - stored procedure / EF - to look up referral by referralId.
            // Could use this to validate the referral code is valid

            // return mock data for now
            ReferralDto? singleReferral = new ReferralDto
            {
                ReferralId = referralId,  // returned object should have the same id as passed in
                ReferralCode = "A1C3D9",
                ReferralLink = $"https://cartoncaps.link/{referralId}?referralCode=A1C3D9",
                Status = Status.Complete   // Assigning a different status for variety
            };

            return Task.FromResult(singleReferral);
        }
    }
}
