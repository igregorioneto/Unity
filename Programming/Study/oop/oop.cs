using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Study.oop
{
    internal class oop
    {
        public static void Run()
        {
            Interacao interacao = new Interacao();
            interacao.SolicitarDigitacao();
            interacao.MostrarDigitacao();

            var digitado = interacao.Mensagem;
            WriteLine($"Nova digitação sem espaços -> {digitado.ToUpper()}");
        }
    }
}
