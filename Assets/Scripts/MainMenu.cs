﻿using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public Texture texture;
	private string howToPlay = "Control the player with WASD\nSpacebar jumps\nCollect thropies to extend the time";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
		GUI.Box (new Rect(Screen.width / 2 - 120, Screen.height - 210, 240, 110), "Instructions:");
		GUI.Label (new Rect(Screen.width / 2 - 110, Screen.height - 190, 220, 100), howToPlay);
		if (GUI.Button (new Rect(Screen.width / 2 - 80, Screen.height - 80, 160, 60), "Press to play"))
		{
			Application.LoadLevel (1);
		}

	}
}
