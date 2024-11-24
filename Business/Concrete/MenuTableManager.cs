using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class MenuTableManager : IMenuTableService
	{
		private readonly IMenuTableDal _menuTableDal;

        public MenuTableManager(IMenuTableDal menuTableDal)
        {
            _menuTableDal = menuTableDal;	
        }
        public void Add(MenuTable entity)
		{
			throw new NotImplementedException();
		}

		public void Delete(MenuTable entity)
		{
			throw new NotImplementedException();
		}

		public MenuTable Get(int id)
		{
			throw new NotImplementedException();
		}

		public List<MenuTable> GetAll()
		{
			throw new NotImplementedException();
		}

		public int MenuTableCount()
		{
			return _menuTableDal.MenuTableCount();
		}

		public void Update(MenuTable entity)
		{
			throw new NotImplementedException();
		}
	}
}
