using System;
using System.Collections.Generic;

#nullable disable

namespace roman_g3_webapi.Domains
{
    public partial class Projeto
    {
        public int IdProjeto { get; set; }
        public short? IdTema { get; set; }
        public int? IdProfessor { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }

        public virtual Professor IdProfessorNavigation { get; set; }
        public virtual Tema IdTemaNavigation { get; set; }
    }
}
