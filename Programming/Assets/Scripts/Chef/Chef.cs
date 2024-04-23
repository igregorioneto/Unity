using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chef : BaseObjects
{
    public Chef(string name) : base(name)
    {
    }

    public void Organize(Food food, Recipe recipe)
    {
        recipe.foods.Add(food);
    }
}
