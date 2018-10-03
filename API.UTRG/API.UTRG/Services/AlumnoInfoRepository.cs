using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.UTRG.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.UTRG.Services
{
    public class AlumnoInfoRepository : IAlumnoInfoRepository
    {
        private AlumnoInfoDbContext _context;

        public AlumnoInfoRepository(AlumnoInfoDbContext context)
        {
            _context = context;
        }

        public void AddRedSocialForAlumno(int alumnoId, RedSocials redSocials)
        {
            var alumno = GetAlumno(alumnoId, false);
            alumno.Redes.Add(redSocials);
        }

        public bool AlumnoExist(int alumnoid)
        {
            return _context.Alumnos.Any(c => c.ID == alumnoid);
        }

        public void Delete(RedSocials redSocials)
        {
            _context.RedSocials.Remove(redSocials);
        }

        public IEnumerable<Alumno> GetAlumnos()
        {
            return _context.Alumnos.OrderBy(c => c.Nombre).ToList();
        }

        public Alumno GetAlumno(int alumnoid, bool includeRedSocial)
        {
            if (includeRedSocial)
            {
                //Include EntityFCore Regresa el objecto con las entidades relacionadas con el 
                return _context.Alumnos.Include(a => a.Redes).Where(a => a.ID == alumnoid).FirstOrDefault();
            }
            return _context.Alumnos.Find(alumnoid);
        }

        public RedSocials GetRedSocialForAlumno(int alumnoid, int redsocial)
        {
            return _context.RedSocials
                 .Where(r => r.AlumnoId == alumnoid && r.ID == redsocial).FirstOrDefault();
        }

        public IEnumerable<RedSocials> GetRedesSocialesForAlumno(int alumnoid)
        {
            return _context.RedSocials.Where(r => r.AlumnoId == alumnoid).ToList();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
