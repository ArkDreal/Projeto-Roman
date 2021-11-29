using roman_g3_webapi.Contexts;
using roman_g3_webapi.Domains;
using roman_g3_webapi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace roman_g3_webapi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        RomanContext ctx = new RomanContext();

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
