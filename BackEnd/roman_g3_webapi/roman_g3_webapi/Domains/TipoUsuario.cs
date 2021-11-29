using System;
using System.Collections.Generic;

#nullable disable

namespace roman_g3_webapi.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public byte IdTipoUsuario { get; set; }
        public string NomeTipo { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
