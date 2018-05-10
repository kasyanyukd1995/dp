using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLib.Entity
{
    public class AssServiceman
    {
        public int Id { get; set; }
        public Serviceman Serviceman { get; set; }
        public Instrument Instrument { get; set; }
        public DateTime Date_Ass { get; set; } //дата закрепления
        public DateTime Date_UnAss { get; set; } //дата открепления

    }
}
