using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bound : MonoBehaviour {
	public  GameController gameController;

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Monkey") {
			Debug.Log ("Loss");
			gameController.camera.GetComponent<Camera_down> ().camera_down = false;
			Destroy(coll.gameObject);
		}
	}
}
