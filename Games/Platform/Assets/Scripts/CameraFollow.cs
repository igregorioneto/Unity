using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFallow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed;
    [SerializeField] Vector3 offset;

    void Update()
    {
        float posX = Mathf.Lerp(transform.position.x, player.position.x, speed);
        Vector3 posFinal = new Vector3(posX + offset.x, transform.position.y, transform.position.z);
        transform.position = posFinal;
    }
}
