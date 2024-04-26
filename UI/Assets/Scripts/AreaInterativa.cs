using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaInterativa : MonoBehaviour
{
    // Variáveis
    public string[] possiveisMensagens;
    public AudioClip somInterativo;

    // Métodos

    // Métodos Internos da Unity
    private void OnTriggerEnter(Collider other)
    {
        // Verificação se quem entrou na área interativa é de fato o jogador!
        if(other.gameObject.tag == "Player")
        {
            if (somInterativo != null)
                AudioSource.PlayClipAtPoint(somInterativo, gameObject.transform.position, 1f);
            int mensagemEscolhida = Random.Range(0, possiveisMensagens.Length);
            Debug.Log("Mensagem: " + possiveisMensagens[mensagemEscolhida]);
        }
    }
}
