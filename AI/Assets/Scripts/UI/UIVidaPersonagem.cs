using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIVidaPersonagem : MonoBehaviour
{
    // Variáveis
    public Image imgFundo;
    private Player jogador;

    // Métodos
    public void AtualizarBarraVida(float value)
    {
        imgFundo.fillAmount = value;
        if (value < 0.3f)
            imgFundo.color = Color.red;
        else if (value < 0.7f)
            imgFundo.color = Color.yellow;
        else
            imgFundo.color = Color.green;
    }

    // Métodos Internos da Unity
    private void Start()
    {
        jogador = GameObject.FindObjectOfType<Player>();
    }
    private void Update()
    {
        // Ajustando a posição da barra
        gameObject.transform.position = new Vector3
            (
                jogador.transform.position.x,
                jogador.transform.position.y + 1.7f,
                jogador.transform.position.z
            );

        // Ajustando a rotação da barra para seguir a rotação da camera
        gameObject.transform.LookAt
            (
                transform.position + Camera.main.transform.rotation * Vector3.back,
                Camera.main.transform.rotation * Vector3.up
            );
    }
}
