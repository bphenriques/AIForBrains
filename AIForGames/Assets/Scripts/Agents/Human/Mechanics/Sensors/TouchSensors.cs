﻿using UnityEngine;
using System.Collections;

public partial class Sensors : MonoBehaviour
{

    public bool IsTouchingFood()
    {
        return touch.foodTouched;
    }
    public bool IsTouchingAmmo()
    {
        return touch.ammoTouched;
    }

	public bool IsTouchingHuman(){
		return touch.humanTouched;
	}

    public GameObject GetTouchingAmmo()
    {
        if (touch.ammoTouched)
            return touch.ammoTouched;
        else
            return null;
    }

    public GameObject GetTouchingFood()
    {
        if (touch.foodTouched)
            return touch.foodTouched;
        else
            return null;
    }

	public GameObject GetTouchingHuman(){
		if (touch.humanTouched) {
			return touch.humanTouched;
		} else
			return null;
	}
}
