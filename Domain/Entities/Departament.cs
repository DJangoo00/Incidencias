using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Departament : BaseEntity
    {
        public string Name { get; set; }
        public int IdCountryTypeFk { get; set;}
        public Country Country { get; set;}
        public ICollection<City> Cities { get; set;}
    }
}