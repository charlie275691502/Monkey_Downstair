using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyController : MonoBehaviour {
	public float init_speed;
	[HideInInspector] public float add_speed;
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
			GetComponent<Animator> ().SetFloat ("play_Speed", dir);
			GetComponent<Rigidbody2D> ().velocity = new Vector2(Find_Velocity(), GetComponent<Rigidbody2D> ().velocity.y);
			if (first) {
				GetComponent<Animator> ().SetTrigger ("start_Rolling");
				first = !first;
				gameController.camera.GetComponent<Camera_down> ().camera_down = true;
			}
		}
	}

	float Find_Velocity(){
		return init_speed * dir + add_speed;
	}
}
