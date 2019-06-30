using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Titan.Models
{
    public class LojaEntity: BaseModel
    {
        public LojaEntity()
        {
        }

        public LojaEntity(string nome, List<UsuarioEntity> usuarios)
        {
            Nome = nome;
            Usuarios = usuarios;
        }

        public string Nome { get; set; }

        public List<UsuarioEntity> Usuarios { get; set; } = new List<UsuarioEntity>();





    }
}
