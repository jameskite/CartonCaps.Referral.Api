using AutoFixture;
using CartonCaps.Referral.Api.Application.Query;
using CartonCaps.Referral.Api.Contracts.Dtos;
using CartonCaps.Referral.Api.Contracts.Query;
using CartonCaps.Referral.Infrastructure.Abstractions;
using FluentAssertions;
using NSubstitute;

namespace CartonCaps.Referral.Api.UnitTests.Application.Query
{
    public class GetReferralsHandlerTests
    {
        private readonly IReferralQueryRepository _repository;
        private readonly Fixture _fixture;
        private readonly GetReferralsHandler _handler;

        public GetReferralsHandlerTests()
        {
            _repository = Substitute.For<IReferralQueryRepository>();
            _fixture = new Fixture();
            _handler = new GetReferralsHandler(_repository);
        }

        [Fact]
        public async Task Handle_ShouldReturnListOfReferralsForCode()
        {
            // Arrange
            var referralCode = _fixture.Create<string>();
            var mockReferralList = _fixture.CreateMany<ReferralDto>();
            var request = new GetReferralsRequest { ReferralCode = referralCode };

            _repository.GetReferrals(Arg.Any<string>(), null, null).Returns(mockReferralList);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(mockReferralList);
            await _repository.Received(1).GetReferrals(referralCode, null, null);

        }

        [Fact]
        public async Task Handle_ShouldReturnEmptyList_WhenNoReferralsFound()
        {
            // Arrange
            var referralCode = _fixture.Create<string>();
            var emptyList = new List<ReferralDto>();
            var request = new GetReferralsRequest { ReferralCode = referralCode };

            _repository.GetReferrals(Arg.Any<string>(), null, null).Returns(emptyList);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
            await _repository.Received(1).GetReferrals(referralCode, null, null);

        }
    }
}
