using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyController : MonoBehaviour {
	public float init_speed;
	[HideInInspector] public float add_speed;
	[HideInInspector] public int dir;
	[HideInInspector] public bool first;
	public GameController gameController;

	public GameObject[] hearts;
	public int max_lifes;
	private int pr_lifes;
	[HideInInspector] public int lifes{
		get{
			return pr_lifes;
		}
		set{
			pr_lifes = value;
			for (int i = 0; i < max_lifes; i++) {
				hearts [i].SetActive (i < value);
			}
		}
	}

	[HideInInspector] public bool immutable;

	// Use this for initialization
	void Start () {
		first = true;
		dir = -1;
		lifes = max_lifes;
		immutable = false;
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
				gameController.camera.GetComponent<Camera_down> ().Next_Stairs ();
			}
		}
	}

	float Find_Velocity(){
		return init_speed * dir + add_speed;
	}

	public void Loss_Heart(int x){
		if (immutable) return;
		lifes -= x;
		if (lifes <= 0) {
			Debug.Log ("Loss");
			gameController.camera.GetComponent<Camera_down> ().camera_down = false;
			Destroy (gameObject.transform.parent.gameObject);
		} else {
			StartCoroutine (Immutable ());
		}
	}

	public IEnumerator Immutable(){
		immutable = true;
		for (int i = 0; i < 3; i++) {
			GetComponent<SpriteRenderer> ().color = new Color (1, 0.7f, 0.7f, 0.5f);
			yield return new WaitForSeconds (0.2f);
			GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);
			yield return new WaitForSeconds (0.2f);
		}
		immutable = false;
	}
}
