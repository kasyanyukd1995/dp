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
    }
}
