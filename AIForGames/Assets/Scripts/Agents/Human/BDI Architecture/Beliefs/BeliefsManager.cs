using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BeliefsManager
{

    /* List of possible beliefs */
    private HungerBelief foodLevelBelief = new HungerBelief();
    private InventoryBelief inventoryBelief = new InventoryBelief();
    private VitalsBelief healthLevelBelief = new VitalsBelief();
    private SightBelief sightBelief = new SightBelief();
    private NavigationBelief navigationBelief = new NavigationBelief();
	private SocialBelief socialBelief = new SocialBelief();

    private Belief[] beliefs;



    public BeliefsManager()
    {
        beliefs = new Belief[] { foodLevelBelief, inventoryBelief, healthLevelBelief, sightBelief, navigationBelief, socialBelief };
    }


	public BeliefsManager BeliefReviewFunction(Human human) 
	{
        foreach (Belief belief in beliefs)
        {
            belief.ReviewBelief(this, human);
        }
        return this;
	}

    public HungerBelief GetHungerBelief()
    {
        return foodLevelBelief;
    }

    public InventoryBelief GetInventoryBelief()
    {
        return inventoryBelief;
    }

    public VitalsBelief GetVitalsBelief()
    {
        return healthLevelBelief;
    }

    public SightBelief GetSightBelief()
    {
        return sightBelief;
    }

    public NavigationBelief GetNavigationBelief()
    {
        return navigationBelief;
    }

	public SocialBelief GetSocialBelief()
	{
		return socialBelief;
	}
}

