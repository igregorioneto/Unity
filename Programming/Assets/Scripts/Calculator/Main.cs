using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField]
    private float num1 = 0;
    [SerializeField]
    private float num2 = 0;    
    void Start()
    {
        Calculator calc = new Calculator(num1, num2);
        Debug.Log($"Sum: {calc.Sum()}");
        Debug.Log($"Sub: {calc.Sub()}");
        Debug.Log($"Mult: {calc.Mult()}");
        Debug.Log($"Div: {calc.Div()}");
    }
}
