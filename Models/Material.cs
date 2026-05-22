// ============================================================
// Models/Material.cs
// Tabela "Materiais"
// ============================================================

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoveisCarrara.Models
{
    [Table("Materiais")]  //Tabela "Materiais"
    public class Material
    {
        [Key]
        [Column("codigo")]
        public int Codigo { get; set; }

        [Required]
        [StringLength(100)]
        [Column("nome_material")]
        public string NomeMaterial { get; set; } = "";

        [Required]
        [StringLength(200)]
        [Column("descricao")]

        public string Descricao { get; set; } = "";

        [Column("preco", TypeName = "decimal(10,2)")]

        public decimal Preco { get; set; }
    }
}