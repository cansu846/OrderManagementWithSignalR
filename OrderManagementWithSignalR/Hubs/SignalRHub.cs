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

		public async Task SendStatistic()
		{
			//var value = context.Categories.Count();
			var categoryCount = _categoryService.CategoryCount();
			await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);

			var productCount = _productService.ProductCount();
			await Clients.All.SendAsync("ReceiveProductCount", productCount);

			var activeCategoryCount = _categoryService.ActiveCategoryCount();
			await Clients.All.SendAsync("RecieveActiveCategoryCount ", activeCategoryCount);

			var passiveCategoryCount = _categoryService.PassiveCategoryCount();
			await Clients.All.SendAsync("RecievePassiveCategoryCount ", passiveCategoryCount);
		}
		

	}
}
