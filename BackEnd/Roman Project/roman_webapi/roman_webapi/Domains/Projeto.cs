using System;
using System.Collections.Generic;

namespace roman_webapi.Domains
{
    public partial class Projeto
    {
        public int IdProjeto { get; set; }
        public short? IdTema { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descricao { get; set; } = null!;

        public virtual Tema? IdTemaNavigation { get; set; }
    }
}
