using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair : MonoBehaviour {
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Monkey") {
			coll.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (coll.gameObject.GetComponent<Rigidbody2D> ().velocity.x, 0);
		}
	}
}
