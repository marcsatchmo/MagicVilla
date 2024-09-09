using System.ComponentModel.DataAnnotations;

namespace MagicVilla_API.Models.Dto
{
    public class NumeroVillaUpdateDto
    {
        [Required]
        public int VillaNro { get; set; }

        [Required]
        public int VillaId { get; set; }

        public string DetalleEspecial { get; set; }
    }
}
