using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLib.Entity;

namespace DomainLib.Concrete
{
    public class AssSrvicemnRepository
    {
        private Context context = new Context();
        public IQueryable<AssSrvicemn> AssServicemens
        {
            get
            {
                return context.AssSrvicmns;
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

        public void SaveAssServiceman(AssSrvicemn assServiceman)
        {
            if (assServiceman.Id == 0)
            {
                context.AssSrvicmns.Add(assServiceman);
                
            }
            else
            {
                var dbEntry = context.AssSrvicmns.Find(assServiceman.Id);
                if (dbEntry != null)
                {
                    dbEntry.Date_Ass = assServiceman.Date_Ass;
                    dbEntry.Date_UnAss = assServiceman.Date_UnAss;
                    dbEntry.Instrument = assServiceman.Instrument;
                    dbEntry.Srvicemn = assServiceman.Srvicemn;

                }
            }
            context.SaveChanges();
        }

        public AssSrvicemn DeleteAssServiceman(int id)
        {
            var dbEntry = context.AssSrvicmns.Find(id);
            if (dbEntry != null)
            {
                context.AssSrvicmns.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
