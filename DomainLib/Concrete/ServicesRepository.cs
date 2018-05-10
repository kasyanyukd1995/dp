using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLib.Entity;


namespace DomainLib.Concrete
{
    public class ServicesRepository
    {
        private Context context = new Context();
        public IQueryable<Service> Services
        {
            get
            {
                return context.Services;
            }
        }
        public IEnumerable<string> GetNamesServices() //список служб
        {
            return context.Services.Select(x => x.NameService);
        }
        public ICollection<Instrument> GetInstrumentsService(string service)
        {
            return context.Services.Where(x=>x.NameService==service).First().Instruments;
        }

    }
}

