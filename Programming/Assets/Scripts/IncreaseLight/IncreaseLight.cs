using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseLight
{
    public IncreaseLight(float intensity)
    {
        Intensity = intensity;
    }

    public float Intensity { get; private set; }

    public void SetIntensity()
    {
        Intensity++;
    }
}
