using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager {

	public static NetworkClient hostClient;

	public void MyStartHost (){
		Debug.Log (Time.timeSinceLevelLoad + " - Host Starting");
		hostClient = StartHost ();
	}

	public override void OnStartHost(){
		Debug.Log (Time.timeSinceLevelLoad + " - Host Started");
		base.OnStartHost ();
	}

	public override void OnStartClient(NetworkClient myClient){
		Debug.Log (Time.timeSinceLevelLoad + " - Client Start Requested");
		base.OnStartClient (myClient);
		InvokeRepeating("WaitingForConnection", 0f, 1f);
	}

	public override void OnClientConnect(NetworkConnection conn){
		CancelInvoke ("WaitingForConnection");
		Debug.Log (Time.timeSinceLevelLoad + " - Client Connected to " + conn.address);
		base.OnClientConnect (conn);
	}

	void WaitingForConnection(){
		Debug.Log (".");
	}
}