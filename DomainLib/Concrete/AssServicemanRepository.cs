using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLib.Entity;

namespace DomainLib.Concrete
{
    public class AssServicemanRepository
    {
        private Context context = new Context();
        public IQueryable<AssServiceman> AssServicemens
        {
            get
            {
                return context.AssServicemans;
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

        public void SaveAssServiceman(AssServiceman assServiceman)
        {
            if (assServiceman.Id == 0)
            {
                context.AssServicemans.Add(assServiceman);
            }
            else
            {
                var dbEntry = context.AssServicemans.Find(assServiceman.Id);
                if (dbEntry != null)
                {
                    dbEntry.Date_Ass = assServiceman.Date_Ass;
                    dbEntry.Date_UnAss = assServiceman.Date_UnAss;
                    dbEntry.Instrument = assServiceman.Instrument;
                    dbEntry.Serviceman = assServiceman.Serviceman;

                }
            }
            context.SaveChanges();
        }

        public AssServiceman DeleteAssServiceman(int id)
        {
            var dbEntry = context.AssServicemans.Find(id);
            if (dbEntry != null)
            {
                context.AssServicemans.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
