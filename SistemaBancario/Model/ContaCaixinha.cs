using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Model
{
    //using System;

        public class ContaCaixinha : Conta
        {
            public decimal Limite { get; private set; }

            public ContaCaixinha(decimal saldo) : base(saldo)
            {
            }

            public ContaCaixinha(Cliente cliente) : base(cliente)
            {
            }

            public ContaCaixinha(decimal saldo, decimal limite) : base(saldo)
            {
                if (limite < 0)
                    throw new ArgumentException("Não é permitido definir um limite negativo.");

                Limite = limite;
            }

            public override void Sacar(decimal valor)
            {
                if (valor <= 0)
                    throw new ArgumentException("O valor informado para saque deve ser positivo.");

                if (valor > Saldo + Limite)
                    throw new InvalidOperationException("Saque não autorizado: saldo insuficiente.");

                Saldo -= valor;
            }

            public override void Transferir(decimal valor, Conta contaDestino)
            {
                if (valor > Saldo + Limite)
                    throw new InvalidOperationException("Transferência não permitida por falta de saldo.");

                base.Transferir(valor, contaDestino);
            }
        }
    
    

}
