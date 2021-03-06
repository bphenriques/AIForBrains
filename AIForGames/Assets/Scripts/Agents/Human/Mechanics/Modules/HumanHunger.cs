using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class HumanHunger : MonoBehaviour
{
		
	public float startingHunger = 80f;
	public float hungerLossSpeed = 1.0f;
	public Slider hungerSlider;
	public Text playerName;
	public Text numberFood;
	
	public float hunger;
	protected Human human;

	protected GameObject player;
	protected HumanHealth hoomanHealth;

	public List<Food> foods = new List<Food>();



	void Awake ()
	{
		human = transform.root.GetComponent <Human> ();
		hoomanHealth = GetComponent <HumanHealth> ();
		hunger = startingHunger;
	}


	void Update()
	{
		if (!hoomanHealth.isHumanDead()){
			if (hunger <= 0){
				playerName.color = Color.green;	
				hoomanHealth.Death();
			}
			else {
				float hungerLoss = (human.Sensors.GetSpeed() / 2) * hungerLossSpeed;
                this.hunger -= hungerLoss * Time.deltaTime;

				//FIXME FIXME FIXME
				if(hungerSlider != null){
					hungerSlider.value = hunger;
				}
			}
		}
	}

	public float GetHungerLevel() {
		return hunger;
	}

	public void AddFood(Food food)
	{
		foods.Add (food);
		numberFood.text = "( " + foods.Count + " )";
	}

	public void EatFood()
	{
		if (!HasFood ())
			return;

		Food largestFood = foods[0];
		foreach (Food food in foods) {
			if(food.foodPoints > largestFood.foodPoints)
				largestFood = food;
		}

		hunger += largestFood.foodPoints;
		foods.Remove (largestFood);
	}

	public bool HasFood(){
		return foods.Count > 0;
	}

	public int GetFoodCarried(){
		return foods.Count;
	}


    public void EatFood(Food foodToBeEaten)
    {
        hunger += foodToBeEaten.Eat();
        foods.Remove(foodToBeEaten);
        numberFood.text = "( " + foods.Count + " )";
    }
}


