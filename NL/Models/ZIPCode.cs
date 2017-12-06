using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NL.Models
{
    [Table("ZIPCode")]
    public class ZIPCode
    {
        [Key]
        public string ZIP { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}