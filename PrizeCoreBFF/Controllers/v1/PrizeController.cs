using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{prizeId}")]
        public async Task<IActionResult> GetPrizeAsync(int prizeId)
        {
            var prize = await _getPrizeUseCase.GetPrizeAsync(prizeId);
            return Ok(prize);
        }

    }
}
