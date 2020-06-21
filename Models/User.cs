using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaoLendario.Models
{

    public class User
    {
        public int UserID { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public DateTime data_nascimento { get; set; }
        public string endereco { get; set; }
        public string cep { get; set; }
        public string uf { get; set; }
        public string telefone { get; set; }
        public ICollection<ProcedimentosPosAdocao> posadocao { get; set; }
        public ICollection<ProcedimentosPreAdocao> preadocao { get; set; }
    }


}
