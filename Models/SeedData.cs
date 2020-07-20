using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaoLendario.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context =
           app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            if (!context.Animais.Any())
            {
                context.Animais.AddRange(
                new Animal
                {
                    NomeAnimal = "Pingo",
                    Nascimento = DateTime.Today,
                    Peso = 50.0,
                    Sexo = TSexo.Masculino,
                    TipoPelagem = TPelagem.Curto,
                    Porte = TPorte.Médio,
                    GostaBrincar = true,
                    Temperamento = "calmo",
                    RelacionaOutroCao = true,
                    RelacionaGato = true,
                    PossuiDeficiencia = false,
                    HistoricoVida = "15 anos de vida",
                    UrlFoto = "https://bordalo.observador.pt/500x,q85/https://s3.observador.pt/wp-content/uploads/2020/03/16193524/95572844_770x433_acf_cropped.jpg",

                },
               new Animal
               {
                   NomeAnimal = "Bethoven",
                   Nascimento = DateTime.Today,
                   Peso = 20.0,
                   Sexo = TSexo.Feminino,
                   TipoPelagem = TPelagem.Longo,
                   Porte = TPorte.Grande,
                   GostaBrincar = true,
                   Temperamento = "Bravo",
                   RelacionaOutroCao = true,
                   RelacionaGato = true,
                   PossuiDeficiencia = false,
                   HistoricoVida = "10 anos de vida",
                   UrlFoto = "https://www.acessa.com/animais/arquivo/noticias/2019/05/10-praca-bom-pastor-tera-feira-adocao-caes-gatos/foto.jpg",
               },
               new Animal
               {
                   NomeAnimal = "Pitoko",
                   Nascimento = DateTime.Today,
                   Peso = 40.0,
                   Sexo = TSexo.Masculino,
                   TipoPelagem = TPelagem.Curto,
                   Porte = TPorte.Médio,
                   GostaBrincar = true,
                   Temperamento = "calmo",
                   RelacionaOutroCao = true,
                   RelacionaGato = true,
                   PossuiDeficiencia = false,
                   HistoricoVida = "5 anos de vida",
                   UrlFoto = "https://mid.curitiba.pr.gov.br/2019/capa/00260110.jpg",
               },
               new Animal
               {
                   NomeAnimal = "Tufão",
                   Nascimento = DateTime.Today,
                   Peso = 40.0,
                   Sexo = TSexo.Masculino,
                   TipoPelagem = TPelagem.Longo,
                   Porte = TPorte.Médio,
                   GostaBrincar = true,
                   Temperamento = "calmo",
                   RelacionaOutroCao = true,
                   RelacionaGato = true,
                   PossuiDeficiencia = false,
                   HistoricoVida = "8 anos de vida",
                  UrlFoto = "https://mid.curitiba.pr.gov.br/2019/capa/00260110.jpg",
               },
               new Animal
               {
                   NomeAnimal = "Leci",
                   Nascimento = DateTime.Today,
                   Peso = 20.0,
                   Sexo = TSexo.Feminino,
                   TipoPelagem = TPelagem.Curto,
                   Porte = TPorte.Médio,
                   GostaBrincar = true,
                   Temperamento = "calmo",
                   RelacionaOutroCao = true,
                   RelacionaGato = true,
                   PossuiDeficiencia = false,
                   HistoricoVida = "10 anos de vida",
                   UrlFoto = "https://upload.wikimedia.org/wikipedia/commons/2/24/Babylone_3ans1.jpg",
               });
                context.SaveChanges();
            }
            if (!context.ProcedimentosPreAdocao.Any())
            {
                context.ProcedimentosPreAdocao.AddRange(
                new ProcedimentosPreAdocao
                {
                    descricao = "Animal bem cuidado e bem alimentado",
                    data = DateTime.Today,
                    AnimalID = 1
                },
               new ProcedimentosPreAdocao
               {
                   descricao = "Animal bem cuidado e bem alimentado e vacinado",
                   data = DateTime.Today,
                   AnimalID = 1
               });
               context.SaveChanges();
            }
            if (!context.ProcedimentosPosAdocao.Any())
            {
                context.ProcedimentosPosAdocao.AddRange(
                new ProcedimentosPosAdocao
                {
                    descricao = "Animal bem cuidado e bem alimentado",
                    data = DateTime.Today,
                    AnimalID = 1
                },
               new ProcedimentosPosAdocao
               {
                   descricao = "Animal bem cuidado e bem alimentado e vacinado",
                   data = DateTime.Today,
                   AnimalID = 1
               });
               context.SaveChanges();
            }
            if (!context.Adotantes.Any())
            {
                context.Adotantes.AddRange(
                new Adotante
                {
                    nome = "Alberto",
                    email = "alberto@albertp.com",
                    senha = "alberto",
                    data_nascimento = DateTime.Today,
                    endereco = "Rua Treze, 35, jd das palemiras",
                    cep = "3713000",
                    uf = "MG",
                    telefone = "3566998877",
                    moradia = tipoMoradia.Casa,
                    porte = prefPorte.Grande,
                    filhote = prefFilhote.Indiferente,
                    castrado = prefCastrado.Indiferente,
                    sexo = prefSexo.Fêmea,
                    talimentacao = alimentacao.Ambos
                });
                context.SaveChanges();
            }
        }
    }
}
