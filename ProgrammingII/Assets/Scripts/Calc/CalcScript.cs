using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CalcScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SumAsync());
        Thread thread = new Thread(Sum);
        thread.Start();
    }

    IEnumerator SumAsync()
    {
        Debug.Log($"Coratina: {10 + 10}");
        yield return null;
    }

    void Sum()
    {
        Debug.Log($"Thread: {10 + 10}");
    }
}
