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
			_menuTableDal.Add(entity);	
		}

		public void Delete(MenuTable entity)
		{
			_menuTableDal.Delete(entity);
		}

		public MenuTable Get(int id)
		{
			return _menuTableDal.Get(mt=>mt.MenuTableID==id);
		}

		public List<MenuTable> GetAll()
		{
			return _menuTableDal.GetAll();
		}

		public int MenuTableCount()
		{
			return _menuTableDal.MenuTableCount();
		}
		public void Update(MenuTable entity)
		{
			_menuTableDal.Update(entity);
		}
	}
}
