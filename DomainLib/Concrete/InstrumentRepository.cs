using DomainLib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLib.Concrete
{
   public class InstrumentRepository
    {
        private Context context = new Context();
        public IQueryable<Instrument> Instruments
        {
            get
            {
                return context.Instruments;
            }
        }
        public IQueryable<string> GetNameInstruments(string nameService)
        {
            return context.Instruments.Where(x => x.Service.NameService == nameService).Select(x=>x.NameInstrument);
        }

    }
}
