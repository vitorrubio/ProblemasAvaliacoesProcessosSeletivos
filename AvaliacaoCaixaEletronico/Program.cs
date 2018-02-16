using System;

namespace AvaliacaoCaixaCaixaEletronico
{
    class Program
    {


        static CaixaEletronico caixa;



        static void Main(string[] args)
        {

            int cedula10 = ReadInteger("Digite a quantidade de notas de 10");
            int cedula20 = ReadInteger("Digite a quantidade de notas de 20");
            int cedula50 = ReadInteger("Digite a quantidade de notas de 50");
            int cedula100 = ReadInteger("Digite a quantidade de notas de 100");

            caixa = new CaixaEletronico(cedula10, cedula20, cedula50, cedula100);

            bool exitLoop = false;
            MenuCaixa();
            while (!exitLoop)
            {

                exitLoop = LerOpcaoMenuCaixa(Console.ReadKey(true).Key);
                MenuCaixa();

            }
        }


        static void MenuCaixa()
        {
            Console.Clear();
            Console.WriteLine("D - Depósito");
            Console.WriteLine("S - Saque (QUESTÃO 3)");
            Console.WriteLine("L - Saldo do Caixa Eletrônico (QUESTÃO 2)");
            Console.WriteLine("E - Extrato do Caixa Eletrônico (QUESTÃO 8)");
            Console.WriteLine("ESC - SAIR");
        }


        static int ReadInteger(string msg)
        {
            int result;

            Console.WriteLine(msg);
            while ((!int.TryParse(Console.ReadLine(), out result)) || (result < 0))
            {
                Console.WriteLine(msg);
                if(result < 0)
                    Console.WriteLine("Digite um número inteiro positivo:");
            }

            return result;
        }

        static bool LerOpcaoMenuCaixa(ConsoleKey key)
        {
            switch(key)
            {
                case ConsoleKey.Escape:
                    return true;

                case ConsoleKey.D:                    
                    caixa.RealizarDeposito(ReadInteger("Qual quantia deseja depositar?"));
                    break;

                case ConsoleKey.S:
                    caixa.RealizarSaque(ReadInteger("Qual quantia deseja sacar?"));
                    break;

                case ConsoleKey.L:
                    caixa.ExibirSaldo();
                    break;

                case ConsoleKey.E:
                    caixa.ExibirExtrato();
                    break;

                default:
                    return false;
            }

            Console.WriteLine("Pressione ENTER para continuar.");
            Console.ReadLine();
            return false;
        }

    }
}
