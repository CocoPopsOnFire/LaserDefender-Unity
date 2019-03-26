﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

	[SerializeField] float scrollSpeed = 0.3f;
	Material background;
	Vector2 offset;

	// Use this for initialization
	void Start () {
		background = GetComponent<Renderer>().material;
		offset = new Vector2(0,scrollSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		background.mainTextureOffset+=offset*Time.deltaTime;
	}
}