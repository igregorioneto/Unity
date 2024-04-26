using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSeguidora : MonoBehaviour
{
    public Transform alvoASeguir;
    public float tempoOlhar, tempoAnimacao;

    void Update()
    {
        iTween.MoveUpdate
            (
                gameObject,     // Quem é o objeto que irá realizar o método
                iTween.Hash     // Configurações
                (
                    "position", alvoASeguir.position,
                    "looktarget", alvoASeguir.parent,
                    "looktime", tempoOlhar,
                    "time", tempoAnimacao
                )
            );
    }
}
