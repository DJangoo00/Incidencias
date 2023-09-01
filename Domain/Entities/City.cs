using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public int IdDepartamentFk { get; set;}
        public Departament Departament { get; set; }
        public ICollection<Person> Persons { get; set; }
    }
}