using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hazards : MonoBehaviour {
	/// <summary>
	/// Start this instance.
	/// </summary>
	// Use this for initialization
	void Start () {
		
	}
	/// <summary>
	/// Update this instance.
	/// </summary>
	// Update is called once per frame
	void Update () {
		
	}
	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="col">Col.</param>
	public void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			

			
				col.gameObject.GetComponent<PlayerController> ().alive = false;
				Time.timeScale = 0;

			}

		}
	}

