//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;

public class HumanCatchAmmo : ReactiveBehaviour
{
	HumanState humanState;
	
	void Awake(){
		humanState = transform.root.GetComponent <HumanState> ();
	}
	
	protected override bool IsInSituation ()
	{
		return !humanState.IsGrabbed () && humanState.IsSeeingAmmo ();
	}
	
	protected override void Execute ()
	{
		GameObject gameObject = humanState.ammoSeen;
		
		if (humanState.ammoSeen == null) {
			humanState.sawAmmo = false;
			return;
		}
		
		Vector3 ammoPosition = gameObject.transform.position;
		humanState.ChangeDestination (ammoPosition);
		humanState.Walk ();
	}
}




