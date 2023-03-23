using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetSystem.Models.Models
{
    public class LoginRespostaModel
    {
        public string Usuario { get; set; }
        public bool Autenticado { get; set; }

        public string Token { get; set; }

        public DateTime? DataExpiracao { get; set; }

    }
}
