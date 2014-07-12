using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {
	private GameControl control;

	private float speed = 0.5f;
	private float time = 0f;
	private float distance = 0.01f;
	private float rotateSpeed = 1f;

	// Use this for initialization
	void Start () {
		control = GameObject.Find ("GameControl").GetComponent<GameControl>();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime * speed;
		transform.Translate(0f, Mathf.Sin (Mathf.PI * 2 * time) * distance, 0f);

		transform.Rotate (0f, rotateSpeed, 0f);
	}

	void OnTriggerEnter(Collider other)
	{
		control.PowerupsCollected();
		Destroy (this.gameObject);
	}
}
