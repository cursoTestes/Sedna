using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaVendas;

namespace TesteVendas
{
    [TestClass]
    public class TesteCalculoComissao
    {
       [TestMethod]
        public void teste_comissao_venda_100_reais_retorna_5()
        {
           decimal valorVenda = 100;
           decimal comissaoVendaEsperada = 5;

           decimal valorComissaoRetornado = CalculadoraComissao.calculaComissao(valorVenda);

           Assert.AreEqual(comissaoVendaEsperada, valorComissaoRetornado);
        }

        [TestMethod]
        public void teste_comissao_venda_200_reais_retorna_10()
        {
            decimal valorVenda = 200;
            decimal comissaoVendaEsperada = 10;
            decimal valorComissaoRetornado = CalculadoraComissao.calculaComissao(valorVenda);

            Assert.AreEqual(comissaoVendaEsperada, valorComissaoRetornado);
 
        }

        [TestMethod]
        public void teste_comissao_venda_10000_reais_retorna_500()
        {
            decimal valorVenda = 10000;
            decimal comissaoVendaEsperada = 500;
            decimal valorComissaoRetornado = CalculadoraComissao.calculaComissao(valorVenda);

            Assert.AreEqual(comissaoVendaEsperada, valorComissaoRetornado);

        }

        [TestMethod]
        public void teste_comissao_venda_1_real_retorna_5_centavos()
        {
            decimal valorVenda = 1;
            decimal comissaoVendaEsperada = 0.05M;
            decimal valorComissaoRetornado = CalculadoraComissao.calculaComissao(valorVenda);

            Assert.AreEqual(comissaoVendaEsperada, valorComissaoRetornado);
        }

        [TestMethod]
        public void teste_comissao_venda_0_real_retorna_0_centavos()
        {
            decimal valorVenda = 0;
            decimal comissaoVendaEsperada = 0;
            decimal valorComissaoRetornado = CalculadoraComissao.calculaComissao(valorVenda);

            Assert.AreEqual(comissaoVendaEsperada, valorComissaoRetornado);
        }

        [TestMethod]
        public void teste_comissao_venda_100000_reais_retorna_6000_reais()
        {
            decimal valorVenda = 100000;
            decimal comissaoVendaEsperada = 6000;
            decimal valorComissaoRetornado = CalculadoraComissao.calculaComissao(valorVenda);

            Assert.AreEqual(comissaoVendaEsperada, valorComissaoRetornado);
        }

        [TestMethod]
        public void teste_comissao_venda_10001_reais_retorna_600_reais_6_centavos()
        {
            decimal valorVenda = 10001;
            decimal comissaoVendaEsperada = 600.06M;
            decimal valorComissaoRetornado = CalculadoraComissao.calculaComissao(valorVenda);

            Assert.AreEqual(comissaoVendaEsperada, valorComissaoRetornado);
        }

        [TestMethod]
        public void teste_comissao_venda_55e59_reais_retorna_2e77()
        {
            decimal valorVenda = 55.59M;
            decimal comissaoVendaEsperada = 2.77M;
            decimal valorComissaoRetornado = CalculadoraComissao.calculaComissao(valorVenda);

            Assert.AreEqual(comissaoVendaEsperada, valorComissaoRetornado);
        }
    }
}
