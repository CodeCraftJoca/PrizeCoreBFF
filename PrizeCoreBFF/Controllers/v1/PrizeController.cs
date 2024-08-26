using Microsoft.AspNetCore.Mvc;
using PrizeCoreBFF.Application.DTO;
using PrizeCoreBFF.Application.Interfaces;

namespace PrizeCoreBFF.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PrizeController : ControllerBase
    {
        private readonly IGetPrizeUseCase _getPrizeUseCase;
        public PrizeController(IGetPrizeUseCase getPrizeUseCase )
        {
            _getPrizeUseCase = getPrizeUseCase;
        }


        /// <summary>
        /// Obtém os termos e condições e detalhes do prêmio.
        /// </summary>
        /// <param name="prizeId">O identificador único do prêmio.</param>
        /// <response code="200">Retorna os detalhes do prêmio.</response>
        /// <response code="404">Prêmio não encontrado.</response>
        [HttpGet("{prizeId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetPrizeDrawDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        [Produces("application/json")]
        public async Task<IActionResult> GetPrizeAsync(int prizeId)
        {
            var prize = await _getPrizeUseCase.GetPrizeAsync(prizeId);
            return prize != null ? Ok(prize) : NotFound();
        }



    }
}
