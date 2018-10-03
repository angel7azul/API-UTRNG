using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.UTRG.Entities
{
    public class RedSocials
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        public string Nombre { get; set; }
        public string RedSocial { get; set; }
        [ForeignKey("AlumnoId")]
        public Alumno Alumno { get; set; }
        public int AlumnoId { get; set; }
    }
}
