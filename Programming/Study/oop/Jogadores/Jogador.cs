using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Study.oop.Jogadores
{
    internal class Jogador
    {
        public string Nome { get; set; }
        public int Vida { get; set; } = 100;
        public int Ataque { get; set; }
        public int Defesa { get; set; }

        public Jogador() { }
        public Jogador(string nome, int ataque, int defesa)
        {
            Nome = nome;
            Ataque = ataque;
            Defesa = defesa;
        }

        public void Atacar(Jogador oponente)
        {
            int dano = Math.Max(1, Ataque - oponente.Defesa);
            oponente.Vida -= dano;
            WriteLine($"{Nome} ataca {oponente.Nome}");
            WriteLine($"Dano causado: {dano}");
            WriteLine($"Vida restante de {oponente.Nome}: {oponente.Vida}");
        }
    }
}
