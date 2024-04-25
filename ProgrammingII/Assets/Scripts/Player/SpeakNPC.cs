using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakNPC : MonoBehaviour
{
    private bool playerInRange = false;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entrou no alcance do NPC.");
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player saiu do alcance do NPC.");
            playerInRange = false;
        }
    }


    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Em que posso ajudar?");
        }
    }
}
