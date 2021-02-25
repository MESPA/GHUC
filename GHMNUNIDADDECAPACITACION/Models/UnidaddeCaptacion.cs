using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GHMNUNIDADDECAPACITACION.Models
{
    public class UnidaddeCaptacion
    {
        [Key]
        public int idUnidaddeCaptacion { get; set; }
        public string filial { get; set; }
        public string departamento { get; set; }
        public string puestoempleado { get; set; }
        public DateTime? fechasolicitud { get; set; }
        public string Areadepartamento { get; set; }
        public string cursorequerido { get; set; }
        public string importanciacurso { get; set; }
        public int cantidadempleados { get; set; }
        public DateTime fechacreacion { get; set; }
        public int estadosolicitud { get; set; }
        public string usuariocreacion { get; set; }
        public string Region { get; set; }

    }
}