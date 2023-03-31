using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Proyecto_MVC_DB_FIRST.Models
{
    public partial class Cursos
    {
        public Cursos()
        {
            AlumnoCurso = new HashSet<AlumnoCurso>();
        }

        public int IdCurso { get; set; }
        public string Nombre { get; set; }
        public bool Disponible { get; set; }

        public virtual ICollection<AlumnoCurso> AlumnoCurso { get; set; }
    }
}
