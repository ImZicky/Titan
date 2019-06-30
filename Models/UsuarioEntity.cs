using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Titan.Models
{
    public class UsuarioEntity: BaseModel
    {
        public UsuarioEntity()
        {
        }

        public UsuarioEntity(TIPO tipo, string email, string senha)
        {
            Tipo = tipo;
            Email = email;
            Senha = senha;
        }

        public TIPO Tipo { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }



    }




}


