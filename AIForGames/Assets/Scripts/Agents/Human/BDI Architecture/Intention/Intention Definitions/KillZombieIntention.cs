using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KillZombieIntention : Intention
{
	GameObject zombie;

	public KillZombieIntention(GameObject zombie, float desiredIntention) : base (desiredIntention){
		
		this.zombie = zombie;

	}

	

	public override bool Evaluate (BeliefsManager beliefs, IList<Intention> previousIntentions)
	{
		SightBelief humanSight = beliefs.GetSightBelief ();

		InventoryBelief inventory = beliefs.GetInventoryBelief ();
		int nBullets = inventory.AmmoLevel ();
		int wasShootingExtraMotivation = 0;
		
		foreach (Intention i in previousIntentions) {
			if(i.GetType().Equals(typeof(KillZombieIntention))){
				wasShootingExtraMotivation = 10;
				break;
			}
		}

        float killZombieIntentionLevel = nBullets + wasShootingExtraMotivation - humanSight.DistanceToZombie(zombie);
        killZombieIntentionLevel = Mathf.Min(killZombieIntentionLevel, 50f);
		intentValue = killZombieIntentionLevel;


		if (humanSight.ZombieSeen().Contains (zombie) == false) {
			return false;
		}

		return true;

	}
	public override IList<PlanComponent> GivePlanComponents (Human human, BeliefsManager beliefs)
	{
		IList<PlanComponent> plan = new List<PlanComponent> ();

		SightBelief humanSight = beliefs.GetSightBelief ();
		NavigationBelief navBelief = beliefs.GetNavigationBelief ();

	

	    plan.Add (new AimPlanComponent (human, zombie));
		plan.Add(new ZombieShootPlanComponent(human, zombie));

		return plan;

	}
	public override bool Succeeded (BeliefsManager beliefs)
	{
		EnemyHealth eHealth = zombie.GetComponent<EnemyHealth>();
		return eHealth.hasDied ();
	}
	public override bool IsImpossible (BeliefsManager beliefs)
	{
		EnemyHealth eHealth = zombie.GetComponent<EnemyHealth>();
		int nbullets = beliefs.GetInventoryBelief ().AmmoLevel ();

		if (nbullets <= 0 || eHealth.hasDied()) {
			return true;
		}

		return false;
	}

	
}

