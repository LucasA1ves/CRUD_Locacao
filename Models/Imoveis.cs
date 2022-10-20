using System.ComponentModel.DataAnnotations;

namespace CrudLocacao.Models
{
    public class Imoveis
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "O campo deve ter entre 3 a 200 caracteres")]
        public string Name { get; set; }
        public string Cep { get; set; }
    }
}
