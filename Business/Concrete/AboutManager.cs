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
    public class AboutManager : IAboutService
    {
        private IAboutDal _aboutDal;
        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }
        public void Add(About entity)
        {
            _aboutDal.Add(entity);
        }

        public void Delete(About entity)
        {
            _aboutDal.Delete(entity);
        }
        
        public About Get(int id)
        {
            return _aboutDal.Get(a=>a.AboutId==id);
        }

        public List<About> GetAll()
        {
            return _aboutDal.GetAll();
        }

        public void Update(About entity)
        {
            _aboutDal.Update(entity);
        }
    }
}
