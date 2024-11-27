using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IGenericDal<T> where T : class, new()
    {   //Expression<Func<T, bool>> ifadesi bir T türünde nesne alıp bool döndüren
        //bir lambda ifadesini veya fonksiyonu kabul eder.
        //Filtre verilirse, Data filtreye göre getirilir.
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
