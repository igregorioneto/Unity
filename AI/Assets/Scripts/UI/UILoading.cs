using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UILoading : UIFade
{
    // Variáveis
    public GameObject imagemFundo;
    public GameObject[] objsLoading;
    public Image imgLoadingInterno;
    private string novaCena;

    // Métodos
    public void MudarCena(string novaCena)
    {
        this.novaCena = novaCena;
        Ativar();
        iTween.MoveBy(this.gameObject, iTween.Hash("x", 0, "time", tempo, "oncompletetarget",
            this.gameObject, "oncomplete", "MudarCenaIntermediario", "ignoretimescale", true));
    }
    private void MudarCenaIntermediario()
    {
        // Agora o Fade já terminou, eu posso habilitar a barra de carregamento.
        for (int i = 0; i < objsLoading.Length; i++)
            objsLoading[i].SetActive(true);

        // Dou início ao carregamento assíncrono de uma outra cena!
        StartCoroutine(MudarCenaAsync());
    }
    private IEnumerator MudarCenaAsync()
    {
        AsyncOperation cenaCarregando = SceneManager.LoadSceneAsync(novaCena);
        while(!cenaCarregando.isDone)
        {
            imgLoadingInterno.fillAmount = cenaCarregando.progress;
            yield return null;
        }
    }

    // Métodos Internos da Unity
    private void Awake()
    {
        imagemFundo.SetActive(true);
        base.Awake();
    }
    private void Start()
    {
        /* Se o método Start está executando, é porque a cena já foi carregada e eu preciso agora
         * desativar o "Carregando... e as barras" e também tirar o Fade */

        for (int i = 0; i < objsLoading.Length; i++)
            objsLoading[i].SetActive(false);
        Desativar();
    }
}