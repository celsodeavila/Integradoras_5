using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace CaoLendario.Models
{
    public class ApplicationDbContext : DbContext //classe que define BD
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { }

        public DbSet<Animal> Animais { get; set; }
        public DbSet<Interesse> Interesse { get; set; }
        public DbSet<Adotante> Adotantes { get; set; }
        public DbSet<ProcedimentosPreAdocao> ProcedimentosPreAdocao { get; set; }
        public DbSet<ProcedimentosPosAdocao> ProcedimentosPosAdocao { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<MedicoVeterinario> MedicosVeterinario { get; set; }

    }
}
