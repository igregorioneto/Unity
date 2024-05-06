using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuInGame : MonoBehaviour
{
    // Variáveis
    public Text txtTempo, txtPontuacao;

    // Métodos
    public void CongelarTempo(bool congelar)
    {
        if (congelar)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }
    public void AtualizarTempo(float valor)
    {
        txtTempo.text = "Tempo: " + valor.ToString("0") + "s";
    }
    public void AtualizarPontuacao(float valor)
    {
        txtPontuacao.text = "Pontuação: " + valor.ToString("0");
    }
}
