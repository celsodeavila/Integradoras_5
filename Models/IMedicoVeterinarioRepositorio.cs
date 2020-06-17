using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaoLendario.Models;

namespace CaoLendario.Models
{
    public interface IMedicoVeterinarioRepositorio
    {
        IQueryable<MedicoVeterinario> medicosVeterinarios { get; }
        public void Create(MedicoVeterinario medicoVeterinario);

        public MedicoVeterinario ObterMedicoVeterinario(int id);

        public void Edit(MedicoVeterinario medicoVeterinario);

        public void Delete(MedicoVeterinario medicoVeterinario);
    }
}
