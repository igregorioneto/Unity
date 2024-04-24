using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkScript : MonoBehaviour
{

    [SerializeField]
    private string[] messages;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            string message = messages[Random.Range(0, messages.Length)];
            Debug.Log(message);
        }
    }
}
