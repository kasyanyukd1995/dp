using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLib.Entity
{
    public class Instrument
    {
        public int Id { get; set; }
        public Service Service { get; set; }
        public string NameInstrument { get; set; }
        public string Description { get; set; }//описание
        public DateTime AccountingDate { get; set; }//дата постановки на учет
        public string YearIssue { get; set; } //год выпуска
        public DateTime Date_ofderegistration { get; set; } //дата снятия с учета
        public string DecisionOprtn { get; set; } //решение на эксплуатацию
        public string SerialNumber { get; set; } //Серийный номер
        public string InventoryNumber { get; set; } //Инвентарный номер
        public string Condition { get; set; } //состояние
        public string AddirionalInf { get; set; } //дополнительная информация
        public string Characteristic { get; set; }
        public Serviceman Serviceman { get; set; }

    }
}
