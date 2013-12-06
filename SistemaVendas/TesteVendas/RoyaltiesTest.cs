using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaVendas;
using Moq;

namespace VendasUnitTest
{
    [TestClass]
    public class RoyaltiesTest
    {
        Mock<IRepositorioVendas> mockRepository = null;
        Mock<CalculadoraComissao> mockCalcComissao = null;

        [TestInitialize]
        public void initialize()
        {
            mockRepository = new Mock<IRepositorioVendas>();
            mockCalcComissao = new Mock<CalculadoraComissao>();
        }

        [TestMethod]
        public void teste_royalties_por_mes_ano_sem_vendas()
        {
            decimal valorEsperado = 0;
            int mes = 1;
            int ano = 2013;
                       
            mockRepository.Setup(mock => mock.GetVendas(mes, ano))
                .Returns(new List<decimal>());                        

            decimal valorRetorno = new CalculoRoyalties(mockRepository.Object, 
                mockCalcComissao.Object).calculaRoyalties(mes, ano);

            Assert.AreEqual(valorEsperado, valorRetorno);
        }

        [TestMethod]
        public void teste_royalties_por_mes_ano_com_uma_venda()
        {
            decimal valorVenda = 100;
            decimal valorComissao = 5;
            decimal valorEsperado = 19;
            int mes = 2;
            int ano = 2013;

            mockRepository.Setup(mock => mock.GetVendas(mes, ano))
                .Returns(new List<decimal> { valorVenda });

            mockCalcComissao.Setup(mock => mock.calculaComissao(valorVenda))
                .Returns(valorComissao);
            
            decimal valorRetorno = new CalculoRoyalties(mockRepository.Object, 
                mockCalcComissao.Object).calculaRoyalties(mes, ano);

            Assert.AreEqual(valorEsperado, valorRetorno);
        }

        [TestMethod]
        public void teste_royalties_por_mes_ano_com_duas_vendas()
        {
            decimal valorVenda1 = 100;
            decimal valorVenda2 = 200;

            decimal valorComissao1 = 0;
            decimal valorComissao2 = 0;

            decimal valorEsperado = 60M;
            int mes = 2;
            int ano = 2013;

            mockRepository.Setup(mock => mock.GetVendas(mes, ano))
                .Returns(new List<decimal> { valorVenda1, valorVenda2 });

            mockCalcComissao.Setup(mock => mock.calculaComissao(valorVenda1))
                .Returns(valorComissao1);

            mockCalcComissao.Setup(mock => mock.calculaComissao(valorVenda2))
                .Returns(valorComissao2);

            decimal valorRetorno = new CalculoRoyalties(mockRepository.Object,
                mockCalcComissao.Object).calculaRoyalties(mes, ano);

            Assert.AreEqual(valorEsperado, valorRetorno);

            mockCalcComissao.Verify(mock => mock.calculaComissao(It.IsAny<decimal>()),Times.Exactly(2));

        }
                
    }
            
}
