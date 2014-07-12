using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {
	public Transform[] spawnPoints;
	public GameObject powerup;

	private float timeLeft = 25f;
	private float timeAddedByPowerup = 2f;
	private float timeIncrement = 0.05f;
	private float spawnDelay = 1f;
	private int powerupsCollected = 0;

	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
		SpawnPowerup();
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if (timeLeft <= 0.0f)
		{
			PlayerPrefs.SetInt ("score", powerupsCollected);
			Application.LoadLevel (2);
		}
	}

	void SpawnPowerup()
	{
		int location = Random.Range(0, spawnPoints.Length);
		float xOffset = Random.Range (-1.5f, 1.5f);
		float zOffset = Random.Range (-1.5f, 1.5f);

		Vector3 pos = spawnPoints[location].position;

		Instantiate (powerup, new Vector3(pos.x + xOffset, pos.y, pos.z + zOffset), Quaternion.identity);

		// call myself again after a delay
		Invoke("SpawnPowerup", spawnDelay);
	}

	public void PowerupsCollected()
	{
		timeLeft += timeAddedByPowerup;
		powerupsCollected++;

		spawnDelay += timeIncrement;
		timeAddedByPowerup += (timeIncrement / 2);

		print (powerupsCollected);
	}

	void OnGUI()
	{
		GUI.Label (new Rect(Screen.width / 2 - 10, Screen.height - 70, 90, 40), "Time Left: " + (int)timeLeft);
		GUI.Label (new Rect(Screen.width / 2 - 10, Screen.height - 50, 90, 40), "Powerups Collected: " + powerupsCollected);
	}
}
