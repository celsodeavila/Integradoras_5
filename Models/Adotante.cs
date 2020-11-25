using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaoLendario.Models
{
    public class Adotante : User
    {
        public tipoMoradia moradia { get; set; }
        public prefPorte porte { get; set; }
        public prefFilhote filhote { get; set; }
        public prefCastrado castrado { get; set; }
        public prefSexo sexo { get; set; }
        public alimentacao talimentacao { get; set; }
    }
    public enum tipoMoradia { Casa, Apartamento, Sítio, Outros }
    public enum prefPorte { Pequeno, Médio, Grande, Indiferente }
    public enum prefFilhote { Sim, Não, Indiferente }
    public enum prefCastrado { Sim, Não, Indiferente }
    public enum prefSexo { Fêmea, Macho }
    public enum alimentacao { Ração, Comida, Ambos, Outro }
}
