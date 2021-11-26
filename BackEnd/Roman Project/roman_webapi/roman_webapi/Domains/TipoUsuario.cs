using System;
using System.Collections.Generic;

namespace roman_webapi.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public byte IdTipoUsuario { get; set; }
        public string NomeTipo { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
