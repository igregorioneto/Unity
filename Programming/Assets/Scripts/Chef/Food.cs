using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : BaseObjects
{
    public int Amount { get; private set; }
    public Food(string name, int amount) : base(name)
    {
        Amount = amount;
    }
}
