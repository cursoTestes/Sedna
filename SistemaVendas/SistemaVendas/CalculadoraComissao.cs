using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVendas
{
    public class CalculadoraComissao
    {

        public static decimal calculaComissao(decimal valorVenda)
        {
            decimal comissao = 0;
            if (valorVenda > 10000)
                comissao = valorVenda * 0.06M;
            else
                comissao = valorVenda * 0.05M;
            comissao = comissao * 100;
            comissao = Math.Floor(comissao);
            comissao = comissao / 100;


            return comissao;
        }
    }
}
