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
	[HideInInspector] public MonkeyController monkeyController;

	void Start(){
		monkeyController = GameObject.Find ("Monkey").transform.Find("Sprite").GetComponent<MonkeyController> ();
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Monkey") {
			switch (stairType) {
			case StairType.Ice:
				Destroy (gameObject, 0.1f);
				break;
			case StairType.Tomato:
				Debug.Log ("Loss");
				GameObject.Find ("GameController").GetComponent<GameController> ().camera.GetComponent<Camera_down> ().camera_down = false;
				Destroy (monkeyController.gameObject);
				break;
			case StairType.Jump:
				coll.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector3 (0, 300, 0));
				GetComponent<Animator> ().Play ("jump");
				break;
			case StairType.RollLeft:
				monkeyController.add_speed = -3;
				break;
			case StairType.RollRight:
				monkeyController.add_speed = 3;
				break;
			default:
				break;
			}
		}
	}
}
