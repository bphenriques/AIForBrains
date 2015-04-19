using UnityEngine;
using System.Collections;

public class AmmoHandler : MonoBehaviour
{
	HumanShooting playerShotting;

	void Awake(){
		playerShotting = this.transform.FindChild("GunBarrelEnd").GetComponent<HumanShooting> ();
	}

	void OnCollisionEnter (Collision other){
		
		Ammo ammo = other.collider.GetComponent<Ammo> ();
		
		if (ammo != null) {
			playerShotting.currentAmmo += ammo.GrabAmmo ();
		}
	}
}

