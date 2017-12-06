using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {
	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="fin">Fin.</param>
	public void OnTriggerEnter2D(Collider2D fin){
		if (fin.gameObject.tag == "Player") {
			Time.timeScale = 0;
		}
	}
}
