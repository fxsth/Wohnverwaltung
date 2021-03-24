using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wohnverwaltung.Models
{
    public class Wohnung
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        [StringLength(50, ErrorMessage = "Die Bezeichnung darf maximal 50 Zeichen lang sein")]
        public string Bezeichnung { get; set; }
        [Required]
        [MaxLength(255)]
        [StringLength(255, ErrorMessage = "Die Straße darf maximal 255 Zeichen lang sein")]
        public string Straße { get; set; }
        [Required]
        [Range(10000, 99999, ErrorMessage = "Bitte gib eine gültige fünfstellige PLZ ein")]
        public int PLZ { get; set; }
        [Required]
        [MaxLength(255)]
        [StringLength(255, ErrorMessage = "Der Ort darf maximal 255 Zeichen lang sein")]
        public string Ort { get; set; }
        [Display(Name = "Ist Inaktiv?")]
        public bool IstInaktiv { get; set; }
    }
}
