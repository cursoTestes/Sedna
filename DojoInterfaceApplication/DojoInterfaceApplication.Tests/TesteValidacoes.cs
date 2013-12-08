using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using DojoInterfaceApplication.Tests;

namespace SeleniumTests
{
    [TestClass]
    public class TesteValidacoes : TesteBase
    {
        [TestMethod]
        public void Retorna_Erro_quando_campos_obrigatorios_nao_sao_preenchidos()
        {
            driver.Navigate().GoToUrl(baseURL + "/Venda/Add");

            driver.FindElement(By.Id("Vendedor")).SendKeys("");
            driver.FindElement(By.Id("DataVenda")).SendKeys("");
            driver.FindElement(By.Id("Valor")).SendKeys("");

            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();

            String resultado = driver.FindElement(By.Id("validacaoVendedor")).Text;
            String esperado = "O campo Id Vendedor é obrigatório.";
            Assert.AreEqual(resultado, esperado);

            resultado = driver.FindElement(By.Id("validacaoDataVenda")).Text;
            esperado = "O campo Data Venda é obrigatório.";
            Assert.AreEqual(resultado, esperado);

            resultado = driver.FindElement(By.Id("validacaoValor")).Text;
            esperado = "O campo Valor é obrigatório.";
            Assert.AreEqual(resultado, esperado);

            Assert.AreEqual(baseURL + "/Venda/Add", driver.Url);

        }

        [TestMethod]
        public void Retorna_Erro_quandoIdEstaComLetra()
        {
            driver.Navigate().GoToUrl(baseURL + "/Venda/Add");

            driver.FindElement(By.Id("Vendedor")).SendKeys("gsddsfg");
            driver.FindElement(By.Id("DataVenda")).SendKeys("23/09/1992");
            driver.FindElement(By.Id("Valor")).SendKeys("10");

            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();

            String resultado = driver.FindElement(By.Id("validacaoVendedor")).Text;
            String esperado = "O campo Id Vendedor deve ser numérico.";
            Assert.AreEqual(resultado, esperado);

            Assert.AreEqual(baseURL + "/Venda/Add", driver.Url);

        }

        [TestMethod]
        public void Retorna_Sucesso_Com_Campos_Preenchidos_Corretamente()
        {
            driver.Navigate().GoToUrl(baseURL + "/Venda/Add");

            driver.FindElement(By.Id("Vendedor")).SendKeys("1");
            driver.FindElement(By.Id("DataVenda")).SendKeys("23/09/1992");
            driver.FindElement(By.Id("Valor")).SendKeys("10");

            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();

            String resultado = driver.FindElement(By.CssSelector("h2")).Text;
            String esperado = "Venda cadastrada com sucesso.";
            Assert.AreEqual(resultado, esperado);

            Assert.AreEqual(baseURL + "/Venda/Add", driver.Url);

        }

        [TestMethod]
        public void Retorna_Erro_quando_data_possui_valor_invalido()
        {
            driver.Navigate().GoToUrl(baseURL + "/Venda/Add");

            driver.FindElement(By.Id("Vendedor")).SendKeys("1");
            driver.FindElement(By.Id("DataVenda")).SendKeys("----");
            driver.FindElement(By.Id("Valor")).SendKeys("20");

            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();

            String resultado = driver.FindElement(By.Id("validacaoDataVenda")).Text;
            String esperado = "O campo Data Venda é obrigatório.";
            Assert.AreEqual(resultado, esperado);

  

            Assert.AreEqual(baseURL + "/Venda/Add", driver.Url);

        }

    }


}
