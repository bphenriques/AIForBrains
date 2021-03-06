using UnityEngine;

public class SenseZombie : ReactiveBehaviour
{
	ZombieState zombieState;
	
	void Awake ()
	{
		zombieState = transform.root.GetComponent <ZombieState> ();
	}

    void Update()
    {
        
    }
	
	
	protected override bool IsInSituation ()
	{
		return zombieState.IsSensingZombie() && !zombieState.DidArrivedAtTargetPosition();
	}
	
	protected override void Execute ()
	{
		zombieState.FollowNearestZombie ();
	}

	
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag == "Enemy")
		{
            if (!other.gameObject.GetComponent<EnemyHealth>().hasDied())
            {
                zombieState.sensingZombie = true;
                zombieState.nearestZombie = other.gameObject;
            }
		}
	}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (!other.gameObject.GetComponent<EnemyHealth>().hasDied())
            {
                zombieState.sensingZombie = true;
                zombieState.nearestZombie = other.gameObject;
            }
        }
    }
	
	void OnTriggerExit (Collider other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			zombieState.sensingZombie = false;
			zombieState.nearestZombie = transform.root.gameObject;
		}
	}
}
