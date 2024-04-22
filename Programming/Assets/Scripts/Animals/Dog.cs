using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Animal
{
    public Dog(string name, int velocity, string color) : base(name, velocity, color)
    {
    }

    public override string Sound() => "Au Au";
}
