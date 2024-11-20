using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRUI.Dtos.CategoryDtos;
using System.Text;

namespace SignalRUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7142/api/Category");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateCategory()
		{
			
			return View();
		}
		
        [HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
		{
            createCategoryDto.Status = true;
			//client: diğer servislerle iletişim kurmak için kullanılır.
			var client = _httpClientFactory.CreateClient();
			// JSON formatına dönüştürülür. API'ye JSON formatında veri gönderildiği için bu işlem gereklidir
			var jsonData = JsonConvert.SerializeObject(createCategoryDto);
			//application/json içerik tipi, HTTP istek ve yanıtlarında kullanılan MIME türlerinden biridir.
            //JSON (JavaScript Object Notation) formatında veri gönderdiğimizi veya aldığımızı belirtmek için kullanılır.
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			//API'nin /api/Category endpointine POST isteği yapılır ve kategori oluşturma talebi gönderilir.
			var responseMessage = await client.PostAsync("https://localhost:7142/api/Category", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
				//API'den başarılı bir yanıt alındıysa, kullanıcı Index metoduna yönlendirilir.
				return RedirectToAction("Index");   
            }
			return View();
		}
        //HtpDelete kullanınca çalıştırdıgım proje (WebApi) yerine SignalRUI veya başka bir proje için istekte bulunuyor
		//[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCategory(int id)
		{
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7142/api/Category/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
			return View();
		}
	}
}
