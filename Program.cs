using System;
using System.Collections.Generic;

namespace ProjetoDio
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            
           Conta minhaConta = new Conta(TipoConta.PessoaFisica,0,0,"Bruno amoedo");
        // Console.WriteLine(minhaConta.ToString());
           string opcaoUsuario = ObterOpcaoUsuario(); 
           while (opcaoUsuario.ToUpper()!="X"){
               switch(opcaoUsuario)
               {
                case "1":
                    InserirConta();
                    break;                
                case "2":
                    ListarContas();
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
                    break;
                default:
                throw new ArgumentOutOfRangeException();    
               }
            opcaoUsuario = ObterOpcaoUsuario();
           }
           Console.WriteLine("Obrigado por utilizar nosso serviços!!");
           Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o numero da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o numero da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor que deseja transferir ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor que deseja Depositar ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor que deseja sacar ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            if (listaContas.Count == 0)
            {
                Console.Write("Nenhuma conta cadastrada");
                return;
            }
            for(int i = 0;i<listaContas.Count;i++){
                Conta conta = listaContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Digite 1 para conta fisica ou 2 para juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o Saldo inicial ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o credito ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta:(TipoConta)entradaTipoConta,
            saldo:entradaSaldo,
            credito:entradaCredito,
            nome:entradaNome);

            listaContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor !!!");
            Console.WriteLine("Informe a opção Desejada: ");

            Console.WriteLine("1- Inserir nova conta");
            Console.WriteLine("2- Listar contas");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("c-Limpar tela");
            Console.WriteLine("X-Sair");
            Console.WriteLine();

            string ObterOpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return ObterOpcaoUsuario;
        }

    }
}
