using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monkeyController : MonoBehaviour {
	public float speed;
	public int dir;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2(speed, 0);
		dir = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2(speed * dir, 0);
			dir = -dir;
		}
	}
}
