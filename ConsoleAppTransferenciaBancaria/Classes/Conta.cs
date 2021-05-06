using ConsoleAppTransferenciaBancaria.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTransferenciaBancaria.Classes
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }        

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;            
        }

        public bool Sacar(double valorSaque)
        {
            if (Saldo - valorSaque >= (Credito * -1))
            {
                Saldo -= valorSaque;
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Depositar(double valorDeposito)
        {
            Saldo += valorDeposito;
            return ("Saldo atual da conta de {0} é {1}: ", Nome, Saldo).ToString();            
        }

        public void Transferir(double valorTransferir, Conta contaDestino)
        {            
            if (Sacar(valorTransferir))
            {
                contaDestino.Depositar(valorTransferir);
                Console.WriteLine("Saldo atual da conta de {0} é {1}: ", Nome, Saldo);
            }
            else
            {
                Console.WriteLine("Não foi possível realizar a tranferência");
            }           
        }

        public override string ToString()
        {            
            return "TipoConta: " + TipoConta + " | "  + "Nome: " + Nome + " | " + "Saldo: " + Saldo + " | " + "Crédito: " + Credito + " | ";         
        }
    }
}