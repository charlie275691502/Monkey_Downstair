using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_down : MonoBehaviour {
	[HideInInspector] public bool camera_down;
	public float speed;

	public Sprite[] numbers;
	public SpriteRenderer[] numbers_sr;
	private float pr_deep;
	[HideInInspector] public float deep{
		get{
			return pr_deep;
		}
		set{
			pr_deep = value;
			int tmp = (int)value;
			numbers_sr[0].sprite = numbers[tmp / 1000]; tmp %= 1000;
			numbers_sr[1].sprite = numbers[tmp / 100]; tmp %= 100;
			numbers_sr[2].sprite = numbers[tmp / 10]; tmp %= 10;
			numbers_sr[3].sprite = numbers[tmp / 1]; tmp %= 1;
			speed = 0.7f + deep * 0.1f;
			if (speed >= 4.0f)
				speed = 4.0f;
		}
	}

	public Vector2 random_stairs_distance;
	public Vector2 random_x;
	public GameObject[] stairs;
	public Transform stairs_folder;

	// Use this for initialization
	void Start () {
		camera_down = false;
		deep = 0;
		Generate_Stairs ();
	}
	
	// Update is called once per frame
	void Update () {
		if (camera_down) {
			transform.position -= new Vector3 (0, speed, 0) * Time.deltaTime;
		}
	}

	float d;
	void Generate_Stairs(){
		d = 2.5f;
		while(d > -6.2f) {
			d -= Random.Range (random_stairs_distance.x, random_stairs_distance.y);
			Instantiate (stairs [Random.Range (0, stairs.Length)], new Vector3 (Random.Range (random_x.x, random_x.y), d, 0), Quaternion.identity, stairs_folder);
		}
	}

	public void Next_Stairs(){
		deep += 1;
		d -= Random.Range (random_stairs_distance.x, random_stairs_distance.y);
		Instantiate (stairs [Random.Range (0, stairs.Length)], new Vector3 (Random.Range (random_x.x, random_x.y), d, 0), Quaternion.identity, stairs_folder);
	}
}
