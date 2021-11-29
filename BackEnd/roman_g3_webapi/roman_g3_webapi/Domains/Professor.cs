using System;
using System.Collections.Generic;

#nullable disable

namespace roman_g3_webapi.Domains
{
    public partial class Professor
    {
        public Professor()
        {
            Projetos = new HashSet<Projeto>();
        }

        public int IdProfessor { get; set; }
        public int? IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Projeto> Projetos { get; set; }
    }
}
