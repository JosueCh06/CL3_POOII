using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace CL3_POOII_JosueDanielChupicaInga.Models
{
    public class curso
    {
        [Display(Name = "IdCurso", Order = 0)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese el id del curso")]
        public string idCur { get; set; }

        [Display(Name = "IdTarifa", Order = 1)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Escoge tarifa")]
        public string idTar { get; set; }

        [Display(Name = "Nombre del Curso", Order = 2)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese el nombre del curso")]
        public string NomCur { get; set; }
    }
}

