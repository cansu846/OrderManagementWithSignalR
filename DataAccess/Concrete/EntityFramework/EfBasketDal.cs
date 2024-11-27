using DataAccess.Abstract;
using Entities.Concrete.Pages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var values = context.Baskets.Where(b=>b.MenuTableID==id).Include(p=>p.Product);
            return values.ToList();
        }
    }
}
