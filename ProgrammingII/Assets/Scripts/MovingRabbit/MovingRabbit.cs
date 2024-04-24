using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRabbit : MonoBehaviour
{
    [SerializeField] Vector3 targetPosition;
    [SerializeField] Vector3 backPosition;
    [SerializeField] float moveDuration = 1f;
    [SerializeField] bool isMoving = true;

    void Start()
    {
        if (targetPosition == null)
            targetPosition = new Vector3(712.3f, 0f, 280.69f);
        if (backPosition == null)
            backPosition = transform.position;
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
        iTween.MoveTo(gameObject,
            iTween.Hash(
                "position", targetPosition, 
                "time", moveDuration,
                "easetype", iTween.EaseType.linear,
                "oncomplete","OnMoveComplete"
                )); 
        isMoving = false;  
    }

    void OnMoveComplete()
    {
        Debug.Log("Movimento completado.");
        iTween.MoveTo(gameObject,
            iTween.Hash(
                "position", backPosition,
                "time", moveDuration,
                "easetype", iTween.EaseType.linear
            ));
    }
}
