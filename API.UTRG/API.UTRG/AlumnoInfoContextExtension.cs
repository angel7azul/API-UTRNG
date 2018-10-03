using API.UTRG.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.UTRG
{
    public static class AlumnoInfoContextExtension
    {
        public static void EnsureSeedDatForContext(this AlumnoInfoDbContext context)
        {
            if (context.Alumnos.Any())
            {
                return;
            }
            var alumnos = new List<Alumno>()
            {
                new Alumno()
                {
                    Nombre="Luis Angel",
                    Email = "luis@gmail.com",
                    Telefono = "7331872838",
                    FechaNacimiento = new DateTime(1997,01,17),
                    Redes= new List<RedSocials>
                    {
                        new RedSocials()
                        {
                            Nombre="Facebook",
                            RedSocial="www.facebook.com/Luisito"
                        },
                        new RedSocials()
                        {
                            Nombre="Twitter",
                            RedSocial="www.twitter.com/Luisito"
                        }
                    }
                },
                new Alumno()
                {
                    Nombre="Pedro",
                    Email = "pedro@gmail.com",
                    Telefono = "7331171852",
                    FechaNacimiento = new DateTime(1997,03,09),
                    Redes= new List<RedSocials>
                    {
                        new RedSocials()
                        {
                            Nombre="Facebook",
                            RedSocial="www.facebook.com/Pedro"
                        }
                    }
                }
            };
            context.Alumnos.AddRange(alumnos);
            context.SaveChanges();
        }
    }
}