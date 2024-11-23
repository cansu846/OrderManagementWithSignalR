using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete.Pages;
using Entities.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal )
        {
            _contactDal = contactDal;
        }
        public void Add(Contact entity)
        {
            _contactDal.Add( entity );
        }

        public void Delete(Contact entity)
        {
           _contactDal.Delete( entity );
        }

        public Contact Get(int id)
        {
            return _contactDal.Get(c=>c.ContactID==id);
        }

        public List<Contact> GetAll()
        {
            return _contactDal.GetAll();
        }

        public void Update(Contact entity)
        {
            _contactDal.Update(entity);
        }
    }
}
