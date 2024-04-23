using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRecipe : MonoBehaviour
{
    void Start()
    {
        Chef chef = new Chef("João");
        Food food = new Food("Cheese", 5);
        Food food1= new Food("Bread", 2);
        Recipe recipe = new Recipe("Bread with Cheese");
        
        chef.Organize(food, recipe);
        chef.Organize(food1, recipe);

        Debug.Log(recipe);
    }
}
