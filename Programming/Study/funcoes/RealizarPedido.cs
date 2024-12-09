using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Study.funcoes
{
    internal class RealizarPedido
    {
        public static void Run()
        {
            WriteLine("=== Sistemas de Pedido ===");

            // Entrada de dados
            Write("Digite o seu nome completo: ");
            string nomeCompleto = ReadLine() ?? "";
            Write("Digite o valor do pedido: ");
            string valorPedidoTexto = ReadLine() ?? "0";
            Write("Digite a data do pedido: ");
            string dataPedidoTexto = ReadLine() ?? DateTime.Now.ToString("dd/MM/yyyy");

            // Manipulação do nome
            string[] nomePartes = nomeCompleto.Trim().Split(' ');
            string primeiroNome = nomePartes[0].ToUpper();
            string sobrenome = nomePartes.Length > 1 ? nomePartes[^1].ToUpper() : "";

            // Conversão do pedido
            decimal valorPedido = Convert.ToDecimal(valorPedidoTexto, CultureInfo.InvariantCulture);
            decimal valorFinal = valorPedido;
            if (valorPedido > 500)
            {
                valorFinal *= 0.90M; // desconto 10%
            }
            else if (valorPedido < 100)
            {
                valorFinal *= 1.05M; // acrescimo 5%
            }

            // Calculo datas
            DateTime dataPedido = DateTime.ParseExact(dataPedidoTexto, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dataVencimento = dataPedido.AddDays(30);
            int diasParaVencimento = (dataVencimento - DateTime.Today).Days;


            WriteLine("\n--- Resumo do Pedido ---");
            Console.WriteLine($"Nome do Cliente: {primeiroNome} {sobrenome}");
            Console.WriteLine($"Valor Original do Pedido: R$ {valorPedido:n2}");
            Console.WriteLine($"Valor Final (com desconto/acréscimo): R$ {valorFinal:n2}");
            Console.WriteLine($"Data do Pedido: {dataPedido:dd/MM/yyyy}");
            Console.WriteLine($"Data de Vencimento: {dataVencimento:dd/MM/yyyy} ({dataVencimento:dddd})");
            Console.WriteLine($"Dias até o vencimento: {diasParaVencimento} dias");
        }
    }
}
