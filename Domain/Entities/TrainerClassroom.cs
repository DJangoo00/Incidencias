using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TrainerClassroom
    {
        public int IdPerson { get; set;}
        public Person Person { get; set;}
        public int IdClassroom { get; set;}
        public Classroom Classroom { get; set;}
    }
}