using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Study.funcoes
{
    internal class conversaoDados
    {
        public static void Run()
        {
            // boxing - converte um tipo para Object
            WriteLine("----- Boxing");
            int percentual = 10;
            object objPercentual = percentual;
            WriteLine($"percentual: {percentual} - {percentual.GetType()}");
            WriteLine($"objPercentual: {objPercentual} - {objPercentual.GetType()}");
            decimal salario = 12500.50M;
            object objSalario = salario;
            WriteLine($"salario: {salario} - {salario.GetType()}");
            WriteLine($"objSalario: {objSalario} - {objSalario.GetType()}");
            string nome = "Visual C#";
            object objNome = nome;
            WriteLine($"nome: {nome} - {nome.GetType()}");
            WriteLine($"objNome: {objNome} - {objNome.GetType()}");
            DateTime hoje = DateTime.Today;
            object objHoje = hoje;
            WriteLine($"hoje: {hoje} - {hoje.GetType()}");
            WriteLine($"objHoje: {objHoje} - {objHoje.GetType()}");

            // unboxing - converte um objeto para um tipo
            WriteLine("----- Unboxing");
            object objDesconto = 10;
            int desconto = (int) objDesconto;
            WriteLine($"desconto: {desconto} - {desconto.GetType()}");
            WriteLine($"objDesconto: {objDesconto} - {objDesconto.GetType()}");

        }
    }
}
