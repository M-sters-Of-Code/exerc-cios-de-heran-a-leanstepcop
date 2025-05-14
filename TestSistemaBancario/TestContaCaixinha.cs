using SistemaBancario.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSistemaBancario
{

    [TestClass]
    public class TestContaCaixinha
    {
        [TestMethod]
        public void DeveConfirmarQueContaCaixinhaDerivaDeConta()
        {
            decimal saldoInicial = 1000;
            ContaCaixinha caixinha = new ContaCaixinha(saldoInicial);

            bool ehSubclasse = typeof(Conta).IsAssignableFrom(caixinha.GetType());
            Assert.IsTrue(ehSubclasse);
        }

        [TestMethod]
        public void DeveDepositarValorEAtualizarSaldoComBonus()
        {
            decimal saldoInicial = 1000;
            decimal valorDeposito = 100;
            ContaCaixinha caixinha = new ContaCaixinha(saldoInicial);

            caixinha.Depositar(valorDeposito);

            Assert.AreEqual(1101, caixinha.Saldo);
        }

        [TestMethod]
        public void DeveSacarValorEAtualizarSaldoCorretamente()
        {
            decimal saldoInicial = 1000;
            decimal saque = 105;
            ContaCaixinha caixinha = new ContaCaixinha(saldoInicial);

            caixinha.Sacar(saque);

            Assert.AreEqual(895, caixinha.Saldo);
        }

        [TestMethod]
        public void DeveLancarExcecaoAoDepositarValorMenorQueUm()
        {
            decimal saldoInicial = 1000;
            decimal valorDeposito = 0.5m;
            ContaCaixinha caixinha = new ContaCaixinha(saldoInicial);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                caixinha.Depositar(valorDeposito)
            );
        }
    }

}
