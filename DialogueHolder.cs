using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
	public string dialogue;
	private DialogueManager dMan;
	// Use this for initialization
	void Start ()
	{
		dMan = FindObjectOfType<DialogueManager> ();
	}
	
	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter2D (Collider2D other)
	{
		//shows dialogue when collides with player
		if (other.gameObject.name == "Player") {
			dMan.ShowBox (dialogue);
		}
	}
}
