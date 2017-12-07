using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NL.Models
{
    [Table("TestType")]
    public class TestType
    {
        [Key]
        public int TestTypeID { get; set; }
        public String Description { get; set; }
    }
}