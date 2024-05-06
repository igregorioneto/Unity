using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaInterativa : MonoBehaviour
{
    // Variáveis
    public string[] possiveisMensagens;
    public AudioClip somInterativo;

    // Métodos
    private void DesligarBalao()
    {
        GameObject.FindObjectOfType<UIBalao>().Desligar();
    }

    // Métodos Internos da Unity
    private void OnTriggerEnter(Collider other)
    {
        // Verificação se quem entrou na área interativa é de fato o jogador!
        if(other.gameObject.tag == "Player")
        {
            if (somInterativo != null)
                AudioSource.PlayClipAtPoint(somInterativo, gameObject.transform.position, 1f);
            int mensagemEscolhida = Random.Range(0, possiveisMensagens.Length);

            GameObject.FindObjectOfType<UIBalao>().Ligar
                (
                    possiveisMensagens[mensagemEscolhida],
                    this.gameObject
                );
            Invoke("DesligarBalao", 4f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            DesligarBalao();
        }
    }
}
