using AutoFixture;
using CartonCaps.Referral.Api.Application.Command;
using CartonCaps.Referral.Api.Contracts.Command;
using CartonCaps.Referral.Api.Contracts.Dtos;
using CartonCaps.Referral.Infrastructure.Abstractions;
using FluentAssertions;
using NSubstitute;

namespace CartonCaps.Referral.Api.UnitTests.Application.Command
{
    public class CreateReferralHandlerTests
    {
        private readonly IReferralCommandRepository _repository;
        private readonly Fixture _fixture;
        private readonly CreateReferralHandler _handler;

        public CreateReferralHandlerTests()
        {
            _repository = Substitute.For<IReferralCommandRepository>();
            _fixture = new Fixture();
            _handler = new CreateReferralHandler(_repository);
        }

        [Fact]
        public async Task Handle_ShouldCreateAndSaveNewReferral_GivenReferralCode()
        {
            // Arrange
            var request = _fixture.Create<CreateReferralRequest>();

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.ReferralCode.Should().BeEquivalentTo(request.ReferralCode);
        }

        [Fact]
        public async Task Handle_ShouldPesistNewReferral()
        {
            // Arrange
            var request = _fixture.Create<CreateReferralRequest>();

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            await _repository.Received(1).SaveReferralAsync(Arg.Any<ReferralDto>());
        }

    }
}
