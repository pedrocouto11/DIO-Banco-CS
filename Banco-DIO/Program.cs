using System;
using System.Collections.Generic;

namespace Banco_DIO
{
    class Program
    {

        static List<Conta> listaContas = new List<Conta>();

        static void Main(string[] args)
        {
            //Conta minhaConta = new Conta(TipoConta.PessoaFisica, 0, 0, "pedro");
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
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
                        //LimparTela();
                        break;
                    default:
                        Console.WriteLine("Opção Inválida, tente novamente\n");
                        break;
                        //throw new ArgumentOutOfRangeException();

                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços\n\n");
        }

        private static void Transferir()
        {
            ListarContas();
            Console.Write("Digite o número da conta de origem: ");
            int? indiceContaOrigem = interpretarInt(Console.ReadLine());
            if (indiceContaOrigem == null)
            {
                return;
            }
            if (indiceContaOrigem > listaContas.Count)
            {
                Console.WriteLine("Número de conta não existente");
                return;
            }

            Console.Write("Digite o número da conta de destino: ");
            int? indiceContaDestino = interpretarInt(Console.ReadLine());
            if (indiceContaDestino == null)
            {
                return;
            }
            if (indiceContaDestino > listaContas.Count)
            {
                Console.WriteLine("Número de conta não existente");
                return;
            }

            Console.Write("Digite o valor a ser trandferido: ");
            double valorTransferencia = interpretarDouble(Console.ReadLine());

            listaContas[(int)indiceContaOrigem].Transferir(valorTransferencia, listaContas[(int)indiceContaDestino]);


        }

        private static void Depositar()
        {
            ListarContas();
            Console.Write("Digite o número da conta de destino: ");
            int? indiceConta = interpretarInt(Console.ReadLine());
            if (indiceConta == null)
            {
                return;
            }
            if (indiceConta > listaContas.Count)
            {
                Console.WriteLine("Número de conta não existente");
                return;
            }

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = interpretarDouble(Console.ReadLine());

            listaContas[(int)indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            ListarContas();
            Console.Write("Digite o número da conta de origem: ");            
            int? indiceConta = interpretarInt(Console.ReadLine());
            if(indiceConta == null)
            {
                return;
            }
            if(indiceConta > listaContas.Count)
            {
                Console.WriteLine("Número de conta não existente");
                return;
            }

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = interpretarDouble(Console.ReadLine());

            listaContas[(int)indiceConta].Sacar(valorSaque);
        }


        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");

            if(listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }
            for(int i = 0; i<listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write("Conta #{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.Write("Inserir nova conta\n\nDigite 1 para conta Pessoa Fisica ou 2 para conta Pessoa Juridica: ");
            string entrada = Console.ReadLine();
            int entradaTipoConta = 0;
            try
            {
                 entradaTipoConta = int.Parse(entrada);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            entrada = "";
            if(entradaTipoConta != 1 && entradaTipoConta != 2)
            {
                Console.WriteLine("Tipo de conta inválida");
                return;
            }

            Console.Write("Digite o nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            entrada = Console.ReadLine();
            int entradaSaldo = 0;
            try
            {
                entradaSaldo = int.Parse(entrada);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            entrada = "";

            Console.Write("Digite o crédito: ");
            entrada = Console.ReadLine();
            int entradaCredito = 0;
            try
            {
                entradaCredito = int.Parse(entrada);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            entrada = "";

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                saldo: entradaSaldo,
                credito: entradaCredito,
                nome: entradaNome);
            
            listaContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank\nInforme a opção desejada\n\n" +
                "1 - Listar contas\n" +
                "2 - Inserir nova conta\n" +
                "3 - Transferir\n" +
                "4 - Sacar\n" +
                "5 - Depositar\n" +
                "C - Limpar tela\n" +
                "X - Sair\n");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        public static int? interpretarInt(string entrada)
        {
            int? retorno = null;
            try
            {
                retorno = int.Parse(entrada);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            entrada = "";
            return retorno;
        }

        public static double interpretarDouble(string entrada)
        {
            double retorno = 0;
            try
            {
                retorno = double.Parse(entrada);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            entrada = "";
            return retorno;
        }
    }
}
