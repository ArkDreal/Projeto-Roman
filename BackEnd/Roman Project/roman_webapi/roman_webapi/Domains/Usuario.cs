using System;
using System.Collections.Generic;

namespace roman_webapi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Professors = new HashSet<Professor>();
        }

        public int IdUsuario { get; set; }
        public byte? IdTipoUsuario { get; set; }
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;

        public virtual TipoUsuario? IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Professor> Professors { get; set; }
    }
}
