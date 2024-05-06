using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRanking : MonoBehaviour
{
    public Text textoRanking;

    public void Buscar()
    {
        textoRanking.text = "Carregando...";
        AcessoBD.BuscarRanking(RespostaRanking);
    }
    private void RespostaRanking(bool erro, string mensagem)
    {
        if (!erro)
        {
            mensagem = mensagem.Replace("\t", "      ");
            textoRanking.text = mensagem;
        }
        else
            textoRanking.text = "Erro ao buscar informações do ranking.";
    }
}
