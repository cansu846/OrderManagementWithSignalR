﻿using Entities.Concrete.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IMenuTableService:IGenericService<MenuTable>
	{
		int MenuTableCount();
	}
}
