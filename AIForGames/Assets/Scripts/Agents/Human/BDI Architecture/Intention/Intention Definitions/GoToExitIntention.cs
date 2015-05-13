using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GoToExitIntention : Intention
{

    private GameObject exit;

    public GoToExitIntention (GameObject exit, float desiredIntention) : base (desiredIntention) {
        this.exit = exit;
    }

    public override bool Succeeded(BeliefsManager beliefs)
    {
		
		//Always returns false because when the human reaches the exit, the human is destroyed
		return false;
	}

    public override bool IsImpossible(BeliefsManager beliefs)
    {

        //TODO
        return false;
		
	}

    public override bool Evaluate(BeliefsManager beliefs, IList<Intention> previousIntentions)
    {
        intentValue = 50f;
        return beliefs.GetSightBelief().SawExit();
    }

    public override IList<PlanComponent> GivePlanComponents(HumanState humanState, BeliefsManager beliefs)
    {
        throw new System.NotImplementedException();
    }
}

