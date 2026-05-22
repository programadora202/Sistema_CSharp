// ============================================================
// Models/Compra.cs
// Tabela "Compras"
// ============================================================

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoveisCarrara.Models
{
    [Table("compras_materiais")]
    public class CompraMaterial
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Compra é obrigatória")]
        [Column("compra_codigo")]
        public int CompraCodigo { get; set; }

        [Required(ErrorMessage = "Material é obrigatório")]
        [Column("material_codigo")]
        public int MaterialCodigo { get; set; }   


        [Required(ErrorMessage = "Material é obrigatório")]
        [Column("item")]
        public int Item { get; set; }

        [Required(ErrorMessage = "Material é obrigatório")]
        [Column("qtd")]
        public int Qtd { get; set; }

        [Required(ErrorMessage = "Material é obrigatório")]
        [Column("preco", TypeName = "decimal(10,2)")]

        public decimal Preco { get; set; }

        [Required]
        [StringLength(20)]
        [Column("dimensoes")]

        public string Dimensoes { get; set; } = "";

        [Required]
        [StringLength(200)]
        [Column("descricao")]

        public string Descricao { get; set; } = "";

        // Navegação
        [ForeignKey("compra_codigo")]
        public Compra? Compra { get; set; }

        [ForeignKey("material_codigo")]
        public Material? Material { get; set; }
    }
}
