using API.UTRG.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.UTRG.Controllers
{
    [Route("api")]
    public class RedesSocialesDtoController : Controller
    {
        //Obtener todas las redes sociales de un Alumno
        [HttpGet("alumno/{id}/redes")]
        public IActionResult GetAll(int id)
        {
            var alumno = AlumnosDbContext.context.Alumno.FirstOrDefault(alu => alu.ID == id);
            if (alumno == null || alumno.Redes.Count < 1)
            {
                return NotFound();
            }
            return Ok(alumno.Redes);
        }

        //Obtener una red social de un Alumno 
        [HttpGet("alumno/{alumnoid}/redes/{redid}", Name = "RedCreada")]
        public IActionResult GetAlumnoByRedID(int alumnoid, int redid)
        {
            var alumno = AlumnosDbContext.context.Alumno.FirstOrDefault(alu => alu.ID == alumnoid);
            if (alumno == null)
            {
                return NotFound();
            }
            var red = alumno.Redes.FirstOrDefault(r => r.ID == redid);
            if (red == null)
            {
                return NotFound();
            }
            return Ok(red);
        }

        //Agregar una red Social
        [HttpPost("{alumnoid}")]
        public IActionResult AddRedSocial([FromBody] RedSocialForAdd RedSocial, int alumnoid)
        {
            if (RedSocial == null)
            {
                return BadRequest();
            }

            var alumno = AlumnosDbContext.context.Alumno.FirstOrDefault(a => a.ID == alumnoid);
            if (alumno == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (RedSocial.Nombre == RedSocial.RedSocial)
            {
                ModelState.AddModelError("Nombre", "El nomnore no pude ser igual que la Red!");
            }

            TryValidateModel(ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Incrementar el ID
            var newID = alumno.Redes.Last().ID;
            var newRed = new RedesSociales
            {
                ID = ++newID,
                Nombre = RedSocial.Nombre,
                RedSocial = RedSocial.RedSocial
            };

            alumno.Redes.Add(newRed);

            return new CreatedAtRouteResult("RedCreada", new { alumnoid = alumno.ID, redid = newRed.ID }, newRed);
        }

        //Actualizar una red social Completa PUT
        [HttpPut("{alumnoid}/red/{redid}")]
        public IActionResult UpdateComplete([FromBody] RedSocialForUpdate redSocialForUpdate, int alumnoid, int redid)
        {
            if (redSocialForUpdate == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var alumno = AlumnosDbContext.context.Alumno.FirstOrDefault(a => a.ID == alumnoid);
            if (alumno == null)
            {
                return NotFound();
            }

            var redID = alumno.Redes.FirstOrDefault(r => r.ID == redid);
            if (redID == null)
            {
                return NotFound();
            }

            redID.Nombre = redSocialForUpdate.Nombre;
            redID.RedSocial = redSocialForUpdate.RedSocial;

            return NoContent();
        }

        //Actualizar una Red Social Parcialmente PATCH
        [HttpPatch("{alumnoid}/red/{redid}")]
        public IActionResult UpdatePartial([FromBody]JsonPatchDocument<RedSocialForUpdate> document, int alumnoid, int redid)
        {
            if (document == null)
            {
                return BadRequest();
            }

            var alumno = AlumnosDbContext.context.Alumno.FirstOrDefault(a => a.ID == alumnoid);
            if (alumno == null)
            {
                return NotFound();
            }

            var redFromStore = alumno.Redes.FirstOrDefault(r => r.ID == redid);
            if (redFromStore == null)
            {
                return NotFound();
            }

            var redCreationToPatch = new RedSocialForUpdate
            {
                Nombre = redFromStore.Nombre,
                RedSocial = redFromStore.RedSocial
            };

            document.ApplyTo(redCreationToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            redFromStore.Nombre = redCreationToPatch.Nombre;
            redFromStore.RedSocial = redCreationToPatch.RedSocial;

            return NoContent();
        }

        //Eliminar una Fakin red Social 
        [HttpDelete("{alumnoid}/red/{redid}")]
        public IActionResult Delete(int alumnoid, int redid)
        {
            var alumno = AlumnosDbContext.context.Alumno.FirstOrDefault(a => a.ID == alumnoid);
            if (alumno == null)
            {
                return NotFound();
            }

            var redFromStore = alumno.Redes.FirstOrDefault(r => r.ID == redid);
            if (redFromStore == null)
            {
                return NotFound();
            }

            alumno.Redes.Remove(redFromStore);
            return NoContent();
        }
    }
}
