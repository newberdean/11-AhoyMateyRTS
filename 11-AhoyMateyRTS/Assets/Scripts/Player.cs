using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Player : NetworkBehaviour {

	public Material myMaterial;		// Material I see.
	public Material notMyMaterial;	// Everyone else.
	public string myName;			// Name above my head.

	Canvas canvas;
	Text myNameText;
	Camera cam;

	// Use this for initialization
	void Start () {
		canvas = GetComponentInChildren<Canvas> ();
		myNameText = GetComponentInChildren<Text> ();
		myNameText.text = myName;
		Vector2 size = myNameText.GetComponent<RectTransform> ().sizeDelta;
		size.x = myNameText.preferredWidth;
		size.y = myNameText.preferredHeight;
		canvas.GetComponent<RectTransform> ().sizeDelta = size;
	}
	
	// Update is called once per frame
	void Update () {
		if (!cam)
			cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		if (myNameText.text != myName && isLocalPlayer) {
			myNameText.text = myName;
			Vector2 size = myNameText.GetComponent<RectTransform> ().sizeDelta;
			size.x = myNameText.preferredWidth;
			size.y = myNameText.preferredHeight;
			canvas.GetComponent<RectTransform> ().sizeDelta = size;
		}
		canvas.transform.LookAt (cam.transform);
		canvas.transform.RotateAround (canvas.transform.position, canvas.transform.up, 180f);
	}

	public override void OnStartLocalPlayer(){
		transform.GetChild (1).gameObject.SetActive (true);
		GetComponent<MovePlayer> ().enabled = true;
		GetComponent<MeshRenderer> ().material = myMaterial;
		base.OnStartLocalPlayer ();
	}
}
