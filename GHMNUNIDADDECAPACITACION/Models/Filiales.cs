
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GHMNUNIDADDECAPACITACION.Models
{
    
    public class Filiales 
    {
        [Key]
        public virtual int IdFilial { get; set; }

        [Required]
        public virtual string Descripcion { get; set; }

        [Required]
        [MaxLength(2)]
        public virtual string Abreviacion { get; set; }

        public string info { get; set; }
    }
}