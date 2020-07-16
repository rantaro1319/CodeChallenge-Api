using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishCourse1._1.Modelos
{
    public class Tablas
    {

    }

    //Modelos de Entity Framework 
    public class estudiantes
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="varchar(50)")]
        public string nombre { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string apellido { get; set; }
        public int edad { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string correo { get; set; }
        [Column(TypeName = "varchar(25)")]
        public string telefono { get; set; }
        public int idsecciones { get; set; }

    }

    public class profesores
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string nombre { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string apellido { get; set; }
        public int Edad { get; set; }
        public List<secciones> secciones { get; set; }
    }

    public class curso
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string nombre { get; set; }
        public List<secciones> secciones { get; set; }
    }

    public class secciones
    {
        public int Id { get; set; }
        public DateTime hora { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Aula { get; set; }
        public int idprofesores { get; set; }
        public int idcurso { get; set; }
        public List<estudiantes> estudiantes { get; set; }

    }
}
