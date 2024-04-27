using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
    [SerializeField] float tempo = 0.5f;
    Image[] images;
    Text[] texts;
    float[] imageAlpha, textAlpha;

    public void Ativar()
    {
        // Habilita todos os componentes
        HabilitarComponentes(true);
        // Realiza o Fade
        iTween.ValueTo(this.gameObject, iTween.Hash(
            "from", 0f,
            "to", 1f,
            "time", tempo,
            "easetype", iTween.EaseType.linear,
            "onupdate", "AtualizarValores",
            "ignoretimescale", true
        ));
    }

    public void Desativar()
    {
        // Remove o Fade
        iTween.ValueTo(this.gameObject, iTween.Hash(
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
            images[i].color = new Color(
                images[i].color.r,
                images[i].color.g,
                images[i].color.b,
                imageAlpha[i] * value
            );

        for (int i = 0; i < texts.Length; i++)
            texts[i].color = new Color(
                texts[i].color.r,
                texts[i].color.g,
                texts[i].color.b,
                textAlpha[i] * value
            );
    }

    private void Awake() {
        images = gameObject.GetComponentsInChildren<Image>();
        imageAlpha = new float[images.Length];
        for (int i = 0; i < images.Length; i++)
            imageAlpha[i] = images[i].color.a;

        texts = gameObject.GetComponentsInChildren<Text>();
        textAlpha = new float[texts.Length];
        for (int i = 0; i < texts.Length; i++)
            textAlpha[i] = texts[i].color.a;   
    }
}
