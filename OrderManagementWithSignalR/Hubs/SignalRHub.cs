using DataAccess.Concrete;
using Microsoft.AspNetCore.SignalR;

namespace WebApi.Hubs
{
	public class SignalRHub:Hub
	{
		//Contructor kullanmadıgımız için program.cs te configurasyon yapmadık
		SignalRDbContext context = new SignalRDbContext();

		public async Task SendCategoryCount()
		{
			var value = context.Categories.Count();
			await Clients.All.SendAsync("ReceiveCategoryCount", value);
		}

	}
}
