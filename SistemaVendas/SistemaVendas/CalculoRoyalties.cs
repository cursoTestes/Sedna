using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVendas
{
    public class CalculoRoyalties
    {
        private IRepositorioVendas repositorio;
        private CalculadoraComissao calcComissao;

        public CalculoRoyalties(IRepositorioVendas paramRepositorio, CalculadoraComissao paramCalcComissao)
        {
            this.repositorio = paramRepositorio;
            this.calcComissao = paramCalcComissao;
        }

        public decimal calculaRoyalties(int mes, int ano)
        {
            List<decimal> vendas = repositorio.GetVendas(mes, ano);

            if (vendas != null && vendas.Count > 0)
            {
                decimal totalLiquido = 0;
                foreach (decimal venda in vendas)
                {
                    totalLiquido += venda;// -this.calcComissao.calculaComissao(venda);
                }
                return totalLiquido * 0.2M;
            }

            return 0;
        }
    }
}
