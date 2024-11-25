using Business.Abstract;
using DataAccess.Concrete;
using Microsoft.AspNetCore.SignalR;

namespace WebApi.Hubs
{
	public class SignalRHub:Hub
	{
		//Contructor kullanmadıgımız için program.cs te configurasyon yapmadık
		//SignalRDbContext context = new SignalRDbContext();

		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;

        public SignalRHub(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
			_productService = productService;
        }

		// Asenkron bir metodun, tamamlandığında bir sonuç döndürmesi gerekmez.
		// Eğer döndürmüyorsa, metot Task türünde olur.
		// Eğer sonuç döndürüyorsa, Task<T> türünde olur
		public async Task SendCategoryCount()
		{
			//var value = context.Categories.Count();
			var value = _categoryService.CategoryCount();
			await Clients.All.SendAsync("ReceiveCategoryCount", value);
		}

		public async Task SendProductCount()
		{
			//var value = context.Categories.Count();
			var value = _productService.ProductCount();
			await Clients.All.SendAsync("ReceiveProductCount", value);
		}

	}
}
