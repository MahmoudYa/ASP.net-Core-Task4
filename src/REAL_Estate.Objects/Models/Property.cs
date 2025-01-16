using REAL_Estate.Components.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REAL_Estate.Objects.Models
{
    public class Property : AModel
    {
        public int propertyId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        //cascading dropdown
        public string Country { get; set; }
        public string City { get; set; }
        public string Region { get; set; }


        // Navigation property for related files
        public virtual ICollection<Filee> Files { get; set; }
    }
}
