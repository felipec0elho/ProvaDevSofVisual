
namespace FolhaPagamentoAPI.Models;


    public class Funcionario
    {
        public int Id { get; set; } 
        [Required]
        public string Nome { get; set; }

        [Required]
        public string CPF { get; set; }
    }