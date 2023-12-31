using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Classroom : BaseEntity
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<TrainerClassroom> TrainerClassrooms { get; set; }

        public ICollection<Person> Persons { get; set; }
    }
}