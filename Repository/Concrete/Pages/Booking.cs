using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Pages
{
    public class Booking:User
    {
        public int BookingID { get; set; }
        public DateTime Date { get; set; }
    }
}
