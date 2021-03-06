﻿using API.UTRG.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.UTRG.Models
{
    public class AlumnoDto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int NumRedes { get { return Redes.Count; } }
        public ICollection<RedSocialDto> Redes { get; set; } = new List<RedSocialDto>();
    }
}
