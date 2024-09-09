using MagicVilla_API.Modelos;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_API.Models
{
    public class NumeroVilla
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VillaNro { get; set; }

        [Required]
        public int VillaId { get; set; }

        [ForeignKey("VillaId")]
        public Villa Villa { get; set; }

        public string DetalleEspecial { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaActualizacion { get; set; }
    }
}
