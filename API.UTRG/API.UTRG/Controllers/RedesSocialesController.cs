using API.UTRG.Models;
using API.UTRG.Services;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.UTRG.Controllers
{
    [Route("api")]
    public class RedesSocialesController : Controller
    {
        private IAlumnoInfoRepository _alumnoInfoRepository;
      
        public RedesSocialesController(IAlumnoInfoRepository alumnoInfoRepository)
        {
            _alumnoInfoRepository = alumnoInfoRepository;
        }

        //Obtener Redes sociales de un alumno
        [HttpGet("alumnos/{id}/redsocial")]
        public IActionResult GetRedSocial(int id)
        {
            if (!_alumnoInfoRepository.AlumnoExist(id))
            {
                return NotFound();
            }

            var redSocialForAlumno = _alumnoInfoRepository.GetRedesSocialesForAlumno(id);
            var redSocialForAlumnoResults = Mapper.Map<IEnumerable<RedSocialDto>>(redSocialForAlumno);
            return Ok(redSocialForAlumnoResults);
        }

        //Crear Red Social
        [HttpPost("alumnos/{alumnoid}/redsocial")]
        public IActionResult CreateRedSocial([FromBody] RedSocialForCreation redSocial, int alumnoid)
        {
            if (redSocial == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_alumnoInfoRepository.AlumnoExist(alumnoid))
            {
                return NotFound();
            }

            var finalRedSocial = Mapper.Map<Entities.RedSocials>(redSocial);

            _alumnoInfoRepository.AddRedSocialForAlumno(alumnoid, finalRedSocial);

            if (!_alumnoInfoRepository.Save())
            {
                return StatusCode(500, "Hola k ace, tiene un error o k");
            }

            var CreatedRedSocialToReturn = Mapper.Map<Models.RedSocialDto>(finalRedSocial);
            return CreatedAtRoute("GetRedSocial", new { alumnoid = alumnoid, id = CreatedRedSocialToReturn.ID }, CreatedRedSocialToReturn);
        }

        //Obtener Red Social por ID
        [HttpGet("{alumnoid}/redsocial/{id}", Name = "GetRedSocial")]
        public IActionResult GetRedSocialById(int alumnoid, int id)
        {
            if (!_alumnoInfoRepository.AlumnoExist(alumnoid))
            {
                return NotFound();
            }

            var redSocial = _alumnoInfoRepository.GetRedSocialForAlumno(alumnoid, id);
            if (redSocial == null)
            {
                return NotFound();
            }

            var redSocialResult = Mapper.Map<RedSocialDto>(redSocial);
            return Ok(redSocialResult);
        }

        //Actualizar Red Social Completo
        [HttpPut("{alumnoid}/redsocial/{id}")]
        public IActionResult Put([FromBody] RedSocialForCreation redSocial, int alumnoid, int id)
        {
            if (redSocial == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_alumnoInfoRepository.AlumnoExist(alumnoid))
            {
                return NotFound();
            }

            var redSocialEntity = _alumnoInfoRepository.GetRedSocialForAlumno(alumnoid, id);

            if (redSocialEntity == null)
            {
                return NotFound();
            }

            Mapper.Map(redSocial, redSocialEntity);

            if (!_alumnoInfoRepository.Save())
            {
                return StatusCode(500, "Hola k ace, tiene un error o k");
            }
            return NoContent();
        }

        //Actualizacion por Campos 
        [HttpPatch("{alumnoid}/redsocial/{id}")]
        public IActionResult PartiallyUpdateRedSocial(int alumnoid, int id, [FromBody] JsonPatchDocument<RedSocialForCreation> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }

            if (!_alumnoInfoRepository.AlumnoExist(alumnoid))
            {
                return NotFound();
            }

            var redSocialEntity = _alumnoInfoRepository.GetRedSocialForAlumno(alumnoid, id);
            if (redSocialEntity == null)
            {
                return NotFound();
            }

            var redSocialToPatch = Mapper.Map<RedSocialForCreation>(redSocialEntity);

            patchDocument.ApplyTo(redSocialToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Mapper.Map(redSocialToPatch, redSocialEntity);
            if (!_alumnoInfoRepository.Save())
            {
                return StatusCode(500, "Error del servidor");
            }

            return NoContent();
        }

        //Eliminar un Red Social
        [HttpDelete("{alumnoid}/redsocial/{id}")]
        public IActionResult DeletePointOfInterest(int alumnoid, int id)
        {
            if (!_alumnoInfoRepository.AlumnoExist(alumnoid))
            {
                return NotFound();
            }

            var redSocialEntity = _alumnoInfoRepository.GetRedSocialForAlumno(alumnoid, id);
            if (redSocialEntity == null)
            {
                return NotFound();
            }

            _alumnoInfoRepository.Delete(redSocialEntity);
            if (!_alumnoInfoRepository.Save())
            {
                return StatusCode(500, "Error de servidor");
            }
            return NoContent();
        }
    }
}