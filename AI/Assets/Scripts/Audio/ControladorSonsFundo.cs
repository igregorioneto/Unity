using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSonsFundo : MonoBehaviour
{
    // Variáveis
    AudioSource[] sonsFundo;
    float[] volumesDesejados;

    // Métodos
    private void AutoDestruir()
    {
        iTween.ValueTo  /* Função que permite modificarmos o valor de uma variável no decorrer do tempo */
            (
                this.gameObject,    // Objeto que receberá os valores desta variável
                iTween.Hash         // Configurações do método de mudança de valor
                (
                    "from", 0f,      // Valor inicial da variável
                    "to", 1f,        // Valor final da variável
                    "time", 2f,      // Tempo que leva para fazer a transição de 0f até 1f
                    "easetype", iTween.EaseType.linear,      // Indica que a transição segue uma curva linear

                    "onupdatetarget", this.gameObject,      // Qual objeto receberá o valor modificado
                    "onupdate", "ValorSom",                 // Método que recebe o valor modificado

                    "oncompletetarget", this.gameObject,    // Qual objeto será chamado quando terminar a execução
                    "oncomplete", "DestruirFinal"           // Método que será chamado no final da execução
                )
            );
    }
    private void ValorSom(float value)
    {
        for (int i = 0; i < sonsFundo.Length; i++)
            sonsFundo[i].volume -= value;
    }
    private void DestruirFinal()
    {
        Destroy(this.gameObject);       // Remove de fato (destrói) o objeto!
    }

    private void TocarSons()
    {
        volumesDesejados = new float[sonsFundo.Length];
        for (int i = 0; i < volumesDesejados.Length; i++)
        {
            volumesDesejados[i] = sonsFundo[i].volume;
            sonsFundo[i].volume = 0f;
        }

        iTween.ValueTo(this.gameObject, iTween.Hash("from", 0f, "to", 1f, "time", 2f, "easetype",
            iTween.EaseType.linear, "onupdatetarget", this.gameObject, "onupdate", "ValorVolume"));
    }
    private void ValorVolume(float value)
    {
        for (int i = 0; i < sonsFundo.Length; i++)
            sonsFundo[i].volume = volumesDesejados[i] * value;
    }

    // Métodos Internos da Unity
    private void Awake()
    {
        /* Se existir algum outro objeto com ControladorSonsFundo, eu vou mandar uma mensagem para que eles
         * morram, de forma que apenas a música de fundo da cena atual seja tocada */
        ControladorSonsFundo[] objetosSonsFundo = GameObject.FindObjectsOfType<ControladorSonsFundo>();
        for (int i = 0; i < objetosSonsFundo.Length; i++)
            if (objetosSonsFundo[i] != this) // Só mando destruir os objetos que não sejam eu!!!
                objetosSonsFundo[i].AutoDestruir();

        // Aqui eu já destrui todo mundo
        DontDestroyOnLoad(this.gameObject); // Quando a cena for trocada, o objeto não é destruído!
    }
    private void Start()
    {
        sonsFundo = gameObject.GetComponents<AudioSource>();
        TocarSons();
    }
}
