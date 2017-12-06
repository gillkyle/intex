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

        //public DbSet<Mission> Missions { get; set; }
        //public DbSet<Question> Questions { get; set; }
        //public DbSet<Response> Responses { get; set; }
        //public System.Data.Entity.DbSet<NL.Models.User> Users { get; set; }
    }
}