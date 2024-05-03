using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] AudioClip somDerrota, somVitoria, somMoeda, somDano;
    [SerializeField] Sprite[] spritesVida;
    [SerializeField] Image[] imagensVida;
    [SerializeField] GameObject telaVitoria, telaDerrota;
    [SerializeField] Text textoPontuacao;

    private int vidas = 9;
    private int pontuacao = 0;
    private bool poderTomarDano = true;

    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        vidas = 9;
        pontuacao = 0;
        textoPontuacao.text = $"{pontuacao}";
        poderTomarDano = true;

        AtualizarImagensVida();

        telaVitoria.SetActive(false);
        telaDerrota.SetActive(false);
    }

    public void CapturarMoeda()
    {
        if (somMoeda != null)
           AudioSource.PlayClipAtPoint(somMoeda, Camera.main.transform.position);
        pontuacao += 1;
        textoPontuacao.text = $"{pontuacao}";
    }

    public void Derrota()
    {
        if (somDerrota != null)
           AudioSource.PlayClipAtPoint(somDerrota, Camera.main.transform.position);
        telaDerrota.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Ganhou()
    {
        if (somVitoria != null)
           AudioSource.PlayClipAtPoint(somVitoria, Camera.main.transform.position);
        telaVitoria.SetActive(true);
        Time.timeScale = 0f;
    }

    public void TomarDano()
    {
        if (!poderTomarDano)
           return;
        poderTomarDano = false;
        Invoke("PoderTomarDano", 1.5f);

        if (somDano != null)
           AudioSource.PlayClipAtPoint(somDano, Camera.main.transform.position);

        vidas--;
        if (vidas > 0)
        {
            AtualizarImagensVida();
        }
        else
        {
            Derrota();
        }
    }

    private void PoderTomarDano()
    {
        poderTomarDano = true;
    }

    private void AtualizarImagensVida()
    {
        if (vidas > 6)
        {
            imagensVida[0].sprite = spritesVida[2];
            imagensVida[1].sprite = spritesVida[2];
            imagensVida[2].sprite = spritesVida[vidas - 7];
        }
        else if (vidas > 3)
        {
            imagensVida[0].sprite = spritesVida[2];
            imagensVida[1].sprite = spritesVida[vidas - 4];
            imagensVida[2].sprite = spritesVida[0];
        }
        else if (vidas > 0)
        {
            imagensVida[0].sprite = spritesVida[vidas - 1];
            imagensVida[1].sprite = spritesVida[0];
            imagensVida[2].sprite = spritesVida[0];
        }
    }
}
