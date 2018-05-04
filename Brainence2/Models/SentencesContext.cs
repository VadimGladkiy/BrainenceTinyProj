using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Brainence2.Models
{
    public class SentencesContext : DbContext 
    {
        public SentencesContext() : base("DefaultConnection")
        {
            
        }
        public DbSet<Entity> Entities { set; get; }
    }
}