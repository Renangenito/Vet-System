using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetSystem.Models.Models
{
    public class ProcedimentoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Nome Procedimento")]
        [Required(ErrorMessage = "O nome do procedimento é obrigatório!")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Este campo deve ter no mínimo 5 e no máximo 100 caracteres!")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "O Animal precisa ser informado!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Este campo deve ter no mínimo 3 e no máximo 100 caracteres!")]
        public string Animal { get; set; }

        [Required(ErrorMessage = "O Turno precisa ser informado!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Este campo deve ter no mínimo 3 e no máximo 100 caracteres!")]
        public string Turno { get; set; }

        [Required(ErrorMessage = "O Custo precisa ser informado!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Este campo deve ter no mínimo 3 e no máximo 100 caracteres!")]
        public decimal Custo { get; set; }

        [Required(ErrorMessage = "A data de inclusão é obrigatória!")]
        [Display(Name = "Data Inclusão")]
        public DateTime DataInclusao { get; set; }

        [Display(Name = "Data Alteração")]
        public DateTime? DataAlteracao { get; set; }
        public int? EspecieId { get; set; }
        public EspecieModel? EspecieModel { get; set; }
        public int? ClienteId { get; set; }
        public ClienteModel? ClienteModel { get; set; }
        public int? MedicamentoId { get; set; }
        public MedicamentoModel? MedicamentoModel { get; set; }
    }
}
