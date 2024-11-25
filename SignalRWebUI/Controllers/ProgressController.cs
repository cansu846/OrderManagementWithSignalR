using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
	public class ProgressController:Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
