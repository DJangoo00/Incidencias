using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Subject : BaseEntity
    {
        public int IdPersonFk { get; set;}
        public int IdClassroomFk { get; set;}
    }
}