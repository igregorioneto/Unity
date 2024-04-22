using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    private Light lightComponent;
    private IncreaseLight increaseLight;
    void Start()
    {
        lightComponent = GetComponent<Light>();
        if (lightComponent != null)
        {
            increaseLight = new IncreaseLight(lightComponent.intensity);
        }
        
    }

    void Update()
    {
        if (lightComponent != null)
        {
            increaseLight.SetIntensity();
            lightComponent.intensity = increaseLight.Intensity;
        }
    }
}
