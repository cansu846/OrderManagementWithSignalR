﻿using Entities.Concrete;
using Entities.Concrete.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IGenericDal<Category>
    {
        int CategoryCount();
        int ActiveCategoryCount();
		int PassiveCategoryCount();
	}
}
