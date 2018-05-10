using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLib.Entity
{
    public class Account
    {
        public int Id { get; set; }
        public Service Service { get; set; } //служба
        public Instrument Instrument { get; set; } //тип средства

        public AssServiceman AssServiceman { get; set; } //закрепленный военнослужащий

    }
}
