using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Titan.Models
{
    public class SatisfacaoEntity: BaseModel
    {
        public SatisfacaoEntity()
        {
        }

        public SatisfacaoEntity(SENTIMENTO sentimento, DateTime dtIns, LojaEntity loja, SecaoEntity secao)
        {
            Sentimento = sentimento;
            DtIns = dtIns;
            Loja = loja;
            Secao = secao;
        }

        public SENTIMENTO Sentimento { get; set; }

        public DateTime DtIns { get; set; }

        public LojaEntity Loja { get; set; } // PERGUNTAR SE PODE FAZER DESSE JEITO COM LOJAENTITY AO INVEZ DE INT
        public SecaoEntity Secao { get; set; }



    }


}
