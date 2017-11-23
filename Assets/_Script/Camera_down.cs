using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_down : MonoBehaviour {
	[HideInInspector] public bool camera_down;
	public float speed;

	// Use this for initialization
	void Start () {
		camera_down = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (camera_down) {
			transform.position -= new Vector3 (0, speed, 0) * Time.deltaTime;
		}
	}
}
