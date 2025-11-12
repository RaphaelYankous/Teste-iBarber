using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iBarber.Models
{
    [Table("Serviços")]
    public class Serviços
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório")]
        public decimal Preço { get; set; }

        [Display(Name = "Barbearia")]
        [Required(ErrorMessage = "Barbearia é obrigatória")]
        public int BarbeariaId { get; set; }

        [ForeignKey("BarbeariaId")]
        public Barbearias Barbearia { get; set; }   
    }
}
