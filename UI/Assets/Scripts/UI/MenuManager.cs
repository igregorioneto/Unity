using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Variables
    public UICanvas canvasAtual;
    private bool podeClicar;

    // Methods
    public void IniciarJogo(string novaCena)
    {
        if (!podeClicar)
           return;
        podeClicar = false;
        GameObject.FindObjectOfType<UILoading>().MudarCena(novaCena);
    }

    public void MudarCanvas(UICanvas novoCanvas)
    {
        if (!podeClicar)
            return;
        podeClicar = false;
        canvasAtual.Desativar();
        novoCanvas.Ligar();

        canvasAtual = novoCanvas;

        // Invoke("FinalizarTroca", novoCanvas.tempo);
        iTween.MoveBy(this.gameObject, iTween.Hash(
            "x", 0,
            "time", novoCanvas.tempo,
            "oncompletetarget", this.gameObject,
            "oncomplete", "FinalizarTroca",
            "ignoretimescale", true
        ));
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
        Debug.Log("Querem sair do jogo!");
        Application.Quit();
    }


    // Methods Unity
    private void Start()
    {
        podeClicar = true;
        UICanvas[] todosCanvas = GameObject.FindObjectsOfType<UICanvas>();
        for (int i = 0; i < todosCanvas.Length; i++)
        {
            todosCanvas[i].Desligar();
        }
        canvasAtual.Ligar();
    }
}
