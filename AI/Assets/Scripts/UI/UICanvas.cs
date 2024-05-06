using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : UIFade
{
    // Métodos
    public void Ligar()
    {
        gameObject.SetActive(true);
        ZerarValoresAlpha();
        Ativar(); // Ativando o Fade
    }
    public void Desligar()
    {
        ZerarValoresAlpha();
        gameObject.SetActive(false);
    }
    public void ZerarValoresAlpha()
    {
        for (int i = 0; i < images.Length; i++)
            images[i].color = new Color(images[i].color.r, images[i].color.g, images[i].color.b, 0f);
        for (int i = 0; i < texts.Length; i++)
            texts[i].color = new Color(texts[i].color.r, texts[i].color.g, texts[i].color.b, 0f);
    }
}
