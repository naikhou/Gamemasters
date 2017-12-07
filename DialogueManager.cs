using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

	public GameObject dialogueBox;
	public Text text;

	public bool dialogActive;
	private PlayerController player;
	// Use this for initialization
	void Start ()
	{
		player = FindObjectOfType<PlayerController> ();
	}
	/// <summary>
	/// Update this instance.
	/// </summary>
	// Update is called once per frame
	void Update ()
	{
		//When space is pressed and is up, dialogue box will disappear
		if (dialogActive==true && Input.GetKeyUp (KeyCode.X)) {
			dialogueBox.SetActive (false);
			dialogActive=false;
			player.canMove = true;
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None; //removes freeze
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation; //freezes rotation
		}
	}
	/// <summary>
	/// Shows the box.
	/// </summary>
	/// <param name="dialogue">Dialogue.</param>
	public void ShowBox (string dialogue)
	{
		dialogActive = true;
		dialogueBox.SetActive (true);
		text.text = dialogue;
		player.canMove = false;
	}
}
