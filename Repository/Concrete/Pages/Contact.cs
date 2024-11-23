using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Pages
{
    public class Contact:User
    {
        public int ContactId { get; set; }
        public string Location { get; set; }
        public string FeatureDescription { get; set; }

    }
}
