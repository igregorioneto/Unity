using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Contains("Player"))
        {
            GameManager.Instance.Ganhou();
        }
    }
}
