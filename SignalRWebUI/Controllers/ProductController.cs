using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.ProductDtos;
using System.Text;



namespace SignalRWebUI.Controllers
{
	public class ProductController : Controller
	{

		private readonly IHttpClientFactory _httpClientFactory;

		public ProductController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7142/api/Product/product-detail");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ProductDetailDto>>(jsonData);
				return View(values);
			}

			return View();
		}

		//Form aracılıgı ile buraya get istegi yapılır ve Product ekleme sayfası açılır.
		[HttpGet]
		public async Task<IActionResult> CreateProduct()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7142/api/Category");
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
			List<SelectListItem> selectListItems = (from x in values
													select new SelectListItem
													{
														Text = x.CategoryName,
														Value = x.CategoryID.ToString()

													}).ToList();
			//Dropdown listesi verilerini ViewBag aracılığıyla görünüme gönderir.
			// v, burada ViewBag içinde taşıdığınız veriye verilen isimdir.
			ViewBag.v = selectListItems;
			return View();

		}

		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
		{
			createProductDto.ProductStatus = true;
			//client: diğer servislerle iletişim kurmak için kullanılır.
			var client = _httpClientFactory.CreateClient();
			// JSON formatına dönüştürülür. API'ye JSON formatında veri gönderildiği için bu işlem gereklidir
			var jsonData = JsonConvert.SerializeObject(createProductDto);
			//application/json içerik tipi, HTTP istek ve yanıtlarında kullanılan MIME türlerinden biridir.
			//JSON (JavaScript Object Notation) formatında veri gönderdiğimizi veya aldığımızı belirtmek için kullanılır.
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			//API'nin /api/Category endpointine POST isteği yapılır ve kategori oluşturma talebi gönderilir.
			var responseMessage = await client.PostAsync("https://localhost:7142/api/Product", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				//API'den başarılı bir yanıt alındıysa, kullanıcı Index metoduna yönlendirilir.
				return RedirectToAction("Index");
			}
			return View();
		}

		//HtpDelete kullanınca çalıştırdıgım proje (WebApi) yerine SignalRUI veya başka bir proje için istekte bulunuyor
		//[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProduct(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.DeleteAsync($"https://localhost:7142/api/Product/{id}");
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}


		public async Task<IActionResult> UpdateProduct(int id)
		{
			var client2 = _httpClientFactory.CreateClient();
			var responseMessage2 = await client2.GetAsync("https://localhost:7142/api/Category");
			var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
			var values2 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData2);
			List<SelectListItem> selectListItems = (from x in values2
													select new SelectListItem
													{
														Text = x.CategoryName,
														Value = x.CategoryID.ToString()

													}).ToList();
			//Dropdown listesi verilerini ViewBag aracılığıyla görünüme gönderir.
			// v, burada ViewBag içinde taşıdığınız veriye verilen isimdir.
			ViewBag.v = selectListItems;

			var client = _httpClientFactory.CreateClient();
			var responsemessage = await client.GetAsync($"https://localhost:7142/api/product/{id}");
			if (responsemessage.IsSuccessStatusCode)
			{
				var jsondata = await responsemessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsondata);
				return View(values);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsondata = JsonConvert.SerializeObject(updateProductDto);
			StringContent stringcontent = new StringContent(jsondata, Encoding.UTF8, "application/json");
			var responsemessage = await client.PutAsync("https://localhost:7142/api/Product/", stringcontent);
			if (responsemessage.IsSuccessStatusCode)
			{
				return RedirectToAction("index");
			}
			return View();
		}
	}
}
