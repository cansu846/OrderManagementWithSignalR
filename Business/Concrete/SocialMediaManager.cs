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
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _socialMediaDal;
        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }
        public void Add(SocialMedia entity)
        {
            _socialMediaDal.Add(entity);
        }
        public void Delete(SocialMedia entity)
        {
            _socialMediaDal.Delete(entity);
        }

        public SocialMedia Get(int id)
        {
            return _socialMediaDal.Get(s=>s.SocialMediaId==id);
        }

        public List<SocialMedia> GetAll()
        {
            return _socialMediaDal.GetAll();
        }

        public void Update(SocialMedia entity)
        {
            _socialMediaDal.Update(entity);
        }
    }
}
