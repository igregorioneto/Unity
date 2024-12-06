using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Globalization;

namespace Study.funcoes
{
    internal class funcaoData
    {
        public static void Run()
        {
            int dia = 12;
            int mes = 05;
            int ano = 2024;

            DateTime dtAniversario = new DateTime(ano, mes, dia);
            DateTime dtFesta = new DateTime(2024, 12, 25);

            WriteLine("“------ Funções de Datas -------");
            WriteLine($"Aniversário: {dtAniversario}");
            WriteLine($"Aniversário: {dtAniversario:dd/MM/yyyy}");
            WriteLine($"Aniversário: {dtAniversario:dddd/MMM/yyyy}");
            WriteLine($"Aniversário: {dtAniversario:dddd dd/MMMM/yyyy}");

            DateTime hoje = DateTime.Today;
            WriteLine("TODAY - retorna a data atual");
            WriteLine($"TODAY: {hoje:dd/MM/yyyy}");

            DateTime DataHora = DateTime.Now;
            WriteLine("NOW - retorna a data e a hora atual");
            WriteLine($"Data e Hora: {DataHora:dd/MM/yyyy hh:mm:ss}");

            WriteLine("DAY / MONTH / YEAR - capturar o dia , mês e ano separadamente");
            WriteLine($"Dia: {DataHora.Day}");
            WriteLine($"Dia: {DataHora.Month}");
            WriteLine($"Dia: {DataHora.Year}");

            DateTime dtPedido = DateTime.Today;
            // adiciona 35 dias
            DateTime dtVencto = dtPedido.AddDays(35);
            // adiciona 2 meses
            DateTime dtPagto = dtVencto.AddMonths(2);
            WriteLine($"Pedido feito em {dtPedido:dd/MMM/yyyy} vence em {dtVencto:dd/MMM/yyyy}");
            WriteLine($"Formatação curta: {dtVencto.ToShortDateString()}");
            // dia da semana
            WriteLine($"Dia da semana: {dtVencto.DayOfWeek}");
            WriteLine($"Dia da semana em português: {dtVencto.ToString("dddd", new CultureInfo("pt-BR"))}");
            WriteLine($"Número do dia da semana: {(int)dtVencto.DayOfWeek}");
            // dia do ano
            WriteLine($"dia do ano: {dtVencto.DayOfYear}");
            // subtrai duas datas
            var qtdeDias = dtPagto.Subtract(dtPedido);
            WriteLine($"Entre o pedido e o pagamento foram {qtdeDias:dd} dias");

            WriteLine("Conversão de Texto para Date");
            string dataTexto = "06/12/2024";
            DateTime dataTextoConvertida;
            if (DateTime.TryParse(dataTexto, out dataTextoConvertida))
                WriteLine("Data com conversão aceita");
            else
                WriteLine("Erro na conversão da data");

            string dataTextoErrada = "15/metade do ano/2021";
            DateTime dataTextoErradaConvertida;
            if (DateTime.TryParse(dataTextoErrada, out dataTextoErradaConvertida))
                WriteLine("Data com conversão aceita");
            else
                WriteLine("Erro na conversão da data");

            var pedido = new Pedido
            { 
                PedidoID = 1,
                DtPedido = DateTime.Today,
                DtPagto = DateTime.Today.AddDays(45),
                Valor = 1500
            };

            WriteLine($"Pedido: {pedido.PedidoID} - " +
                $"{pedido.DtPedido:dd/MMM/yyyy} - " + 
                $"vencto: {pedido.DtVencimento():dd/MMM/yyyy} - " +
                $"dias atraso: {pedido.DiasAtraso().TotalDays} - " +
                $"valor: {pedido.Valor:n2} - " +
                $"multa: {pedido.Multa:n2}");

        }
    }

    public class Pedido
    {
        public int PedidoID { get; set; }
        public DateTime DtPedido { get; set; }
        public DateTime DtVencimento() => DtPedido.AddDays(30);
        public DateTime DtPagto { get; set; }
        public TimeSpan DiasAtraso() => DtPagto.Subtract(DtVencimento());
        public decimal Valor { get; set; }
        public decimal Multa => Valor * 0.10M;
    }
}
