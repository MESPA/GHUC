using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace GHMNUNIDADDECAPACITACION.Models
{
    public class GHUContext : DbContext
    {

        public virtual DbSet<UnidaddeCaptacion> UnidaddeCaptacion { get; set; }
        public virtual DbSet<Filiales> Filiales { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }

        public GHUContext()
           //Reference the name of your connection string ( WebAppCon )  
           : base("DefaultConnection") { }
    }
}
   
