using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Variáveis
    public AudioClip somBotao;
    private static SoundManager instance;

    // Métodos
    public static void SomBotao()
    {
        AudioSource novoSom = instance.gameObject.AddComponent<AudioSource>();
        novoSom.clip = instance.somBotao;
        novoSom.volume = 1f;
        novoSom.spatialBlend = 0f;
        novoSom.Play();
        Destroy(novoSom, instance.somBotao.length);
    }

    // Métodos Internos da Unity
    private void Awake()
    {
        instance = this;
    }
}
