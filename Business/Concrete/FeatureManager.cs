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
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDal _featureDal;
        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }
        public void Add(EntityFeature entity)
        {
            _featureDal.Add(entity);
        }

        public void Delete(EntityFeature entity)
        {
            _featureDal.Delete(entity);
        }

        public EntityFeature Get(int id)
        {
            return _featureDal.Get(f=>f.EntityFeatureId==id);
        }

        public List<EntityFeature> GetAll()
        {
            return _featureDal.GetAll();
        }

        public void Update(EntityFeature entity)
        {
            _featureDal.Update(entity);
        }
    }
}
