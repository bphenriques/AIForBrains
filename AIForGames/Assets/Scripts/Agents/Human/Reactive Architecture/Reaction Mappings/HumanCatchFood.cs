using UnityEngine;
using System;

public class HumanCatchFood : ReactiveBehaviour
{
	
	Human humanState;
	
	void Awake(){
		humanState = transform.root.GetComponent <Human> ();
	}
	
	protected override bool IsInSituation ()
	{
		return humanState.IsOnFood ();
	}
	
	protected override void Execute ()
	{

		GameObject foodObject = humanState.foodSeen;
		//Due to non-deterministic environment
		if (foodObject == null) {
			humanState.onFood = false;
			humanState.sawFood = false;
			return;
		}

		Food food = foodObject.GetComponent<Food> ();
		humanState.Actuators.CatchFood (food.catchFood ());

		humanState.onFood = false;
		humanState.sawFood = false;

	}
}
