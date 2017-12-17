using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bound : MonoBehaviour {
	public bool break_the_stairs;
	public  GameController gameController;

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Monkey") {
			if(break_the_stairs) coll.gameObject.GetComponent<MonkeyController> ().Loss_Heart (1);
			else coll.gameObject.GetComponent<MonkeyController> ().Loss_Heart (3);
		}
		if (coll.gameObject.tag == "Stairs") {
			if(break_the_stairs) Destroy (coll.gameObject);
			else transform.parent.gameObject.GetComponent<Camera_down>().Next_Stairs ();
		}
	}
}
