using System;
using System.Collections.Generic;

namespace roman_webapi.Domains
{
    public partial class Tema
    {
        public Tema()
        {
            Projetos = new HashSet<Projeto>();
        }

        public short IdTema { get; set; }
        public string NomeTema { get; set; } = null!;

        public virtual ICollection<Projeto> Projetos { get; set; }
    }
}
