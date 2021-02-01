using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vendaLanchesAsp.Models
{
    //[Table("lanche")]
    public class Lanche
    {
        public int LancheId { get; set; }
        [StringLength(200)]
        public string Nome { get; set; }
        [StringLength(200)]
        public string DescricaoCurta { get; set; }
        [StringLength(200)]
        public string DescricaoDetalhada { get; set; }
        public decimal Preco { get; set; }
        [StringLength(250)]
        public string ImagemUrl { get; set; }
        [StringLength(250)]
        public string ImagemThumbnailUrl { get; set; }
        public bool IsLanchePreferido { get; set; }
        public bool EmEstoque { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
