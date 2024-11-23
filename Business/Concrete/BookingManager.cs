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
    public class BookingManager : IBookingService
    {
        IBookingDal _bookingDal;
        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }
        public void Add(Booking entity)
        {
            _bookingDal.Add(entity);
        }

        public void Delete(Booking entity)
        {
            _bookingDal.Delete(entity);
        }

        public Booking Get(int id)
        {
            return _bookingDal.Get(b=>b.BookingID==id);
        }

        public List<Booking> GetAll()
        {
            return _bookingDal.GetAll();
        }
        public void Update(Booking entity)
        {
            _bookingDal.Update(entity);
        }

     
    }
}
