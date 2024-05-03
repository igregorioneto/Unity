using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CaptureCoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Contains("Player"))
        {
            GameManager.Instance.CapturarMoeda();
            Destroy(this.gameObject);
        }
    }
}
