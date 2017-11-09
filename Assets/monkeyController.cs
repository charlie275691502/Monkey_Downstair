using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monkeyController : MonoBehaviour {
	public float speed;
	[HideInInspector] public int dir;
	[HideInInspector] public bool first;
	public GameController gameController;

	// Use this for initialization
	void Start () {
		first = true;
		dir = -1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			dir = -dir;
			GetComponent<Rigidbody2D> ().velocity = new Vector2(speed * dir, GetComponent<Rigidbody2D> ().velocity.y);
			if (first) {
				first = !first;
				gameController.camera.GetComponent<Camera_down> ().camera_down = true;
			}
		}
	}
}
