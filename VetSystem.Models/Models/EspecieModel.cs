using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetSystem.Models.Models
{
    public class EspecieModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome é obrigatório!")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Este campo deve ter no mínimo 5 e no máximo 100 caracteres!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O Tipo precisa ser informado!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Este campo deve ter no mínimo 3 e no máximo 100 caracteres!")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "O sexo precisa ser informado!")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Este campo deve ter 1 caracteres!")]
        public string Sexo { get; set; }

        [Display(Name = "Raça")]
        [Required(ErrorMessage = "A raça precisa ser informada!")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Este campo deve ter no mínimo 5 e no máximo 100 caracteres!")]
        public string Raca { get; set; }
        [Required(ErrorMessage = "A Data de nascimento é obrigatória!")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "A data de inclusão é obrigatória!")]
        [Display(Name = "Data Inclusão")]
        public DateTime DataInclusao { get; set; }

        [Display(Name = "Data Alteração")]
        public DateTime? DataAlteracao { get; set; }
        public decimal? PesoKg { get; set; }

        [Display(Name = "Cor Pelagem")]
        [Required(ErrorMessage = "A cor precisa ser informada!")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Este campo deve ter no mínimo 5 e no máximo 100 caracteres!")]
        public string Cor { get; set; }


    }
}
