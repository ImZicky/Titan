using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Titan.Models
{
    public class SecaoEntity: BaseModel
    {
        public SecaoEntity()
        {
        }

        public SecaoEntity(CATEGORIA categoria, string nome, LojaEntity loja)
        {
            Categoria = categoria;
            Nome = nome;
            Loja = loja;
        }

        public CATEGORIA Categoria { get; set; }

        public string Nome { get; set; }

        public LojaEntity Loja { get; set; } // PERGUNTAR SE PODE FAZER DESSE JEITO COM LOJAENTITY AO INVEZ DE INT






    }

}
