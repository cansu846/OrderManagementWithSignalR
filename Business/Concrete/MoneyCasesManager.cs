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
	public class MoneyCaseManager : IMoneyCaseService
	{
		private readonly IMoneyCaseDal _moneyCaseDal;

        public MoneyCaseManager(IMoneyCaseDal moneyCaseDal)
        {
            _moneyCaseDal = moneyCaseDal;
        }
        public void Add(MoneyCase entity)
		{
			throw new NotImplementedException();
		}

		public void Delete(MoneyCase entity)
		{
			throw new NotImplementedException();
		}

		public MoneyCase Get(int id)
		{
			throw new NotImplementedException();
		}

		public List<MoneyCase> GetAll()
		{
			throw new NotImplementedException();
		}

		public decimal TotalMoneyCaseAmount()
		{
			return _moneyCaseDal.TotalMoneyCaseAmount();
		}

		public void Update(MoneyCase entity)
		{
			throw new NotImplementedException();
		}
	}
}
