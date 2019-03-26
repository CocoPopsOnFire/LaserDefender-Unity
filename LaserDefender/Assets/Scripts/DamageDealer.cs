﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {

	[SerializeField] float damage = 100;

	public float GetDamage (){
		return damage;
	}

	public void Hit(){
		Destroy(gameObject);
	}

}
