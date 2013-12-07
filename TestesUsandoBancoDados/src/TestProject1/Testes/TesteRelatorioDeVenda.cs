using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using MbUnit.Framework;
using SistemaVendas.Negocio;
using NHibernate;

namespace TestProject1.Testes
{
    [TestFixture]
    public class TesteRelatorioDeVenda : TesteBase
    {
        [Test]
        public void teste_consulta_vendedor9999_inexistente()
        {
            ISession session = Contexto.SessionFactory.OpenSession();
            RelatorioVendasRepository relatorioVendas = new RelatorioVendasRepository(session);

            decimal valorEsperado = 0;
            int idVendedor = 9999;
            int ano = 2011;

            decimal valorAnual = relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }

        [Test]
        public void teste_consulta_vendedor2_semVenda_no_ano()
        {
            ISession session = Contexto.SessionFactory.OpenSession();
            RelatorioVendasRepository relatorioVendas = new RelatorioVendasRepository(session);

            decimal valorEsperado = 0;
            int idVendedor = 2;
            int ano = 2013;

            decimal valorAnual = relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);            
        }

        [Test]
        public void teste_consulta_vendedor3_umaVenda_no_ano_2010()
        {
            ISession session = Contexto.SessionFactory.OpenSession();
            RelatorioVendasRepository relatorioVendas = new RelatorioVendasRepository(session);

            decimal valorEsperado = 50;
            int idVendedor = 3;
            int ano = 2010;

            decimal valorAnual = relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }

        [Test]
        public void teste_consulta_vendedor4_duasVendas_no_ano_2010()
        {
            ISession session = Contexto.SessionFactory.OpenSession();
            RelatorioVendasRepository relatorioVendas = new RelatorioVendasRepository(session);

            decimal valorEsperado = 100;
            int idVendedor = 4;
            int ano = 2010;

            decimal valorAnual = relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }

        [Test]
        public void teste_consulta_vendedor5_com_uma_Venda__compartilhada_no_ano_2014()
        {
            ISession session = Contexto.SessionFactory.OpenSession();
            RelatorioVendasRepository relatorioVendas = new RelatorioVendasRepository(session);

            decimal valorEsperado = 50;
            int idVendedor = 5;
            int ano = 2014;

            decimal valorAnual = relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }
    }
}
