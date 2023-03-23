using System.ComponentModel.DataAnnotations;

namespace VetSystem.Models.Models
{
    public class LoginRequisicaoModel
    {
        [Required]
        public string Usuario { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}