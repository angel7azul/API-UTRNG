using API.UTRG.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.UTRG.Services
{
    public interface IAlumnoInfoRepository
    {
        //Repositorio que implementara AlumnoInfoRepository
        IEnumerable<Alumno> GetAlumnos();
        Alumno GetAlumno(int alumnoid, bool includeRedSocial);
        bool AlumnoExist(int alumnoid);
        IEnumerable<RedSocials> GetRedesSocialesForAlumno(int alumnoid);
        RedSocials GetRedSocialForAlumno(int alumnoid, int redsocial);

        //Crear Puntos de Redes sociales

        void AddRedSocialForAlumno(int alumnoId, RedSocials redSocials);

        bool Save();

        void Delete(RedSocials redSocials);
    }
}
