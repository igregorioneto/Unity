using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSeguidora : MonoBehaviour
{
    [SerializeField] Transform alvoASeguir;
    [SerializeField] float tempoOlhar, tempoAnimação;

    void Update()
    {
        iTween.MoveUpdate(gameObject, iTween.Hash(
            "position", alvoASeguir.position,
            "looktarget", alvoASeguir.parent,
            "looktime", tempoOlhar,
            "time", tempoAnimação
        ));
    }
}
