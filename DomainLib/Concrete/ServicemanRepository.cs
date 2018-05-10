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
    }
}
