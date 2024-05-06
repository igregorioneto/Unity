using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AcessoBD : MonoBehaviour
{
    public string urlBusca = "http://localhost/unityprojeto81/buscar.php";
    public string urlAdicionar = "http://localhost/unityprojeto81/adicionar.php";

    private static AcessoBD instance;
    private void Awake()
    {
        instance = this;
    }

    public static void AdicionarAoRanking(string nome, int pontuacao, Action<bool, string> metodoResposta)
    {
        instance.StartCoroutine(instance.AdicionarAoRankingAsync(nome, pontuacao, metodoResposta));
    }
    private IEnumerator AdicionarAoRankingAsync(string nome, int pontuacao, Action<bool, string> metodoResposta)
    {
        WWWForm formularioAdicaoRanking = new WWWForm();
        formularioAdicaoRanking.AddField("nome", nome);
        formularioAdicaoRanking.AddField("pontuacao", pontuacao);

        UnityWebRequest adicionarRanking = UnityWebRequest.Post(urlAdicionar, formularioAdicaoRanking);
        adicionarRanking.downloadHandler = new DownloadHandlerBuffer();
        adicionarRanking.certificateHandler = null;

        // Esperando a resposta
        yield return adicionarRanking.SendWebRequest();

        // Nesta linha, já chegou a resposta
        if (adicionarRanking.error == null) // Significa que não houve erros na UNITY!!!
        {
            string resposta = adicionarRanking.downloadHandler.text;
            if (resposta.Split('|')[0] == "Erro")    // Significa que houve erro no BANCO DE DADOS!!!
                metodoResposta(true, "Erro Banco de Dados: " + resposta.Split('|')[1]);
            else  // Não houve erros em nenhuma parte, nem na Unity e nem no Banco de Dados
                metodoResposta(false, resposta.Split('|')[1]);
        }
        else // Significa que houve erros na Unity!
            metodoResposta(true, "Erro Unity: " + adicionarRanking.error);
    }

    public static void BuscarRanking(Action<bool, string> metodoResposta)
    {
        instance.StartCoroutine(instance.BuscarRankingAsync(metodoResposta));
    }
    private IEnumerator BuscarRankingAsync(Action<bool, string> metodoResposta)
    {
        UnityWebRequest buscaRanking = UnityWebRequest.Get(urlBusca);
        buscaRanking.downloadHandler = new DownloadHandlerBuffer();
        buscaRanking.certificateHandler = null;

        // Esperando a resposta
        yield return buscaRanking.SendWebRequest();

        // Nesta linha, já chegou a resposta
        if (buscaRanking.error == null)
        {
            string resposta = buscaRanking.downloadHandler.text;
            if (resposta.Split('|')[0] == "Erro")
                metodoResposta(true, "Erro Banco de Dados: " + resposta.Split('|')[1]);
            else
                metodoResposta(false, resposta.Split('|')[1]);
        }
        else
            metodoResposta(true, "Erro Unity: " + buscaRanking.error);
    }
}
