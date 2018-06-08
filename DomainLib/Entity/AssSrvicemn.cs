using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLib.Entity
{
    public class AssSrvicemn
    {
        public int Id { get; set; }
        public Srvicemn Srvicemn { get; set; }
        public Instrument Instrument { get; set; }
        public DateTime Date_Ass { get; set; } //дата закрепления
        public DateTime Date_UnAss { get; set; } //дата открепления

    }
}
