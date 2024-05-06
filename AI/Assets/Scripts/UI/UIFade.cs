using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
    // Variáveis
    public float tempo = 0.5f;
    protected Image[] images;
    protected Text[] texts;
    protected float[] imagesAlpha, textsAlpha;

    // Métodos
    public void Ativar()
    {
        // Habilitar todos os componentes (Images e Texts)
        HabilitarComponentes(true);

        // Realizar o Fade
        iTween.ValueTo(this.gameObject,
            iTween.Hash
            (
                "from", 0f,
                "to", 1f,
                "time", tempo,
                "easetype", iTween.EaseType.linear,
                "onupdatetarget", this.gameObject,
                "onupdate", "AtualizarValores",
                "ignoretimescale", true
            ));
    }
    public void Desativar()
    {
        // Remover o Fade
        iTween.ValueTo(this.gameObject,
            iTween.Hash
            (
                "from", 1f,
                "to", 0f,
                "time", tempo,
                "easetype", iTween.EaseType.linear,
                "onupdatetarget", this.gameObject,
                "onupdate", "AtualizarValores",
                "ignoretimescale", true,
                "oncompletetarget", this.gameObject,
                "oncomplete", "HabilitarComponentes",
                "oncompleteparams", false
            ));
    }
    private void HabilitarComponentes(bool habilitar)
    {
        for (int i = 0; i < images.Length; i++)
            images[i].enabled = habilitar;
        for (int i = 0; i < texts.Length; i++)
            texts[i].enabled = habilitar;
    }
    private void AtualizarValores(float value)
    {
        for (int i = 0; i < images.Length; i++)
            images[i].color = new Color
                (
                    images[i].color.r,
                    images[i].color.g,
                    images[i].color.b,
                    imagesAlpha[i] * value
                );
        for (int i = 0; i < texts.Length; i++)
            texts[i].color = new Color(texts[i].color.r, texts[i].color.g, texts[i].color.b, textsAlpha[i] * value);
    }

    // Métodos Internos da Unity
    protected void Awake()
    {
        images = gameObject.GetComponentsInChildren<Image>();
        imagesAlpha = new float[images.Length];
        for (int i = 0; i < images.Length; i++)
            imagesAlpha[i] = images[i].color.a;

        texts = gameObject.GetComponentsInChildren<Text>();
        textsAlpha = new float[texts.Length];
        for (int i = 0; i < texts.Length; i++)
            textsAlpha[i] = texts[i].color.a;
    }
}
