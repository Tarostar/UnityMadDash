using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	public Texture texture;
	private string gameoverText = "Your final score was: ";

	// Use this for initialization
	void Start () {
		Screen.showCursor = true;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI() {
		GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height), texture);
		GUI.Box(new Rect(Screen.width / 2 - 70, Screen.height - 205, 140, 110), "");
		GUI.Label (new Rect(Screen.width / 2 - 65, Screen.height - 200, 130, 100), gameoverText);
		GUI.Label(new Rect(Screen.width / 2 -10, Screen.height - 180, 20, 20), PlayerPrefs.GetInt("score").ToString());
		if (GUI.Button (new Rect(Screen.width / 2 - 80, Screen.height - 80, 160, 60), "Play Again?"))
		{
			Application.LoadLevel(0);
			PlayerPrefs.DeleteAll();
		}
	}
}
