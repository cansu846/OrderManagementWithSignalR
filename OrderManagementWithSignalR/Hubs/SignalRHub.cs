using Business.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Pages;
using Microsoft.AspNetCore.SignalR;

namespace WebApi.Hubs
{
	public class SignalRHub : Hub
	{
		//Contructor kullanmadıgımız için program.cs te configurasyon yapmadık
		//SignalRDbContext context = new SignalRDbContext();

		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;
		private readonly IMoneyCaseService _moneyCaseService;
		private readonly IOrderService _orderService;
		private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;
		private readonly INotificationService _notificationService;


		public SignalRHub(ICategoryService categoryService, IProductService productService,
			IMoneyCaseService moneyCaseService, IOrderService orderService, IMenuTableService menuTableService,
            IBookingService bookingService, INotificationService notificationService)
		{
			_categoryService = categoryService;
			_productService = productService;
			_moneyCaseService = moneyCaseService;
			_orderService = orderService;	
			_menuTableService = menuTableService;
            _bookingService = bookingService;
			_notificationService = notificationService;
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
			await Clients.All.SendAsync("RecieveActiveCategoryCount", activeCategoryCount);
			Console.WriteLine("test");
			Console.WriteLine(activeCategoryCount);

			var passiveCategoryCount = _categoryService.PassiveCategoryCount();
			await Clients.All.SendAsync("RecievePassiveCategoryCount", passiveCategoryCount);
		}

		public async Task SendProgressbar()
		{
			var moneyCaseAmount = _moneyCaseService.TotalMoneyCaseAmount();
			await Clients.All.SendAsync("RecieveMoneyCaseAmount", moneyCaseAmount);
			Console.WriteLine("test");
			Console.WriteLine(moneyCaseAmount);

			var activeOrderCount = _orderService.ActiveOrderCount();
			await Clients.All.SendAsync("RecieveActiveOrderCount", activeOrderCount);
			Console.WriteLine("test");
			Console.WriteLine(activeOrderCount);

			var menuTableCount = _menuTableService.MenuTableCount();
			await Clients.All.SendAsync("RecieveMenuTableCount", menuTableCount);
			Console.WriteLine("test");
			Console.WriteLine(menuTableCount);

		}
        public async Task SendBookingList()
        {
            var values = _bookingService.GetAll();
            await Clients.All.SendAsync("ReceiveBookingList", values);
        }
		public async Task SendNotification()
		{
			var values = _notificationService.NotificationCountByStatusFalse();
			await Clients.All.SendAsync("ReceiveNotificationCountByStatusFalse", values);

			List<Notification> list = _notificationService.GetAllNotificationByFalse();
			await Clients.All.SendAsync("ReceiveGetAllNotificationByFalse", list);
		}
	}
    }
