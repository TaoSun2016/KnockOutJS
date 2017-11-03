using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KOJS.Models
{
    public class MyTecBitsDBContext : DbContext
    {
        public DbSet<MTB_Article> MTB_Articles { get; set; }
}
}