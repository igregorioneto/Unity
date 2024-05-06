using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescricaoObjeto : MonoBehaviour
{
    // Variáveis
    public string descricao;

    // Métodos

    // Métodos Internos da Unity
    private void OnMouseDown()
    {
        Debug.Log("Eu sou: " + descricao);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Eu sou: " + descricao + " e alguém colidiu em mim");
    }
}
