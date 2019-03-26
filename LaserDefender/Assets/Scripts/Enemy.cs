﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] float health = 100;
	[SerializeField] float shotCounter;
	[SerializeField] float minTimeBetweenShots=0.2f;
	[SerializeField] float maxTimeBetweenShots=1.9f;
	[SerializeField] GameObject laserPrefab;
	[SerializeField] float laserSpeed=10f;
	[SerializeField] GameObject deathVFX;
	[SerializeField] float durationOfVFX = 1f;

	// Use this for initialization
	void Start () {
		shotCounter=UnityEngine.Random.Range(minTimeBetweenShots,maxTimeBetweenShots);
	}

	// Update is called once per frame
	void Update () {
		CountDownAndShoot();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
		if(!damageDealer){
            return;
        }
		ProcessHit(damageDealer);
	}

	private void ProcessHit(DamageDealer damageDealer){
		health -= damageDealer.GetDamage();
		damageDealer.Hit();
		if(health<=0){
			Die();
			Destroy(gameObject);
		}
	}

	private void CountDownAndShoot(){
		shotCounter-= Time.deltaTime;
		if(shotCounter<=0f){
			Fire();
			shotCounter=UnityEngine.Random.Range(minTimeBetweenShots,maxTimeBetweenShots);
		}
	}

	private void Fire()
	{
		GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);
	}

	private void Die(){
			Destroy(gameObject);
			GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
			Destroy(explosion, durationOfVFX);
	}
}
