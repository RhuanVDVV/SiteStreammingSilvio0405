using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteStreammingSilvio0405.Models
{
    [Table ("Streaming")]
    public class Streamming
    {
        [Column ("StreammingID")]
        [Display(Name="Id")]
        public int Id { get; set; }

        [Column("TamanhoVideo")]
        [Display(Name = "Tamanho")]
        [Required]
        public int Size { get; set; }

        [Column("TipoVideo")]
        [Display(Name = "Tipo")]
        [Required]
        public string Tipo { get; set; }


        [Column("TituloVideo")]
        [Display(Name = "Titulo")]
        [Required]
        public string Titulo { get; set; }

        [Column("DescriçãoVideo")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        
    }
}
