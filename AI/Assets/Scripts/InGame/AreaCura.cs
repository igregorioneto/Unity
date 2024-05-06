using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCura : MonoBehaviour
{
    // Variáveis
    public float valorCura;
    public AudioClip somCura;
    private float horaQueEntrou;

    // Métodos
    private void Curar()
    {
        horaQueEntrou = Time.time;
        if (somCura != null && FindObjectOfType<GameManager>().vidaPersonagem < 100)
            AudioSource.PlayClipAtPoint(somCura, transform.position, 1f);
        FindObjectOfType<GameManager>().PlayerPerdeuVida(-1 * valorCura);
    }

    // Métodos Internos da Unity
    private void OnTriggerEnter(Collider other)
    {
        // Jogador toma dano ao entrar na área!
        if (other.gameObject.tag == "Player")
            Curar();
    }
    private void OnTriggerStay(Collider other)
    {
        // Se o jogador continuar nesta área, a cada 1 segundo tomará dano novamente!
        if (other.gameObject.tag == "Player" && (Time.time - horaQueEntrou) > 1f)
            Curar();
    }
}
