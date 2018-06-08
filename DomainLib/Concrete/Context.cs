using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DomainLib.Entity;


namespace DomainLib.Concrete
{
    public class Context : DbContext
    {
        public Context() : base("DefaultConnectionT")
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AssSrvicemn> AssSrvicmns { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Srvicemn> Srvicemns { get; set; }
        
      
    
       
    }

}
