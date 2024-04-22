using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculator
{
    public Calculator(float _num1, float _num2)
    {
        Num1 = _num1;
        Num2 = _num2;
    }

    public float Num1 { get; private set; }
    public float Num2 { get; private set; }

    public float Sum()
    {
        return (Num1 + Num2);
    }

    public float Sub()
    {
        return (Num1 - Num2);
    }

    public float Mult()
    {
        return (Num1 * Num2);
    }

    public float Div()
    {
        return (Num1 / Num2);
    }
}
