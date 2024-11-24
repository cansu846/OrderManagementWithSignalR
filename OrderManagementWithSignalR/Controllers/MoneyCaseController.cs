using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]

	[ApiController]
	public class MoneyCaseController: ControllerBase
	{
		private IMoneyCaseService _moneyCaseService;
        public MoneyCaseController(IMoneyCaseService moneyCaseService)
        {
            _moneyCaseService = moneyCaseService;
        }

        [HttpGet("TotalMoneyCaseAmount")]
		public IActionResult TotalMoneyCaseAmount()
		{
			return Ok(_moneyCaseService.TotalMoneyCaseAmount());
		}

	}
}
