using DomainLib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLib.Concrete
{
    public class ServicemanRepository
    {
        private Context context = new Context();
        public IQueryable<Serviceman> Servicemans
        {
            get
            {
                return context.Servicemans;
            }
        }
        public IEnumerable<string> GetNamesServices() //список служб
        {
            return context.Services.Select(x => x.NameService);
        }
        public ICollection<Instrument> GetInstrumentsService(string service)
        {
            return context.Services.Where(x => x.NameService == service).First().Instruments;
        }

        public void SavServiceman(Serviceman serviceman)
        {
            if (serviceman.Id == 0)
            {
                context.Servicemans.Add(serviceman);
            }
            else
            {
                var dbEntry = context.Servicemans.Find(serviceman.Id);
                if (dbEntry != null)
                {
                    dbEntry.Instruments = serviceman.Instruments;
                    dbEntry.Name = serviceman.Name;
                    dbEntry.Status = serviceman.Status;
                    dbEntry.Surname = serviceman.Surname;
                }
            }
            context.SaveChanges();
        }

        public Serviceman DeleteServiceman(int id)
        {
            var dbEntry = context.Servicemans.Find(id);
            if (dbEntry != null)
            {
                context.Servicemans.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
