﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public bool gameOver;

	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}
	// Use this for initialization
	void Start () {
		gameOver = false;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame(){
		UiManager.instance.GameStart ();
		ScoreManager.instance.StartScore ();
	}

	public void StopGame(){
		UiManager.instance.GameEnd ();
		ScoreManager.instance.stopScore ();
	}
}
