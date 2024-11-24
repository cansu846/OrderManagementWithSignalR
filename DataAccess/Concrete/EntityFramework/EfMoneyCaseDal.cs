using DataAccess.Abstract;
using Entities.Concrete.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMoneyCaseDal : EfEntityRepositoryBase<MoneyCase>, IMoneyCaseDal
    {
        public EfMoneyCaseDal(SignalRDbContext context) : base(context)
        {
        }

        public decimal TotalMoneyCaseAmount()
        {
            using var context = new SignalRDbContext();
            var total = context.MoneyCases.Select(mc => mc.TotalAmount).FirstOrDefault();
            return total;
        }
    }
}
