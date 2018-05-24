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

        public void SaveService(Service service)
        {
            if(service.Id==0)
            {
                context.Services.Add(service);
            }
            else
            {
               var dbEntry = context.Services.Find(service.Id);
                if(dbEntry!=null)
                {
                    dbEntry.Instruments = service.Instruments;
                    dbEntry.NameService = service.NameService;
                }
            }
            context.SaveChanges();
        }

        public Service DeleteService(int id)
        {
            var dbEntry = context.Services.Find(id);
            if(dbEntry!=null)
            {
                context.Services.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        
    }
}

