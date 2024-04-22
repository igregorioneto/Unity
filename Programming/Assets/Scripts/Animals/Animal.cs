using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal
{
    public Animal(string name, int velocity, string color)
    {
        Name = name;
        Velocity = velocity;
        Color = color;
    }

    public string Name { get; private set; }
    public int Velocity { get; private set; }
    public string Color { get; private set; }

    public virtual string Sound() => "";

    public override string ToString() => $"Name: {Name}, Velocity: {Velocity}, Color: {Color}.";
}
