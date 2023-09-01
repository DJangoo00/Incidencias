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
        public Gender Gender { get; set;}
        public int IdCityFk { get; set;}
        public City City { get; set;}
        public int IdPersonTypeFk { get; set;}
        public PersonType PersonType { get; set;}

        public ICollection<Subject> Subjects { get; set;}
        public ICollection<TrainerClassroom> TrainerClassrooms { get; set;}

    }
}