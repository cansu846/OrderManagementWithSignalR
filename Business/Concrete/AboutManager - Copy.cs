using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;
        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }
        public void Add(Slider entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Slider entity)
        {
            throw new NotImplementedException();
        }

        public Slider Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Slider> GetAll()
        {
            return _sliderDal.GetAll();
        }

        public void Update(Slider entity)
        {
            throw new NotImplementedException();
        }
    }
}
