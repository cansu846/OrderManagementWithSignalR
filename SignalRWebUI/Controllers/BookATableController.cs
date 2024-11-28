using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SignalRWebUI.Controllers
{
    public class BookATableController:Controller
    {
        IHttpClientFactory _httpClientFactory;

        public BookATableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {

            return View();
        }
        
    }
}
