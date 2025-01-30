using AutoFixture;
using CartonCaps.Referral.Api.Application.Query;
using CartonCaps.Referral.Api.Contracts.Dtos;
using CartonCaps.Referral.Api.Contracts.Query;
using CartonCaps.Referral.Infrastructure.Abstractions;
using FluentAssertions;
using NSubstitute;

namespace CartonCaps.Referral.Api.UnitTests.Application.Query
{
    public class GetReferralHandlerTests
    {
        private readonly IReferralQueryRepository _repository;
        private readonly Fixture _fixture;
        private readonly GetReferralHandler _handler;

        public GetReferralHandlerTests()
        {
            _repository = Substitute.For<IReferralQueryRepository>();
            _fixture = new Fixture();
            _handler = new GetReferralHandler(_repository);
        }

        [Fact]
        public async Task Handle_ShouldReturnReferral_WhenExists()
        {
            // Arrange
            var mockReferral = _fixture.Create<ReferralDto>();
            var request = new GetReferralRequest { ReferralId = mockReferral.ReferralId };

            _repository.GetReferral(Arg.Any<string>()).Returns(mockReferral);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(mockReferral);
            await _repository.Received(1).GetReferral(mockReferral.ReferralId);

        }
    }
}
