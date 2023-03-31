using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Proyecto_MVC_DB_FIRST.Data
{
    public class AlumnosContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public AlumnosContext() : base("name=AlumnosContext")
        {
        }

        public System.Data.Entity.DbSet<Proyecto_MVC_DB_FIRST.Models.Alumnos> Alumnos { get; set; }

        public System.Data.Entity.DbSet<Proyecto_MVC_DB_FIRST.Models.AlumnoCurso> AlumnoCursoes { get; set; }

        public System.Data.Entity.DbSet<Proyecto_MVC_DB_FIRST.Models.Cursos> Cursos { get; set; }
    }
}
