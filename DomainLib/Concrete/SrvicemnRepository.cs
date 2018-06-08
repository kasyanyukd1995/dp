using DomainLib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLib.Concrete
{
    public class SrvicemnRepository
    {
        private Context context = new Context();
        public IQueryable<Srvicemn> Servicemans
        {
            get
            {
                return context.Srvicemns;
            }
        }
        public int GetServicemen(string nameServicemen)
        {
            return context.Srvicemns.FirstOrDefault(x => x.SN == nameServicemen).Id;
        }
        public IEnumerable<string> GetNamesServicemen() //список в/сл
        {
            return context.Srvicemns.Select(x => x.SN);
        }
        public ICollection<Instrument> GetInstrumentsService(string service)
        {
            return context.Services.Where(x => x.NameService == service).First().Instruments;
        }

        public void SavServiceman(Srvicemn serviceman)
        {
            if (serviceman.Id == 0)
            {
                context.Srvicemns.Add(serviceman);
            }
            else
            {
                var dbEntry = context.Srvicemns.Find(serviceman.Id);
                if (dbEntry != null)
                {
                    
                    dbEntry.SN = serviceman.SN;
                   
                }
            }
            context.SaveChanges();
        }

        public Srvicemn DeleteServiceman(int id)
        {
            var dbEntry = context.Srvicemns.Find(id);
            if (dbEntry != null)
            {
                context.Srvicemns.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
