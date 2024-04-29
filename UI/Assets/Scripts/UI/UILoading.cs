using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILoading : UIFade
{
    // Variables
    public GameObject imagemFundo;
    public GameObject[] objsLoading;
    public Image imgLoadingInterno;
    private string novaCena;

    // Methods
    public void MudarCena(string novaCena)
    {
        this.novaCena = novaCena;
        Ativar();
        iTween.MoveBy(this.gameObject, iTween.Hash(
            "x", 0,
            "time", tempo,
            "oncompletetarget", this.gameObject,
            "oncomplete", "MudarCenaIntermediario",
            "ignoretimescale", true
        ));
    }

    private void MudarCenaIntermediario()
    {
        for (int i = 0; i < objsLoading.Length; i++)
        {
            objsLoading[i].SetActive(true);
        }
        StartCoroutine(MudarCenaAsync());
    }

    private IEnumerator MudarCenaAsync()
    {
        AsyncOperation cenaCarregando = SceneManager.LoadSceneAsync(novaCena);
        while (!cenaCarregando.isDone)
        {
            imgLoadingInterno.fillAmount = cenaCarregando.progress;
            yield return null;
        }
    }

    // Methods Unity
    private new void Awake()
    {
        imagemFundo.SetActive(true);
        base.Awake();
    }
    private void Start()
    {
        for (int i = 0; i < objsLoading.Length; i++)
        {
            objsLoading[i].SetActive(false);
        }
        Desativar();
    }
}
