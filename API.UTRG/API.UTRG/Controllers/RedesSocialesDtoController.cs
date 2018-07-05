using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.UTRG.Controllers
{
    [Route("api")]
    public class RedesSocialesDtoController:Controller
    {
        [HttpGet("alumno/{id}/redes")]
        public IActionResult GetAll(int id)
        {
            var alumno = AlumnosDbContext.context.Alumno.FirstOrDefault(alu => alu.ID == id);
            if (alumno==null||alumno.Redes==null)
            {
                return NotFound();
            }
            return Ok(alumno.Redes);
        }

        [HttpGet("alumno/{alumnoid}/redes/{redid}")]
        public IActionResult GetAlumnoByRedID(int alumnoid,int redid)
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
    }
}
