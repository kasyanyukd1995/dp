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
        ServiceRepository servicesRepository = new ServiceRepository ();
        public IQueryable<Instrument> Instruments
        {
            get
            {
                return context.Instruments;
            }
        }
        public IQueryable<string> GetNameInstruments(string nameService, int Index)
        {
            return context.Instruments.Where(x => x.Service.Id == Index ).Select(x=>x.NameInstrument);
        }

        public string GetYearissue(string nameInstrument)
        {

            return Instruments.FirstOrDefault(x => x.NameInstrument == nameInstrument).YearIssue;
        }
        public string GetDescript(string nameInstrument)
        {
            return Instruments.FirstOrDefault(x => x.NameInstrument == nameInstrument).Description;
        }
        public string GetCharacteristic(string nameInstrument)
        {
            return Instruments.FirstOrDefault(x => x.NameInstrument == nameInstrument).Characteristic;
        }

        public IEnumerable<string> GetNamesServices() //список служб
        {
            return context.Services.Select(x => x.NameService);
        }
        public ICollection<Instrument> GetInstrumentsService(string service)
        {
            return context.Services.Where(x => x.NameService == service).First().Instruments;
        }
        public int GetInstrumentId (string nameInstrument)
        {
            return context.Instruments.FirstOrDefault(x => x.NameInstrument == nameInstrument).Id;
        }
        public void SaveInstrument(Instrument instrument)
        {
            if (instrument.Id == 0)
            {
                context.Instruments.Add(instrument);
            }
            else
            {
                var dbEntry = context.Instruments.Find(instrument.Id);
                if (dbEntry != null)
                {
                    dbEntry.Characteristic = instrument.Characteristic;
                    dbEntry.Description = instrument.Description;
                    dbEntry.NameInstrument = instrument.NameInstrument;
                    dbEntry.Service = instrument.Service;
                    dbEntry.YearIssue = instrument.YearIssue;
                }
            }
            context.SaveChanges();
        }

        public Instrument DeleteInstrument(int id)
        {
            var dbEntry = context.Instruments.Find(id);
            if (dbEntry != null)
            {
                context.Instruments.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
