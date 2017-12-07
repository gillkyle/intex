using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace NL.Models
{
    [Table("AssayProtocol")]
    public class AssayProtocol
    {
        [Key, ForeignKey("Assay")]
        public int AssayID { get; set; }
        public virtual Assay Assay { get; set; }
        [Key, ForeignKey("Protocol")]
        public int ProtocolID { get; set; }
        public virtual Protocol Protocol { get; set; }
    }
}