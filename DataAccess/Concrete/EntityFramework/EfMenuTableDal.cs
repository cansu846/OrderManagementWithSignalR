using DataAccess.Abstract;
using Entities.Concrete.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfMenuTableDal : EfEntityRepositoryBase<MenuTable>, IMenuTableDal
	{
		public EfMenuTableDal(SignalRDbContext context) : base(context)
		{
		}

		public int MenuTableCount()
		{
			using var context = new SignalRDbContext();
			var value = context.MenuTables.Count();
			return value;
		}

	}
}
