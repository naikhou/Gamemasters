using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	
	private Vector2 velocity;

	public float smoothTimeY;
	public float smoothTimeX;

	public GameObject player;
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {
		
		float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
		//smooths x-axis movement
		float posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY); 
		//smooths y-axis movement
		transform.position = new Vector3 (posX, posY, transform.position.z); 
		// Doesn't affact z-axis
	}
}
