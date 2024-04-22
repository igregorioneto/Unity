using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Animal
{
    public Cat(string name, int velocity, string color) : base(name, velocity, color)
    {
    }

    public override string Sound() => "Miau!";
}
