using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CaoLendario.Models
{
    public class EFInteresseRepositorio:IInteresseRepositorio
    {
        public ApplicationDbContext context;

        public EFInteresseRepositorio(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Interesse> Interesse => context.Interesse
        .Include(a => a.Adotante);

        

        public void Create(Interesse interesse)
        {
            context.Add(interesse);
            context.SaveChanges();
        }

        public Interesse ObterInteresse(int id)
        {
            var interesse = context.Interesse
            .Include(a => a.Adotante)
           .FirstOrDefault(i => i.InteresseID == id);
            return interesse;
        }
        public void Edit(Interesse interesse)
        {
            context.Entry(interesse).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(Interesse interesse)
        {
            context.Remove(interesse);
            context.SaveChanges();
        }
    }
}
