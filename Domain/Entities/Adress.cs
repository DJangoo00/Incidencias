using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Adress : BaseEntity
    {
        public string WayType { get; set; }
        public int Number { get; set; }
        public string Letter { get; set; }
        public string CardinalSuf { get; set; }
        public int NumWaysec { get; set; }
        public string LettWaysec { get; set; }
        public string SuffCards { get; set; }
    }
}