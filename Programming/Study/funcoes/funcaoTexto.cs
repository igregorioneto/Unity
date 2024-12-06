using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Console;

namespace funcoes.livrocsharp
{
    class funcaoTexto
    {
        public static void Run()
        {
            WriteLine("------Funções de Textos--------");
            string empresa = " Microsoft Corporation   ";
            WriteLine("TRIM - retira os espaços em branco antes e após a expressão");
            WriteLine($"Nome sem espaços: { empresa.Trim()}");

            WriteLine("Length - retorna a qtde de caracteres");
            WriteLine($"Tamanho do texto: {empresa.Length}");

            empresa = empresa.Trim();
            WriteLine($"Tamanho do texto após o TRIM: {empresa.Length}");

            WriteLine("ToUpper - Converte todos os caracteres em maiúsculo.");
            WriteLine($"Converter para maiúsculo: {empresa.ToUpper()}");

            WriteLine("ToLower - Converte para minúsculo");
            WriteLine($"Converter para minúsculo: {empresa.ToLower()}");

            // Comparação
            var nomeUpper = "AIRTON SENNA";
            var nomeLower = "airton senna";
            if (nomeUpper == nomeLower)
                WriteLine("1 - Nomes iguais");
            else
                WriteLine("1 - Nomes diferentes");

            if (nomeUpper.ToLower() == nomeLower)
                WriteLine("2 - Nomes iguais");
            else
                WriteLine("2 - Nomes diferentes");

            if (nomeUpper.Equals(nomeLower, StringComparison.OrdinalIgnoreCase))
                WriteLine("3 - Nomes iguais");
            else
                WriteLine("3 - Nomes diferentes");

            WriteLine("Remove - extrai x caracteres a partir da esquerda da expressão");
            WriteLine($"texto esquerdo: { empresa.Remove(9)}");

            WriteLine("Captura apenas o primeiro nome das pessoas");
            string[] nomes = { "Fabricio dos Santos", "José da Silva", "Roberta Brasil" };
            foreach (var n in nomes)
            {
                WriteLine($"{n.Remove(n.IndexOf(" "))}");
            }

            WriteLine("“Replace - troca o conteúdo da expressão");
            WriteLine($"texto atual: {empresa}");
            var novaEmpresa = empresa.Replace("Microsoft", "Google");
            WriteLine($"texto trocado: {novaEmpresa}");

            WriteLine("Split - divide e extrai cada palavra em um array");
            string nivelLivro = "Este livro é básico de C#.";
            string[] blocos = nivelLivro.Split(' ');
            var contador = 1;
            foreach (var exp in blocos)
            {
                WriteLine($"texto {contador++}: {exp}");
            }
            WriteLine($"Qtde de palavras: {blocos.Count()}");

            WriteLine("Substring é usado para extrair parte do texto");
            WriteLine(nivelLivro.Substring(5,14));
            string[] cesta = {"5 Laranjas", "10 Goiabas vermelhas", "5 Pêssegos doces", "5 Bananas"};
            var qtde = 0;
            foreach (var p in cesta)
            {
                qtde += Convert.ToInt32(p.Substring(0, p.IndexOf(" ")));
                WriteLine($"{p.Substring(p.IndexOf(" ") + 1)}");
            }
            WriteLine($"Qtde total: {qtde:n0}");

            WriteLine("IsNullOrEmpty verifica se a string está nula ou vazia");
            string nome = "João";
            string sobrenome = null;
            if (!String.IsNullOrEmpty(nome) && !String.IsNullOrEmpty(sobrenome))
            {
                WriteLine($"Nome completo: {nome} {sobrenome}");
            } else
            {
                WriteLine($"Nome: {nome}");
            }
        }
    }
}
