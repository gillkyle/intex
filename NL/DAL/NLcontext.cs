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

        public DbSet<Assay> Assay { get; set; }
        //public System.Data.Entity.DbSet<NL.Models.User> Users { get; set; }
    }
}