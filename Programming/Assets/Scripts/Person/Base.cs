using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base
{
    public string Name { get; private set; }
    public int Life { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }

    public Base(string name, int life, int attack, int defense)
    {
        Name = name;
        Life = life;
        Attack = attack;
        Defense = defense;
    }

    public virtual void BaseAttack() {}
    public virtual void BaseDefense() {}
    public virtual void BaseDamage(int damage) {
        Life -= damage;
    }
}
