using API.UTRG.Models;
using API.UTRG.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.UTRG.Controllers
{
    [Route("api/alumnos")]
    public class AlumnoController:Controller
    {
        //Inyectar el repositorio 
        private IAlumnoInfoRepository _alumnoInfoRepository;
        public AlumnoController(IAlumnoInfoRepository alumnoInfoRepository)
        {
            _alumnoInfoRepository = alumnoInfoRepository;
        }

        //Obtener todos los alumnos
        [HttpGet()]
        public IActionResult GetAlumnos()
        {
            //return Ok(CiudadDataStore.Current.Ciudades);
            var alumnosEntities = _alumnoInfoRepository.GetAlumnos();
            var results = Mapper.Map<IEnumerable<AlumnoWithoutRedSocialDto>>(alumnosEntities);

            return Ok(results);
        }

        //Alumno por id Con o sin Redes sociales
        [HttpGet("{id}")]
        public IActionResult GetAlumnoById(int id, bool includeRedSocial)
        {
            var consultaEnPostman = "http://localhost:59282/api/alumnos/1?includeRedSocial=false";

            var alumno = _alumnoInfoRepository.GetAlumno(id, includeRedSocial);

            if (alumno == null)
            {
                return NotFound();
            }

            if (includeRedSocial)
            {
                var alumnoResult = Mapper.Map<AlumnoDto>(alumno);
                return Ok(alumnoResult);
            }
            var alumnoWithoutRedSocial = Mapper.Map<AlumnoWithoutRedSocialDto>(alumno);
            return Ok(alumnoWithoutRedSocial);
        }
    }
}
