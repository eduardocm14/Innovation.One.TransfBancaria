using ConsoleAppTransferenciaBancaria.Classes;
using ConsoleAppTransferenciaBancaria.Enum;
using System;
using System.Collections.Generic;

namespace ConsoleAppTransferenciaBancaria
{
    class Program
    {
		static readonly List<Conta> listContas = new();
		static string opcaoUsuario = string.Empty;

		static void Main(string[] args)
        {
			opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
                if (opcaoUsuario.ToUpper() == string.Empty)
                {
					opcaoUsuario = ObterOpcaoUsuario();
				}

				switch (opcaoUsuario)
				{
					case "1":
						ListarContas();
						break;
					case "2":
						InserirConta();
						break;
					case "3":
						Transferir();
						break;
					case "4":
						Sacar();
						break;
					case "5":
						Depositar();
						break;
					case "C":
						Console.Clear();
						ReiniciarMenu();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}				
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

		private static void ReiniciarMenu()
		{			
			opcaoUsuario = string.Empty;
			opcaoUsuario = ObterOpcaoUsuario();
		}

		private static void Depositar()
		{
			Console.WriteLine("******   Dados Depósito      ************");

			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser depositado: ");
			double valorDeposito = double.Parse(Console.ReadLine());

			listContas[indiceConta].Depositar(valorDeposito);

			ReiniciarMenu();
		}

		private static void Sacar()
		{
			Console.WriteLine("******   Dados Saque         ************");			

			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser sacado: ");
			double valorSaque = double.Parse(Console.ReadLine());

            if (! listContas[indiceConta].Sacar(valorSaque)) 
			{
				Console.WriteLine("******   Saldo insuficiente  ************");				
			}

			ReiniciarMenu();
		}

		private static void Transferir()
		{
			Console.WriteLine("******   Dados transferências  ************");

			Console.Write("Digite o número da conta de origem: ");
			int indiceContaOrigem = int.Parse(Console.ReadLine());

			Console.Write("Digite o número da conta de destino: ");
			int indiceContaDestino = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser transferido: ");
			double valorTransferencia = double.Parse(Console.ReadLine());

			listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);

			ReiniciarMenu();
		}

		private static void InserirConta()
		{
			int op;

			do
            {
                Console.WriteLine("Inserir nova conta");

                Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
                int entradaTipoConta = int.Parse(Console.ReadLine());

                Console.Write("Digite o Nome do Cliente: ");
                string entradaNome = Console.ReadLine();

                Console.Write("Digite o saldo inicial: ");
                double entradaSaldo = double.Parse(Console.ReadLine());

				Console.Write("Digite o crédito inicial: ");
				double entradaCredito = double.Parse(Console.ReadLine());

				Conta novaConta = new(tipoConta: (TipoConta)entradaTipoConta,
                                      saldo: entradaSaldo,
                                      credito: entradaCredito,
                                      nome: entradaNome);
                listContas.Add(novaConta);

                //Console.Write("Digite o crédito: ");
                //double entradaCredito = double.Parse(Console.ReadLine());

                //Conta novaConta1 = new(tipoConta: (TipoConta)1,
                //					  saldo: 100,
                //					  credito: 110,
                //					  nome: "Conta1");
                //listContas.Add(novaConta1);

                //Conta novaConta2 = new(tipoConta: (TipoConta)2,
                //					  saldo: 200,
                //					  credito: 220,
                //					  nome: "Conta2");
                //listContas.Add(novaConta2);

                //Conta novaConta3 = new(tipoConta: (TipoConta)1,
                //					  saldo: 300,
                //					  credito: 330,
                //					  nome: "Conta3");
                //listContas.Add(novaConta3);

                try
				{
					Console.WriteLine("Incluir nova conta (1-sim 2-nao)");
					op = int.Parse(Console.ReadLine());
				}
                catch (Exception)
                {
					Console.WriteLine("Opção inválida!");
					throw;
                }
				
				while (op < 1 || op > 2)
				{
					Console.WriteLine("Incluir nova conta (1-sim 2-nao)");
					op = int.Parse(Console.ReadLine());
				}

			} while (op == 1);

			ReiniciarMenu();
		}

		private static void ListarContas()
		{
			Console.Clear();
			Console.WriteLine("******   Relatório de Contas   ************");			

			if (listContas.Count == 0)
			{
				Console.WriteLine("Nenhuma conta cadastrada.");
				opcaoUsuario = string.Empty;
				return;
			}
            else
            {
				for (int i = 0; i < listContas.Count; i++)
				{
					Conta conta = listContas[i];
					Console.Write("#{0} - ", i);
					Console.WriteLine(conta);
				}

				Console.WriteLine("*******************************************");
				
				ReiniciarMenu();
			}			
		}
		private static string ObterOpcaoUsuario() 
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("****** Selecione a operação bancária ******");
            Console.WriteLine("****** Informe a opção desejada: **********");
            Console.WriteLine("*******************************************");
            Console.WriteLine("******  1 - Listar Contas        **********");
            Console.WriteLine("******  2 - Inserir nova conta   **********");
            Console.WriteLine("******  3 - Transferir           **********");
            Console.WriteLine("******  4 - Sacar                **********");
            Console.WriteLine("******  5 - Depositar            **********");
            Console.WriteLine("******  C - Limpar Tela          **********");
            Console.WriteLine("******  X - Sair do Sistema      **********");
            Console.WriteLine("*******************************************");
            Console.WriteLine();

            return Console.ReadLine().ToUpper();
        }
    }
}
