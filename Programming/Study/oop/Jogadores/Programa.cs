using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Study.oop.Jogadores
{
    internal class Programa
    {
        public static void Run()
        {
            var jogador1 = new Jogador("Goku", 20, 10);
            var jogador2 = new Jogador("Vegeta", 18, 12);

            WriteLine($"Jogador 1: {jogador1.Nome}");
            WriteLine($"Vida: {jogador1.Vida} | Ataque: {jogador1.Ataque} | Defesa: {jogador1.Defesa}");
            WriteLine($"Jogador 2: {jogador2.Nome}");
            WriteLine($"Vida: {jogador2.Vida} | Ataque: {jogador2.Ataque} | Defesa: {jogador2.Defesa}");

            WriteLine("\nIniciando a batalha...\n");
            int turno = 1;

            while (jogador1.Vida > 0 && jogador2.Vida > 0)
            {
                WriteLine($"Turno {turno}:");
                jogador1.Atacar(jogador2);

                if (jogador2.Vida <= 0)
                {
                    WriteLine($"\n{jogador2.Nome} foi derrotado!");
                    WriteLine($"{jogador1.Nome} é o vencedor!");
                    break;
                }

                jogador2.Atacar(jogador1);

                if (jogador1.Vida <= 0)
                {
                    WriteLine($"\n{jogador1.Nome} foi derrotado!");
                    WriteLine($"{jogador2.Nome} é o vencedor!");
                    break;
                }

                turno++;
                WriteLine();
            }
        }
    }
}
