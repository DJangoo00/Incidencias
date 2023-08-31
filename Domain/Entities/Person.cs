using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set;}
        public string Adress { get; set;}
        public int IdGenderFk { get; set;}
        public int IdCityFk { get; set;}
        public int IdPersonTypeFk { get; set;}

    }
}