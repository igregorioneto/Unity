using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Study.colecoes
{
    public class ListaGenerica<T>
    {
        public void Adicinar(T item) { }
    }

    public class TestarListaGenerica
    {
        private class ExampleClass() { }
        static void Run()
        {
            ListaGenerica<int> listaGenericaInt = new ListaGenerica<int>();
            listaGenericaInt.Adicinar(1);
            ListaGenerica<string> listaGenericaString = new ListaGenerica<string>();
            listaGenericaString.Adicinar("João");
            ListaGenerica<ExampleClass> listaGenericaObject = new ListaGenerica<ExampleClass>();
            listaGenericaObject.Adicinar(new ExampleClass());
        }
    }
    internal class colecoes
    {
        public static void Run()
        {
            WriteLine("===== Coleções =====");
            int[] insts = new int[2];
            int[] ints2 = new int[] { 1,2 };
            int[] ints3 = { 3, 4 };
            string[] nomes = { "Maria", "João", "Francisco", "Larissa", "Manoela" };
            foreach (var nome in nomes)
            {
                WriteLine(nome);
            }

            WriteLine("----- Listas -----");
            List<int> listNumeros = new List<int>();
            listNumeros.Add(1);
            listNumeros.Add(3);
            listNumeros.Add(5);
            listNumeros.Add(7);
            listNumeros.Add(9);
            foreach (int numero in listNumeros)
            {
                WriteLine(numero);
            }

        }
    }
}
