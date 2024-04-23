using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : BaseObjects
{
    public List<Food> foods;
    public Recipe(string name) : base(name)
    {
        foods = new List<Food>();
    }

    public override string ToString()
    {
        string item = "";
        foreach (var food in foods)
        {
            item += $"\t{food.Name}\t{food.Amount}";
        }
        return $"\t{Name}: {item}";
    }
}
