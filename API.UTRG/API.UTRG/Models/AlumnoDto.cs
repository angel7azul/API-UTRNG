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
        [MaxLength(30)]
        [Required]
        public string Nombre { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public int NumRedes { get { return Redes.Count; } }
        [Required]
        public ICollection<RedesSociales> Redes { get; set; } = new List<RedesSociales>();
    }
}
