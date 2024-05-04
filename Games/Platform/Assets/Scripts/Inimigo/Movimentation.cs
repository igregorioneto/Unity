using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentation : MonoBehaviour
{
    [SerializeField] float speed;
    private bool left;
    private new Rigidbody2D rigidbody;

    private void Start() {
        left = false;
        rigidbody = GetComponent<Rigidbody2D>();

        if (Random.Range(0f, 100f) < 50f)
        {
            left = true;
            transform.localScale = new Vector3(
                -1 * transform.localScale.x,
                transform.localScale.y,
                transform.localScale.z
            );
        }

        Moviment();
    }

    private void Moviment()
    {
        left = !left;
        transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
        Invoke("Moviment", Random.Range(1f, 4f));
    }

    private void FixedUpdate() {
        Vector2 force;
        if (left)
           force = new Vector2(-1 * speed, 0);
        else
           force = new Vector2(speed, 0);
        rigidbody.AddForce(force);
    }


}
