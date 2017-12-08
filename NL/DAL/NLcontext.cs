using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NL.Models;
using System.Data.Entity;

namespace NL.DAL
{
    public class NLcontext : DbContext
    {
        public NLcontext() : base("NLcontext")
        {

        }

        public System.Data.Entity.DbSet<NL.Models.Assay> Assays { get; set; }

        public System.Data.Entity.DbSet<NL.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<NL.Models.Role> Roles { get; set; }

        public System.Data.Entity.DbSet<NL.Models.ZIPCode> ZIPCodes { get; set; }

        public System.Data.Entity.DbSet<NL.Models.AssayTest> AssayTests { get; set; }

        public System.Data.Entity.DbSet<NL.Models.Test> Tests { get; set; }

        public System.Data.Entity.DbSet<NL.Models.WorkOrder> WorkOrders { get; set; }

        public System.Data.Entity.DbSet<NL.Models.BillDetail> BillDetails { get; set; }

        public System.Data.Entity.DbSet<NL.Models.Priority> Priorities { get; set; }

        public System.Data.Entity.DbSet<NL.Models.Status> Status { get; set; }

        public System.Data.Entity.DbSet<NL.Models.Question> Questions { get; set; }

        public System.Data.Entity.DbSet<NL.Models.Response> Responses { get; set; }

        public System.Data.Entity.DbSet<NL.Models.Compound> Compounds { get; set; }

        public System.Data.Entity.DbSet<NL.Models.AssayReferences> AssayReferences { get; set; }

        public System.Data.Entity.DbSet<NL.Models.Sample> Samples { get; set; }

        public System.Data.Entity.DbSet<NL.Models.SampleAssay> SampleAssays { get; set; }
    }
}