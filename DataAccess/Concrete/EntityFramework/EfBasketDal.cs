using DataAccess.Abstract;
using Dto.BasketDto;
using Entities.Concrete;
using Entities.Concrete.Pages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBasketDal : EfEntityRepositoryBase<Basket>, IBasketDal
    {
        public EfBasketDal(SignalRDbContext context) : base(context)
        {
        }

        public List<Basket> GetBasketByMenuTableId(int id)
        {
            using var context = new SignalRDbContext();
            //Include metodu, Entity Framework'te bir sorgu sırasında ilişkili tabloları (navigation properties) sorguya dahil etmek için kullanılır. 
            //    Yani, ilişkili verilerin (örneğin, Basket ile ilişkili Product verileri) önceden veritabanından alınmasını sağlar. 
            //    Bu yöntem, eager loading (ön yükleme) olarak bilinir.
            //Product Verisi: Her bir Basket nesnesi için ilişkili olan Product nesnesinin tüm verileri döner.
            //Eğer Include kullanılmazsa, Basket.Product null olur.Çünkü varsayılan olarak lazy loading aktif değilse ilişkili veriler otomatik yüklenmez.
            var values = context.Baskets.Where(b=>b.MenuTableID==id).Include(p=>p.Product).ToList();
            return values;
        }

        public List<ResultBasketListWithProductsDto> GetBasketListByMenuTableIdWithProductName(int id)
        {
            using var context = new SignalRDbContext();
            var values = context.Baskets.Where(b => b.MenuTableID == id).Include(p => p.Product)
                .Select(b=>new ResultBasketListWithProductsDto()
                {
                    BasketID=b.BasketID,
                    Count=b.Count,
                    MenuTableID=b.MenuTableID,
                    Price=b.Price,
                    TotalPrice=b.TotalPrice,
                    ProductID=b.ProductID,
                    ProductName=b.Product.ProductName
                }).ToList();

            return values;
        }
    }
}
