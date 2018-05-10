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
    }
}
