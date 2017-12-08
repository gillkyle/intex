using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NL.Models
{
    public class TestResult
    {
        public int AssayID { get; set; }
        public int TestID { get; set; }
        public bool Active { get; set; }
        public bool Complete { get; set; }
        public String QuantResults { get; set; }
        public String QualResults { get; set; }
        public bool Approval { get; set; }
        public String Desc { get; set; }
    }
}