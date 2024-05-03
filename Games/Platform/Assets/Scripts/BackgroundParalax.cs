using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParalax : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        transform.position = new Vector3(
            transform.position.x - speed * Time.deltaTime * Input.GetAxis("Horizontal"),
            transform.position.y,
            transform.position.z
        );
    }
}
