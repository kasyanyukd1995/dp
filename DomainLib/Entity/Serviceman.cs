using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLib.Entity
{
    public class Serviceman
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public ICollection<Instrument> Instruments { get; set; }

    }
}
