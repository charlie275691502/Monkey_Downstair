using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public Camera camera;
	public Animator a;

	void Update(){
		if (Input.GetKeyDown (KeyCode.A)) {
			a.Play ("jump");
		}
	}
}
