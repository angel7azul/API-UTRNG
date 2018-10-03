using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.UTRG.Models
{
    public class AlumnoWithoutRedSocialDto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
