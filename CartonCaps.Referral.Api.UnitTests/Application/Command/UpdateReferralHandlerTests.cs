using AutoFixture;
using CartonCaps.Referral.Api.Application.Command;
using CartonCaps.Referral.Api.Contracts.Command;
using CartonCaps.Referral.Api.Contracts.Dtos;
using CartonCaps.Referral.Infrastructure.Abstractions;
using FluentAssertions;
using NSubstitute;

namespace CartonCaps.Referral.Api.UnitTests.Application.Command
{
    public class UpdateReferralHandlerTests
    {
        private readonly IReferralCommandRepository _commandRepository;
        private readonly IReferralQueryRepository _queryRepository;

        private readonly Fixture _fixture;
        private readonly UpdateReferralHandler _handler;

        public UpdateReferralHandlerTests()
        {
            _commandRepository = Substitute.For<IReferralCommandRepository>();
            _queryRepository = Substitute.For<IReferralQueryRepository>();
            _fixture = new Fixture();
            _handler = new UpdateReferralHandler(_commandRepository, _queryRepository);
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenReferralNotFound()
        {
            // Arrange
            var request = _fixture.Create<UpdateReferralRequest>();
            _queryRepository.GetReferral(Arg.Any<string>()).Returns(Task.FromResult<ReferralDto?>(null));

            // Act
            Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<Exception>().WithMessage($"Referral with Id {request.ReferralId} does not exist");
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenReferralCodeDoesNotMatch()
        {
            // Arrange
            var request = _fixture.Create<UpdateReferralRequest>();
            var mockReferral = _fixture.Create<ReferralDto>();
            _queryRepository.GetReferral(Arg.Any<string>()).Returns(mockReferral);

            // Act
            Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<Exception>().WithMessage("The referral code in the link is not valid");
        }

        [Fact]
        public async Task Handle_ShouldUpdateStatusAndName_WhenReferralFound()
        {
            // Arrange
            var mockReferral = _fixture.Create<ReferralDto>();
            var request = new UpdateReferralRequest(mockReferral.ReferralId, mockReferral.ReferralCode, mockReferral.Status, mockReferral.Name);
            _queryRepository.GetReferral(Arg.Any<string>()).Returns(mockReferral);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(mockReferral);
            await _commandRepository.Received(1).SaveReferralAsync(mockReferral);

        }

    }
}

