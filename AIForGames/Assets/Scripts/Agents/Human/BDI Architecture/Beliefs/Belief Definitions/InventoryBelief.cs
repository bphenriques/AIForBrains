﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryBelief : Belief
{

    private float ammoLevel;
    private IList<Food> foods;

    public override void ReviewBelief(BeliefsManager beliefs, Human humanState)
    {
        this.ammoLevel = humanState.Sensors.AmmoLevel();
        this.foods = humanState.Sensors.FoodsCarried();
        CleanEatenFoods();
    }

    public float AmmoLevel()
    {
        return ammoLevel;
    }

    public IList<Food> Foods()
    {
        return foods;
    }

    private void CleanEatenFoods()
    {
        IList<Food> eatenFoods = new List<Food>();
        foreach (Food food in foods)
        {
            eatenFoods.Add(food);
        }

        foreach (Food eatenFood in eatenFoods)
        {
            foods.Remove(eatenFood);
        }
    }
}
