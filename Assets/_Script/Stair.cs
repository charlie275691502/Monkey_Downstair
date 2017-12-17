using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StairType{
	Basic,
	Ice,
	Tomato,
	MovingTomato,
	Jump,
	RollLeft,
	RollRight
}

public class Stair : MonoBehaviour {
	public StairType stairType;
	[HideInInspector] public MonkeyController monkeyController;
	private Vector3 init_pos;
	private float swip = 0.5f;
	private float speed = 1.0f;

	void Start(){
		init_pos = transform.position;
		monkeyController = GameObject.Find ("Monkey").transform.Find("Sprite").GetComponent<MonkeyController> ();
	}

	float time = 0.0f;
	void Update(){
		if (stairType == StairType.MovingTomato) {
			time += Time.deltaTime;
			float x = Mathf.Sin (time * speed) * swip;
			transform.position = init_pos + new Vector3 (x, 0, 0);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Monkey") {
			switch (stairType) {
			case StairType.Ice:
				Destroy (gameObject, 0.1f);
				break;
			case StairType.Jump:
				coll.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector3 (0, 250, 0));
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
	
	void OnCollisionStay2D(Collision2D coll) {
		if (coll.gameObject.tag == "Monkey") {
			switch (stairType) {
			case StairType.Tomato:
				monkeyController.Loss_Heart (1);
				break;
			case StairType.MovingTomato:
				monkeyController.Loss_Heart (1);
				break;
			default:
				break;
			}
		}
	}

	void OnCollisionExit2D(Collision2D coll) {
		if (coll.gameObject.tag == "Monkey") {
			switch (stairType) {
			case StairType.RollLeft:
				monkeyController.add_speed = 0;
				break;
			case StairType.RollRight:
				monkeyController.add_speed = 0;
				break;
			default:
				break;
			}
		}
	}
}
