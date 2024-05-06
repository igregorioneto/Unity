using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFimDeJogo : MonoBehaviour
{
    public Text textoPontuacao;
    public InputField entradaUsuario;
    public Button botaoEnviar;

    public void CarregarPontuacao()
    {
        textoPontuacao.text = "Pontuação: " + (int)FindObjectOfType<GameManager>().pontuacao;
    }
    public void EnviarInformacoes()
    {
        textoPontuacao.text = "Enviando...";
        botaoEnviar.interactable = false;
        string nome = "Anônimo";
        if (entradaUsuario.text != "")
            nome = entradaUsuario.text;
        AcessoBD.AdicionarAoRanking(nome, (int)FindObjectOfType<GameManager>().pontuacao,
            RespostaAdicionar);
        SoundManager.SomBotao();
    }
    private void RespostaAdicionar(bool erro, string mensagem)
    {
        if(erro)
        {
            CarregarPontuacao();
            botaoEnviar.interactable = true;
        }
        else
        {
            textoPontuacao.text = "Dados enviados!";
        }
    }
}