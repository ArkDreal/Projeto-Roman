using System;
using System.Collections.Generic;

namespace roman_webapi.Domains
{
    public partial class Professor
    {
        public int IdProfessor { get; set; }
        public int? IdUsuario { get; set; }
        public string Nome { get; set; } = null!;
        public string Sobrenome { get; set; } = null!;
        public string Cpf { get; set; } = null!;

        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
