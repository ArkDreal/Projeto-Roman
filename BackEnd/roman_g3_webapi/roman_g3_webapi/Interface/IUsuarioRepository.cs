using roman_g3_webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace roman_g3_webapi.Interface
{
    interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);
    }
}
