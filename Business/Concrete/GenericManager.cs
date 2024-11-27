using DataAccess.Abstract;
using Entities.Concrete.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GenericManager<TEntity>
        where TEntity : class, new()
    {
        private readonly IGenericDal<TEntity> _genericDal;
        public GenericManager(IGenericDal<TEntity> genericDal)
        {
            _genericDal = genericDal;
        }
        public void Add(TEntity entity)
        {
            _genericDal.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _genericDal.Delete(entity);
        }

        public TEntity Get(int id)
        {

            return _genericDal.Get();
        }

        public List<TEntity> GetAll()
        {
            return _genericDal.GetAll();
        }

        public void Update(TEntity entity)
        {
            _genericDal.Update(entity);
        }
    }
}
