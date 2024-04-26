using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] ParticleSystem fireParticle;
    private bool playerInRange = false;

    private void StopEmission()
    {
        var emission = fireParticle.emission;
        emission.enabled = false;
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entrou do alcance do Fogo.");
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player saiu do alcance do Fogo.");
            playerInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Apagando o fogo!");
            StopEmission();
        }
    }
}
