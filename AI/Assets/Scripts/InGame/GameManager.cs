using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variáveis
    public float vidaPersonagem = 100f;
    public float tempoMaximo = 300f;
    public float pontuacao = 0;
    public UICanvas canvasFimDeJogo;

    private MenuInGame objMenuInGame;
    private UIVidaPersonagem objVidaPersonagem;
    private bool jogoTerminou;
    private float tempoAtual, tempoInicioJogo;

    // Métodos
    public void PlayerGanhouPontos(float value)
    {
        pontuacao += value;
    }
    public void PlayerPerdeuVida(float value)
    {
        vidaPersonagem -= value;
        if (vidaPersonagem <= 0)
            FimDeJogo();
        else if (vidaPersonagem >= 100f)
            vidaPersonagem = 100f;
    }

    // Métodos Internos da Unity
    private void Start()
    {
        objMenuInGame = GameObject.FindObjectOfType<MenuInGame>();
        objVidaPersonagem = GameObject.FindObjectOfType<UIVidaPersonagem>();
        jogoTerminou = false;
        tempoAtual = tempoMaximo;
        tempoInicioJogo = Time.time;
    }
    private void Update()
    {
        if (jogoTerminou)
            return;

        tempoAtual = tempoMaximo - (Time.time - tempoInicioJogo);
        if (tempoAtual <= 0)
        {
            tempoMaximo = 0f;
            FimDeJogo();
        }
        objMenuInGame.AtualizarTempo(tempoAtual);
        objMenuInGame.AtualizarPontuacao(pontuacao);
        objVidaPersonagem.AtualizarBarraVida(vidaPersonagem / 100f);
    }
    public void FimDeJogo()
    {
        jogoTerminou = true;
        FindObjectOfType<MenuManager>().MudarCanvas(canvasFimDeJogo);
        FindObjectOfType<MenuInGame>().CongelarTempo(true);
    }
}
