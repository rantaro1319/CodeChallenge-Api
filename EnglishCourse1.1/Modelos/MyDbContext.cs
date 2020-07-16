using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishCourse1._1.Modelos
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> opciones) : base(opciones)
        {

        }


        public DbSet<estudiantes> estudiantes { get; set; }
        public DbSet<profesores> profesores { get; set; }
        public DbSet<curso> curso { get; set; }
        public DbSet<secciones> secciones { get; set; }


    }
}
