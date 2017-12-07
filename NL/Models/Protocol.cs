using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NL.Models
{
    [Table("Protocol")]
    public class Protocol
    {
        [Key]
        public int ProtocolID { get; set; }
        public String ProtocolDesc { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PreviousID { get; set; }
    }
}