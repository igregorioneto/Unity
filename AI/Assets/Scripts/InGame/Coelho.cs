using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Coelho : MonoBehaviour
{
    // Variáveis
    public float pontos = 10f;
    public AudioClip somCaptura;
    public GameObject particulaCaptura;

    private Animation coelhoAnimation;
    private bool estaMovendo;
    private Vector3 destino;
    private GameObject jogador;
    private NavMeshAgent navAgent;

    // Métodos
    public void Correr()
    {
        coelhoAnimation.CrossFade("Armature|Running", 1f);
        estaMovendo = true;
        destino = new Vector3
            (
                Random.Range(650f, 720f),
                0f,
                Random.Range(240f, 310f)
            );
        navAgent.SetDestination(destino);
    }
    public void Parar()
    {
        coelhoAnimation.CrossFade("Armature|Sitting.000", 1f);
        estaMovendo = false;
        navAgent.isStopped = true;
    }

    // Métodos Internos da Unity
    private void Start()
    {
        coelhoAnimation = GetComponent<Animation>();
        jogador = FindObjectOfType<Player>().gameObject;
        navAgent = GetComponent<NavMeshAgent>();

        if (Random.Range(0f, 100f) < 40)
            Parar();
        else
            Correr();
    }
    private void Update()
    {
        if (!estaMovendo)
            return;
        else if (Vector3.Distance(destino, transform.position) < 0.5f)
            Parar();
    }
    private void OnMouseDown()
    {
        if (Vector3.Distance(jogador.transform.position, transform.position) > 2f)
            return;
        if (somCaptura != null)
            AudioSource.PlayClipAtPoint(somCaptura, transform.position, 1f);
        if (particulaCaptura != null)
            Instantiate(particulaCaptura, transform.position, Quaternion.identity);
        FindObjectOfType<GameManager>().PlayerGanhouPontos(pontos);
        Destroy(this.gameObject);
    }
}
