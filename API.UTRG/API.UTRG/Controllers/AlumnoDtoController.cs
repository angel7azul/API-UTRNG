using API.UTRG.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.UTRG.Controllers
{

    [Route("api")]
    public class AlumnoDtoController : Controller
    {
        [HttpGet("agenda")]
        public IActionResult Get()
        {
            return Ok(AlumnosDbContext.context.Alumno);
        }

        [HttpGet("agenda/{id}",Name ="Creado")]
        public IActionResult GetById(int id)
        {
            var alumno = AlumnosDbContext.context.Alumno.FirstOrDefault(alu => alu.ID == id);
            if (alumno == null)
            {
                return NotFound();
            }
            return Ok(alumno);
        }
        //mes, y por parte del nombre

        [HttpGet("month/{mes}")]
        public IActionResult GetByMonth(string mes)
        {
            int mesNum = 0;
            switch (mes.ToLower())
            {
                case "enero":
                    mesNum = 1;
                    break;
                case "febrero":
                    mesNum = 2;
                    break;
                case "marzo":
                    mesNum = 3;
                    break;
                case "abril":
                    mesNum = 4;
                    break;
                case "mayo":
                    mesNum = 5;
                    break;
                case "junio":
                    mesNum = 6;
                    break;
                case "julio":
                    mesNum = 7;
                    break;
                case "agosto":
                    mesNum = 8;
                    break;
                case "septiembre":
                    mesNum = 9;
                    break;
                case "octubre":
                    mesNum = 10;
                    break;
                case "noviembre":
                    mesNum = 11;
                    break;
                case "diciembre":
                    mesNum = 12;
                    break;
                default:
                    return NotFound();
            }
            var alumno = AlumnosDbContext.context.Alumno.Where(a => a.FechaNacimiento.Date.Month == mesNum);
            if (alumno == null)
            {
                return NotFound();
            }
            return Ok(alumno);
        }

        [HttpGet("nombre/{nom}")]
        public IActionResult GetByName(string nom)
        {
            var alumno = AlumnosDbContext.context.Alumno.Where(a => a.Nombre.Contains(nom.ToLower()));
            if (alumno.Count() == 0)
            {
                return NotFound();
            }
            return Ok(alumno);
        }

        [HttpPost("add")]
        public IActionResult Post([FromBody] AlumnoDto alumno)
        {
            if (alumno == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            AlumnosDbContext.context.Alumno.Add(alumno);

            return new CreatedAtRouteResult("Creado", new { id = alumno.ID }, alumno);
        }
    }
}