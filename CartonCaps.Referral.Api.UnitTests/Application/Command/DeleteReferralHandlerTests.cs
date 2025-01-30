using AutoFixture;
using CartonCaps.Referral.Api.Application.Command;
using CartonCaps.Referral.Api.Contracts.Command;
using CartonCaps.Referral.Infrastructure.Abstractions;
using FluentAssertions;
using MediatR;
using NSubstitute;

namespace CartonCaps.Referral.Api.UnitTests.Application.Command
{
    public class DeleteReferralHandlerTests
    {
        private readonly IReferralCommandRepository _repository;
        private readonly Fixture _fixture;
        private readonly DeleteReferralHandler _handler;

        public DeleteReferralHandlerTests()
        {
            _repository = Substitute.For<IReferralCommandRepository>();
            _fixture = new Fixture();
            _handler = new DeleteReferralHandler(_repository);
        }

        [Fact]
        public async Task Handle_ShouldCallTheDeleteRepository_WithReferralId()
        {
            // Arrange
            var request = _fixture.Create<DeleteReferralRequest>();

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().Be(Unit.Value);
            await _repository.Received(1).DeleteReferralAsync(request.ReferralId);
        }

    }
}
