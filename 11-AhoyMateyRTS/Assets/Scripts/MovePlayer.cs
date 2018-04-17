using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using USACPI = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager;

public class MovePlayer : NetworkBehaviour {

	public float hSpeed = 3f, vSpeed = 3f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer) {
			return;
		}
		float hMove = USACPI.GetAxis ("Horizontal") * hSpeed;
		float vMove = USACPI.GetAxis ("Vertical") * vSpeed;

		transform.Translate (new Vector3 (hMove, 0f, vMove));
	}
}
