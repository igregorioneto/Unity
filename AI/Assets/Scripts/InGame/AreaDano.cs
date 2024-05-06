using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDano : MonoBehaviour
{
    // Variáveis
    public float dano;
    public AudioClip somDano;
    private float horaQueEntrou;

    // Métodos
    private void TomarDano()
    {
        horaQueEntrou = Time.time;
        FindObjectOfType<GameManager>().PlayerPerdeuVida(dano);
        if (somDano != null)
            AudioSource.PlayClipAtPoint(somDano, transform.position, 1f);
    }

    // Métodos Internos da Unity
    private void OnTriggerEnter(Collider other)
    {
        // Jogador toma dano ao entrar na área!
        if (other.gameObject.tag == "Player")
            TomarDano();
    }
    private void OnTriggerStay(Collider other)
    {
        // Se o jogador continuar nesta área, a cada 1 segundo tomará dano novamente!
        if (other.gameObject.tag == "Player" && (Time.time - horaQueEntrou) > 1f)
            TomarDano();
    }
}
