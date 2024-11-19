using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Pages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTestimonialDal : EfEntityRepositoryBase<Testimonial>, ITestimonialDal
    {
        public EfTestimonialDal(SignalRDbContext dbContext):base(dbContext) { } 
      
    }
}
