using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRabbit : MonoBehaviour
{
    [SerializeField] Vector3 targetPosition;
    [SerializeField] float moveDuration = 1f;
    [SerializeField] bool isMoving = true;

    void Start()
    {
        targetPosition = new Vector3(712.3f, 0f, 280.69f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            MoveToTarget();
        }
    }

    void MoveToTarget()
    {
        Debug.Log("MoveToTarget chamado.");
        isMoving = true;
        iTween.MoveTo(gameObject,
            iTween.Hash(
                "position", targetPosition, 
                "time", moveDuration,
                "easetype", iTween.EaseType.linear,
                "oncomplete",
                "OnMoveComplete"
                ));
    }

    void OnMoveComplete()
    {
        Debug.Log("Movimento completado.");
        isMoving = false;
    }
}
