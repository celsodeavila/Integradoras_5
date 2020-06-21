using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaoLendario.Models
{
    public class Animal
    {
        public int AnimalID { get; set; }
        public string NomeAnimal { get; set; }
        public DateTime Nascimento { get; set; }
        public double Peso { get; set; }
        public TSexo Sexo { get; set; }
        public TPelagem TipoPelagem { get; set; }
        public TPorte Porte { get; set; }
        public bool GostaBrincar { get; set; }
        public string Temperamento { get; set; }
        public bool RelacionaOutroCao { get; set; }
        public bool RelacionaGato { get; set; }
        public bool PossuiDeficiencia { get; set; }
        public string HistoricoVida { get; set; }
        public string UrlFoto { get; set; }

        public virtual ICollection<ProcedimentosPosAdocao> ProcedimentosPosAdocao { get; set; }

        public virtual ICollection<ProcedimentosPreAdocao> ProcedimentosPreAdocao { get; set; }

        public virtual ICollection<Interesse> Interesse { get; set; }
    }
    #region Definição das Enum
    public enum TPelagem
    {
        Curto,
        Médio,
        Longo
    }

    public enum TSexo
    {
        Masculino,
        Feminino
    }

    public enum TPorte
    {
        Pequeno,
        Médio,
        Grande
    }
    #endregion
}
