using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.UTRG.Models
{
    public class RedSocialForUpdate
    {
        [Required(ErrorMessage = "Este Campo es Requerido")]
        public string Nombre { get; set; }
        public string RedSocial { get; set; }
    }
}
