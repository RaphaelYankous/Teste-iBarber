using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;    

namespace iBarber.Models
{
    [Table("Barbearias")]

    public class Barbearias
    {
        [Key]
        public int Id { get; set; }
        
       
        
        [Required(ErrorMessage = "Endereço é obrigatório")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Especialidade é obrigatório")]
        public string Especialidade { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        public ICollection<Serviços> Serviços{ get; set; }
    }
}
