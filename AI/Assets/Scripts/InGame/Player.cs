using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variáveis
    public GameObject macaPrefab, bastaoPrefab;
    public AudioClip somArma, somPasso;

    private Transform maoJogador;
    private GameObject armaJogador;

    // Métodos
    public void TocarSomPasso()
    {
        if (PlayerPrefs.GetInt("mudo") == 0)
            AudioSource.PlayClipAtPoint(somPasso, gameObject.transform.position, 0.1f);
    }

    // Métodos Internos da Unity
    void Start()
    {
        Transform[] todasAsTransformsDoJogador = gameObject.GetComponentsInChildren<Transform>();
        for(int i = 0; i < todasAsTransformsDoJogador.Length; i++)
        {
            if(todasAsTransformsDoJogador[i].tag == "Hand")
            {
                maoJogador = todasAsTransformsDoJogador[i];
                break;
            }
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            if (armaJogador != null)
                Destroy(armaJogador);
        }
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (armaJogador != null)
                Destroy(armaJogador);

            // Cria a arma dentro do mundo
            // Posiciona a arma na mão do jogador
            // Posicionar esta arma, como filha da mão do jogador
            armaJogador = Instantiate
                (
                    macaPrefab,             // Indica qual o objeto que será criado
                    maoJogador.position,    // Indica qual a posição deste objeto no mundo
                    maoJogador.rotation,    // Indica qual a rotação inicial do objeto
                    maoJogador              // Transform que será pai deste novo objeto
                );

            if(PlayerPrefs.GetInt("mudo") == 0)
                AudioSource.PlayClipAtPoint(somArma, maoJogador.position, 1f);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (armaJogador != null)
                Destroy(armaJogador);

            armaJogador = Instantiate(bastaoPrefab, maoJogador.position, maoJogador.rotation, maoJogador);
            //AudioSource.PlayClipAtPoint(somArma, maoJogador.position, 1f);

            AudioSource somTemporario = gameObject.AddComponent<AudioSource>();
            somTemporario.clip = somArma;
            somTemporario.volume = 1f;
            somTemporario.spatialBlend = 1f;
            if (PlayerPrefs.GetInt("mudo") == 0)
                somTemporario.Play();
            Destroy(somTemporario, somArma.length);
        }
    }
}
