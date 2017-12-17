using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void Dialog_Delegate(bool option);

public class GameController : MonoBehaviour {
	public Camera camera;
	public bool has_dialog;
	public GameObject dialog_gmo;

	public void Start_Dialog(Dialog_Delegate d, string title, string content, int options_amount){
		if (has_dialog) return;
		has_dialog = true;
		GameObject dialog = Instantiate (dialog_gmo, Vector2.zero, Quaternion.identity, camera.transform);
		dialog.GetComponent<Dialog_manager> ().dialog_Delegate = d;
		dialog.GetComponent<Dialog_manager> ().options_amount = options_amount;
		dialog.transform.Find ("canvas").Find ("Title").GetComponent<Text> ().text = title;
		dialog.transform.Find ("canvas").Find ("Content").GetComponent<Text> ().text = content;
	}
}
