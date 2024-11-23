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
    public class TestimonialManager : ITestimonialService
    {
        private ITestimonialDal _testimonialDal;
        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }
        public void Add(Testimonial entity)
        {
            _testimonialDal.Add(entity);
        }

        public void Delete(Testimonial entity)
        {
            _testimonialDal.Delete(entity);
        }

        public Testimonial Get(int id)
        {
            return _testimonialDal.Get(t=>t.TestimonialID == id);   
        }

        public List<Testimonial> GetAll()
        {
            return _testimonialDal.GetAll();
        }

        public void Update(Testimonial entity)
        {
            _testimonialDal.Update(entity); 
        }
    }
}
