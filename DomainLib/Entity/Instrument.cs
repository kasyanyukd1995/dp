using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLib.Entity
{
    public class Instrument
    {
        public int Id { get; set; }
        public Service Service { get; set; }
        public string NameInstrument { get; set; }
        public string Description { get; set; }//описание
        public string YearIssue { get; set; } //год выпуска
        public string Characteristic { get; set; }
      
    }
}
