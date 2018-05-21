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
        public DateTime AccountingDate { get; set; }//дата постановки на учет
        public DateTime Date_ofderegistration { get; set; } //дата снятия с учета
        public string DecisionOprtn { get; set; } //решение на эксплуатацию
        public string SerialNumber { get; set; } //Серийный номер
        public string InventoryNumber { get; set; } //Инвентарный номер
        public string Condition { get; set; } //состояние
        public string AddirionalInf { get; set; } //дополнительная информация
        public Serviceman Serviceman { get; set; }

   

    }
}
