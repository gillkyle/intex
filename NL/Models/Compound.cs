using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NL.Models
{
    [Table("Compound")]
    public class Compound
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LTNum { get; set; }
        [ForeignKey("WorkOrder")]
        public int WorkOrderID { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }
        public string Name { get; set; }
        public Decimal ActualAmount_mg { get; set; }
        public Decimal StatedAmount_mg { get; set; }
        public Decimal MolecularMass { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateArrived { get; set; }
        [ForeignKey("User")]
        public int ReceivedBy { get; set; }
        public virtual User User { get; set; }
        public string Appearance { get; set; }


    }
}