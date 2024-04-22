using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMain : MonoBehaviour
{
    private Animal animal;

    [SerializeField]
    private string nameAnimal = "";
    [SerializeField]
    private int velocityAnimal = 0;
    [SerializeField]
    private string colorAnimal = "";
    [SerializeField]
    private bool isDog = false;

    void Start()
    {
        if (!isDog)
        {
            animal = new Cat(nameAnimal, velocityAnimal, colorAnimal);
        } else {
            animal = new Dog(nameAnimal, velocityAnimal, colorAnimal);
        }

        Debug.Log($"Informations: {animal}");
        Debug.Log(animal.Sound());
    }
}
