using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StairType{
	Basic,
	Ice,
	Tomato,
	Jump,
	RollLeft,
	RollRight
}

public class Stair : MonoBehaviour {
	public StairType stairType;
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Monkey") {
			switch (stairType) {
			case StairType.Jump:
				coll.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector3 (0, 200, 0));
				GetComponent<Animator> ().Play ("jump");
				break;
			default:
				break;
			}
		}
	}
}
