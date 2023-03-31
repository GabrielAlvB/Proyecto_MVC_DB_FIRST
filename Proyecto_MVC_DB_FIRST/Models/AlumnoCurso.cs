using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Proyecto_MVC_DB_FIRST.Models
{
    public partial class AlumnoCurso
    {
        [Key]
        public int Id { get; set; }
        public int? IdAlumno { get; set; }
        public int? IdCurso { get; set; }

        public virtual Alumnos IdAlumnoNavigation { get; set; }
        public virtual Cursos IdCursoNavigation { get; set; }


        /*
        public class AlumnosDBContext : DbContext
        {
            public DbSet<Alumnos> Users { get; set; }
        }
        */

   }



}
