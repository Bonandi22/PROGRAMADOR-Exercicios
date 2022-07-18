using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        private static int CalcularSoma()
        {
            int a = 1;
            int b = 2;
            int c = a + b;
            return c;
        }

        public static void MostrarMesagemNaTela()
        {
            Console.WriteLine("Olá pessoal");
        }

        public static void Tabuada(int numero)
        {
            Console.WriteLine("======== Calculo da tabuada do " + numero + "\n==========");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(numero + " X " + i + " = " + (numero * i));
            }
            Console.WriteLine("==================");
        }
        private static void LerArquivos(int numeroArquivo)
        {
            string arquivoComCaminho = @"C:\arquivos\arq" + numeroArquivo + ".txt";
            Console.WriteLine("==== Lendo arquivo ====\n" + arquivoComCaminho + "\n=====");
            if (File.Exists(arquivoComCaminho))
            {
                using (StreamReader arquivo = File.OpenText(arquivoComCaminho))
                {
                    string linha;
                    while ((linha = arquivo.ReadLine()) != null)
                    {
                        Console.WriteLine(linha);
                    }
                }
            }
            string arquivoComCaminho2 = @"C:\arquivos\arq" + (numeroArquivo + 1) + ".txt";
            if (File.Exists(arquivoComCaminho2))
            {
                LerArquivos(numeroArquivo + 1);
            }
        }

        private static void CalcularMediaAluno()
        {
            Console.WriteLine("Digite o nome do aluno");
            string nome = Console.ReadLine();
            int qtdNotas = 3;
            Console.WriteLine("Digite as " + qtdNotas + " notas do aluno " + nome);

            List<int> notas = new List<int>();
            int totalNotas = 0;
            for (int i = 1; i <= qtdNotas; i++)
            {
                Console.WriteLine("Digite a nota numero " + i);
                int nota = int.Parse(Console.ReadLine());
                totalNotas += nota;
                notas.Add(nota);
            }

            int media = totalNotas / notas.Count;
            Console.WriteLine("A média do aluno " + nome + " é: " + media);
            Console.WriteLine("Suas notas são:\n");
            foreach (int nota in notas)
            {
                Console.WriteLine("Nota: " + nota + "\n");
            }
        }
        private static void Menu()
        {
            while (true)
            {
                string mensagem = "Olá usuário, bem vindo ao programa\n" +
                    "\n  Utilizando programação funcional" +
                    "\n\n" +
                    "\n    Digite uma das opções abaixo:" +
                    "\n      0 - Sair do programa" +
                    "\n      1 - Para Ler Arquivos" +
                    "\n      2 - Para executar a tabuada" +
                    "\n      3 - Calcular média de alunos";
                Console.WriteLine(mensagem);

                int valor = int.Parse(Console.ReadLine());
                if (valor == SAIDA_PROGRAMA)
                {
                    break;
                }
                else if (valor == LER_ARQUIVOS)
                {
                    Console.WriteLine("==== Opção Ler Arquivos ====");
                    LerArquivos(1);
                    Console.WriteLine("\n============================\n");
                }
                else if (valor == TABUADA)
                {
                    Console.WriteLine("==== Opção tabuada ====");
                    Console.WriteLine("Digite o número que deseja na tabuada");
                    int numero = int.Parse(Console.ReadLine());
                    Tabuada(numero);
                    Console.WriteLine("\n============================\n");
                }
                else if (valor == CALCULO_MEDIA)
                {
                    CalcularMediaAluno();
                    Console.WriteLine("\n============================\n");
                }
                else
                {
                    Console.WriteLine("Opção inválida, digite novamente");
                }
            }
           
        }

        public const int SAIDA_PROGRAMA = 0;
        public const int LER_ARQUIVOS = 1;
        public const int TABUADA = 2;
        public const int CALCULO_MEDIA = 3;

        static void Main(string[] args)
        {
            Menu();
        }
    }
}