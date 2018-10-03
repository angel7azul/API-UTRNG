using API.UTRG.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.UTRG.Controllers
{
    public class DummyController:Controller
    {
        private AlumnoInfoDbContext _ctx;

        public DummyController(AlumnoInfoDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        [Route("api/testdatabase")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}