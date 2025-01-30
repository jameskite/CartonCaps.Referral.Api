using CartonCaps.Referral.Api.Contracts.Command;
using CartonCaps.Referral.Api.Contracts.Dtos;
using CartonCaps.Referral.Api.Contracts.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CartonCaps.Referral.Api.Controllers
{
    [ApiController]
    public class ReferralController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReferralController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets a list of referrals based on a users referral code
        /// </summary>
        /// <param name="request">This includes the user's unique code, and paging options in case there are a lot of referrees</param>
        /// <returns>List of referrals</returns>
        /// <response code="200">Returns the list of referred users OR empty list if no referrees</response>
        /// <response code="404">Referrer code was invalid</response>
        [Route("/Referrals")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ReferralDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetReferrals([FromQuery] GetReferralsRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Get single referral to validate referee when link clicked.
        /// Could also be used to lazy load additional details on each referree 
        /// </summary>
        /// <param name="request"></param>
        /// <response code="200">Returns the single referral by Id</response>
        /// <response code="404">Referral Id does not exist</response>
        [Route("/Referrals/{ReferralId}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ReferralDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        // 
        // 
        public async Task<IActionResult> GetReferral([FromRoute] GetReferralRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);

        }


        /// <summary>
        /// Generate a new referral with referral link based on user's unique code
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     POST /Referrals
        ///     {
        ///         "ReferralCode": "ABC123"
        ///     }
        ///     
        /// </remarks>
        /// <response code="200">Successfully created new referral</response>
        /// <response code="401">User does not have authorization to create new referral links</response>
        [Route("/Referrals")]
        [HttpPost]
        [ProducesResponseType(typeof(ReferralDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateReferral([FromBody] CreateReferralRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        /// <summary>
        /// Update an existing referral with a new status AND/OR capture name of user who is signing up
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     PUT /Referrals/7L8M9N0
        ///     {
        ///         "ReferralCode": "SL8eP9"
        ///         "Statue": "Pending"
        ///         "Name": "John Smith"
        ///     }
        /// 
        /// </remarks>
        /// <param name="ReferralId">Key of Referral to update</param>
        /// <response code="200">Referral was found and was updated successfully</response>
        /// <response code="404">No referral was found</response>
        /// <response code="400">Referral code is invalid</response>
        [Route("Referrals/{ReferralId}")]
        [HttpPut]
        [ProducesResponseType(typeof(IEnumerable<ReferralDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        // Update status when referee clicks on link completes sign up / internal validation 
        public async Task<IActionResult> UpdateReferral([FromRoute] string ReferralId, [FromBody] UpdateReferralDto dto)
        {
            var result = await _mediator.Send(new UpdateReferralRequest(ReferralId, dto.ReferralCode, dto.Status, dto.Name));
            return Ok(result);
        }


        /// <summary>
        /// Remove a Referral. This might be due to an expiration of the invite or you want to rescind the invite.
        /// </summary>
        /// <response code="200">Successfully removed referral</response>
        /// <response code="404">No referral was found with the provided key</response>
        /// <response code="401">User does not have access to remove referral</response>
        [ProducesResponseType(typeof(IEnumerable<ReferralDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [Route("Referrals/{ReferralId}")]
        [HttpDelete]
        // cancel referral
        public async Task<IActionResult> DeleteReferral([FromRoute] DeleteReferralRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }




    }
}
