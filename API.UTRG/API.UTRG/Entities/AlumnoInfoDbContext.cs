using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.UTRG.Entities
{
    public class AlumnoInfoDbContext : DbContext
    {

        public AlumnoInfoDbContext(DbContextOptions<AlumnoInfoDbContext> options) : base(options)
        {
            //Llamar EnsureCreated() para forzar a crear la BD y crear DummyController
            Database.EnsureCreated();
        }

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<RedSocials> RedSocials { get; set; }
    }
}
