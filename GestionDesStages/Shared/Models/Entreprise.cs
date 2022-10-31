using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesStages.Shared.Models
{
    public class Entreprise
    {

        [Key]
        [StringLength(450)]
        public string Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Adresse { get; set; }
        [Required]
        [StringLength(100)]
        public string Nom { get; set; }
        [Required]
        [StringLength(100)]
        public string NomResponsable { get; set; }
        [Required]
        [StringLength(100)]
        public string PrenomResponsable { get; set; }
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        public string TelephoneCellulaire { get; set; }
        [StringLength(20)]
        public string PosteTelephonique { get; set; }
    }
}
