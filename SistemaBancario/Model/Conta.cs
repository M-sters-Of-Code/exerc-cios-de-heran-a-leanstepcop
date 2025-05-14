using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Model
{
    public class Conta
    {
        public long Numero { get; private set; }
        public decimal Saldo { get; protected set; }
        public Cliente Titular { get; protected set; }

        public Conta(decimal saldo)
        {
            if (saldo < 0)
                throw new ArgumentException("Saldo inicial inválido: não pode ser negativo.");

            Saldo = saldo;
        }

        public Conta(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException("Cliente obrigatório: não pode ser nulo.");

            Titular = cliente;
        }

        public virtual void Depositar(decimal valor)
        {
            if (valor <= 1)
                throw new ArgumentOutOfRangeException("O depósito precisa ser superior a R$1,00.");

            decimal bonus = 1;
            decimal valorTotal = valor + bonus;
            Saldo += valorTotal;
        }

        public virtual void Sacar(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor do saque deve ser positivo.");

            if (valor > Saldo)
                throw new InvalidOperationException("Operação cancelada: saldo insuficiente.");

            Saldo -= valor;
        }

        public virtual void Transferir(decimal valor, Conta contaDestino)
        {
            if (contaDestino == null)
                throw new ArgumentNullException("A conta de destino precisa ser informada.");

            if (valor <= 0)
                throw new ArgumentException("Valor da transferência deve ser maior que zero.");

            if (valor > Saldo)
                throw new InvalidOperationException("Transferência não autorizada: saldo insuficiente.");

            Saldo -= valor;
            contaDestino.Depositar(valor);
        }

        // Validações:
        // - O saque deve ser maior que zero e menor ou igual ao saldo.
        // - O depósito deve ser superior a R$1,00.
        // - A transferência segue as mesmas regras do saque.
    }
}
