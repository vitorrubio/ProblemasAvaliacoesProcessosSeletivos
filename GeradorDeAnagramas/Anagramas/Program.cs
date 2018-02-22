using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagramas
{
    class Program
    {
        public static List<string> GetPermutacoes(string palavra, int inicio)
        {
            int tamanho = palavra.Length - inicio;

            if (tamanho < 1) return new List<string>() { };

            if (tamanho == 1) return new List<string>() { palavra.Substring(inicio) };

            if (tamanho == 2)
            {
                List<string> list = new List<string>(2);

                list.Add(palavra.Substring(inicio));
                char[] newWord = palavra.Substring(inicio).ToCharArray();
                char temp = newWord[0];
                newWord[0] = newWord[1];
                newWord[1] = temp;
                list.Add(new string(newWord));
                return list;
            }

            List<string> novaLista = new List<string>();
            foreach (string p in GetPermutacoes(palavra, inicio + 1))
            {
                for (int i = 0; i <= p.Length; i++)
                {
                    string w = p.Insert(i, palavra.Substring(inicio, 1));
                    novaLista.Add(w);
                }
            }

            return novaLista;


        }


        static void Main(string[] args)
        {

            List<string> listaAnagramas = new List<string>();

            string palavra = (args.Length > 0 && !string.IsNullOrWhiteSpace( args[0])) ? args[0] : "amor";

            listaAnagramas = GetPermutacoes(palavra, 0);

            Console.WriteLine("Anagramas possíveis para a palavra {0}:", palavra);
            Console.WriteLine("");

            for (int i = 0; i < listaAnagramas.Count; i++)
            {
                Console.WriteLine((i + 1).ToString() + " - " + listaAnagramas[i]);
            }

            Console.ReadLine();
        }
    }




}
