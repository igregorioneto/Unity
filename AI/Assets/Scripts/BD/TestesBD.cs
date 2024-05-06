using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestesBD : MonoBehaviour
{
    public string nome;
    public int pontuacao;

    private void RespostaInsercao(bool erro, string resposta)
    {
        if (erro)
            Debug.Log("Deu erro!!!! " + resposta);
        else
            Debug.Log("Sucesso ao inserir!");
    }
    private void RespostaBusca(bool erro, string resposta)
    {
        if (erro)
            Debug.Log("Deu erro!!!! " + resposta);
        else
            Debug.Log("Sucesso ao buscar: " + resposta);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
            AcessoBD.BuscarRanking(RespostaBusca);
        if (Input.GetKeyDown(KeyCode.P))
            AcessoBD.AdicionarAoRanking(nome, pontuacao, RespostaInsercao);
    }
}
