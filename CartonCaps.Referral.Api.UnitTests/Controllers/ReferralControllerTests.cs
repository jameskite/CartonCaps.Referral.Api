using AutoFixture;
using CartonCaps.Referral.Api.Contracts.Command;
using CartonCaps.Referral.Api.Contracts.Dtos;
using CartonCaps.Referral.Api.Contracts.Query;
using CartonCaps.Referral.Api.Controllers;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace CartonCaps.Referral.Api.UnitTests.Controllers
{
    public class ReferralControllerTests
    {
        private readonly IMediator _mediator;
        private readonly ReferralController _controller;
        private readonly Fixture _fixture;

        public ReferralControllerTests()
        {
            _mediator = Substitute.For<IMediator>();
            _controller = new ReferralController(_mediator);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task GetReferral_ShouldReturnOk_WhenValidRequest()
        {
            // Arrange
            var request = _fixture.Create<GetReferralRequest>();
            var mockResult = _fixture.Create<ReferralDto>();
            _mediator.Send(request).Returns(mockResult);

            // Act
            var result = await _controller.GetReferral(request);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            await _mediator.Received(1).Send(request);
        }

        [Fact]
        public async Task GetReferrals_ShouldReturnOk_WhenValidRequest()
        {
            // Arrange
            var request = _fixture.Create<GetReferralsRequest>();
            var mockResult = _fixture.CreateMany<ReferralDto>();
            _mediator.Send(request).Returns(mockResult);

            // Act
            var result = await _controller.GetReferrals(request);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            await _mediator.Received(1).Send(request);
        }

        [Fact]
        public async Task CreateReferral_ShouldReturnOk_WhenValidRequest()
        {
            // Arrange
            var request = _fixture.Create<CreateReferralRequest>();
            var mockResult = _fixture.Create<ReferralDto>();
            _mediator.Send(request).Returns(mockResult);

            // Act
            var result = await _controller.CreateReferral(request);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            await _mediator.Received(1).Send(request);
        }

        [Fact]
        public async Task UpdateReferral_ShouldReturnOk_WhenValidRequest()
        {
            // Arrange
            var request = _fixture.Create<UpdateReferralRequest>();
            var mockResult = _fixture.Create<ReferralDto>();
            _mediator.Send(request).Returns(mockResult);

            // Act
            var result = await _controller.UpdateReferral(request.ReferralId, new UpdateReferralDto { ReferralCode = request.ReferralCode, Name = request.Name, Status = request.Status });

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            await _mediator.Received(1).Send(Arg.Any<UpdateReferralRequest>());
        }

        [Fact]
        public async Task DeleteReferral_ShouldReturnOk_WhenValidRequest()
        {
            // Arrange
            var request = _fixture.Create<DeleteReferralRequest>();
            _mediator.Send(request).Returns(Unit.Value);

            // Act
            var result = await _controller.DeleteReferral(request);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            await _mediator.Received(1).Send(request);
        }
    }
}
