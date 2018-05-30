using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLib.Entity;

namespace DomainLib.Concrete
{
    public class AccountsRepository
    {
        private Context context = new Context();
        public IQueryable<Account> Accounts
        {
            get
            {
                return context.Accounts;
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

        public void SaveAccount(Account account)
        {
            if (account.Id == 0)
            {
                context.Accounts.Add(account);
            }
            else
            {
                var dbEntry = context.Accounts.Find(account.Id);
                if (dbEntry != null)
                {
                    dbEntry.AccountingDate = account.AccountingDate;
                    dbEntry.AddirionalInf = account.AddirionalInf;
                    dbEntry.Condition = account.Condition;
                    dbEntry.Date_ofderegistration = account.Date_ofderegistration;
                    dbEntry.DecisionOprtn = account.DecisionOprtn;
                    dbEntry.Instrument = account.Instrument;
                    dbEntry.InventoryNumber = account.InventoryNumber;
                    dbEntry.SerialNumber = account.SerialNumber;
                    dbEntry.Service = account.Service;
                    dbEntry.Serviceman = account.Serviceman;

                }
            }
            context.SaveChanges();
        }

        public Account DeleteAccount(int id)
        {
            var dbEntry = context.Accounts.Find(id);
            if (dbEntry != null)
            {
                context.Accounts.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
