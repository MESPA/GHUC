using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GHMNUNIDADDECAPACITACION.Models
{
    public class Departamento
    {
        [Key]
        public int IdDepartamentoss { get; set; }
        public string Descripcion { get; set; }

    }
}