using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Base
{
    public Player(string name, int life, int attack, int defense) : base(name, life, attack, defense)
    {
    }

    public override void BaseAttack()
    {
        Debug.Log("Attack");
    }

    public override void BaseDefense()
    {
        Debug.Log("Defense");
    }

    public override void BaseDamage(int damage)
    {
        this.BaseDamage(damage);
    }
}
