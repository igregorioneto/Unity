using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Variáveis
    public UICanvas canvasAtual;
    private bool podeClicar;

    // Métodos
    public void IniciarJogo(string novaCena)
    {
        if (!podeClicar)
            return;
        podeClicar = false;

        SoundManager.SomBotao();

        GameObject.FindObjectOfType<UILoading>().MudarCena(novaCena);
    }
    public void MudarCanvas(UICanvas novoCanvas)
    {
        if (!podeClicar)
            return; // Caso não possa clicar, saímos do método nesta linha, sem executar as próximas!
        podeClicar = false;

        canvasAtual.Desativar();
        novoCanvas.Ligar();

        canvasAtual = novoCanvas;

        SoundManager.SomBotao();

        iTween.MoveBy(this.gameObject, iTween.Hash("x", 0, "time", novoCanvas.tempo, "oncompletetarget",
            this.gameObject, "oncomplete", "FinalizarTroca", "ignoretimescale", true));
    }
    private void FinalizarTroca()
    {
        podeClicar = true;
    }
    public void SairJogo()
    {
        if (!podeClicar)
            return;
        podeClicar = false;

        SoundManager.SomBotao();

        Debug.Log("Querem sair do jogo!");

        Application.Quit(); // Finaliza o jogo
    }

    // Métodos Internos da Unity
    private void Start()
    {
        podeClicar = true;

        UICanvas[] todosCanvas = GameObject.FindObjectsOfType<UICanvas>();
        for (int i = 0; i < todosCanvas.Length; i++)
            todosCanvas[i].Desligar();
        canvasAtual.Ligar();
    }
}
