using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Study.oop
{
    internal class Interacao
    {
        private string _MensagemInteracao;
        public String Mensagem
        {
            get { return _MensagemInteracao; }
            set { _MensagemInteracao = value; }
        }

        public void SolicitarDigitacao()
        {
            _MensagemInteracao = ReadLine();
        }

        public void MostrarDigitacao()
        {
            WriteLine(_MensagemInteracao);
        }
    }
}
