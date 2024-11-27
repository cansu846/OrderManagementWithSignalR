using DataAccess.Abstract;
using Dto.BasketDto;
using Entities.Concrete.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBasketService:IGenericService<Basket>
    {
        List<Basket> GetBasketByMenuTableId(int id);
        List<ResultBasketListWithProductsDto> GetBasketListByMenuTableIdWithProductName(int id);
    }
}
