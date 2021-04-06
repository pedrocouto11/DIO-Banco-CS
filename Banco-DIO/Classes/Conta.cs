using System;
using System.Collections.Generic;
using System.Text;

namespace Banco_DIO
{
    class Conta
    {
        private string Nome { get; set; }

        private double Credito { get; set; }

        private double Saldo { get; set; }

        private TipoConta TipoConta { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            if (valorSaque <= 0)
            {
                Console.WriteLine("Impossível sacar valor negativo ou zero");
                return false;
            }

            if(this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            this.Saldo -= valorSaque;
            Console.WriteLine("Saque realizado. Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

            return true;
        }

        public bool Depositar(double valorDeposito)
        {
            if(valorDeposito <= 0)
            {
                Console.WriteLine("Impossível depositar valor menor ou igual a zero");
                return false;
            }
            this.Saldo += valorDeposito;
            Console.WriteLine("Depósito realizado. Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            return true;

        }

        public bool Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                if (contaDestino.Depositar(valorTransferencia)) {
                    Console.WriteLine("Foi transferido R$ {0} da conta de {1} para {2}.", valorTransferencia, this.Nome, contaDestino.Nome);
                    return true;
                }                
            }
            return false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo + " | ";
            retorno += "Crédito: " + this.Credito ;
            return retorno;
        }
    }
}
