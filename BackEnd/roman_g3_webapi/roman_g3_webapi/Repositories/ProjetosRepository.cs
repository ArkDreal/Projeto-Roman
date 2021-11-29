using roman_g3_webapi.Contexts;
using roman_g3_webapi.Domains;
using roman_g3_webapi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace roman_g3_webapi.Repositories
{
    public class ProjetosRepository : IProjetosRepository
    {
        RomanContext ctx = new RomanContext();
        public Projeto BuscarPorId(int id)
        {
            return ctx.Projetos.FirstOrDefault(e => e.IdProjeto == id);
        }

        public void Cadastrar(Projeto novoProjeto)
        {
            ctx.Projetos.Add(novoProjeto);

            ctx.SaveChanges();
        }

        public List<Projeto> Listar()
        {
            return ctx.Projetos
                .Select(p => new Projeto()
                {
                    IdProjeto = p.IdProjeto,
                    Titulo = p.Titulo,
                    IdTemaNavigation = new Tema
                    {
                        NomeTema = p.IdTemaNavigation.NomeTema
                    },
                    IdProfessorNavigation = new Professor
                    {
                        Nome = p.IdProfessorNavigation.Nome,
                        Sobrenome= p.IdProfessorNavigation.Sobrenome,
                    }
                })
                .ToList();
        }
    }
}
