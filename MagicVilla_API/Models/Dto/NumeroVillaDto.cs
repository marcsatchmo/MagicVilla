using MagicVilla_API.Modelos;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MagicVilla_API.Models.Dto
{
    public class NumeroVillaDto
    {
        [Required]
        public int VillaNro { get; set; }

        [Required]
        public int VillaId { get; set; }

        public string DetalleEspecial { get; set; }
    }
}
