using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBalao : MonoBehaviour
{
    // Variáveis
    public RectTransform objBalao;
    public Text txtConteudo;

    private GameObject qualObjetoSeguir;
    private bool ativado;

    // Métodos
    public void Ligar(string conteudo, GameObject qualObjetoSeguir)
    {
        txtConteudo.text = conteudo;
        this.qualObjetoSeguir = qualObjetoSeguir;
        objBalao.gameObject.SetActive(true);
        ativado = true;
    }
    public void Desligar()
    {
        objBalao.gameObject.SetActive(false);
        ativado = false;
    }

    // Métodos Internos da Unity
    private void Awake()
    {
        Desligar();
    }
    private void Update()
    {
        if(ativado && qualObjetoSeguir != null)
        {
            Vector3 posicaoMundo = new Vector3
                (
                    qualObjetoSeguir.transform.position.x,
                    qualObjetoSeguir.transform.position.y + 0.3f,
                    qualObjetoSeguir.transform.position.z
                );
            Vector3 posicaoTela = Camera.main.WorldToScreenPoint(posicaoMundo);

            Vector2 posicaoMovimento;
            RectTransformUtility.ScreenPointToLocalPointInRectangle
                (
                    this.transform as RectTransform,
                    posicaoTela,
                    null,
                    out posicaoMovimento
                );
            objBalao.localPosition = new Vector2(posicaoMovimento.x + 15, posicaoMovimento.y + 40);
        }
    }
}
