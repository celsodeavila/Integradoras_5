using CaoLendario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CaoLendario.Models
{
    public class EFMedicoVeterinarioRepositorio : IMedicoVeterinarioRepositorio
    {
        public ApplicationDbContext context;

        public EFMedicoVeterinarioRepositorio (ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<MedicoVeterinario> medicosVeterinarios => context.MedicosVeterinario
            .Include(pre => pre.preadocao);
       
        public void Create(MedicoVeterinario medicoVeterinario)
        {
            context.Add(medicoVeterinario);
            context.SaveChanges();
        }

        public void Delete(MedicoVeterinario medicoVeterinario)
        {
            context.Remove(medicoVeterinario);
            context.SaveChanges();
        }

        public void Edit(MedicoVeterinario medicoVeterinario)
        {
            context.Entry(medicoVeterinario).State = EntityState.Modified;
            context.SaveChanges();
        }

        public MedicoVeterinario ObterMedicoVeterinario(int id)
        {
            var mv = context.MedicosVeterinario.FirstOrDefault(m => m.UserID == id);
            return mv;
        }
    }
}
