using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	/// <summary>
	/// Returns to the menu.
	/// </summary>
	public void ReturntoMenu ()
	{
		SceneManager.LoadScene ("Menu");
	}
	//creating booleans to separate the pause and win menus
	bool winEnable;
	bool pauseEnable;

	//creating lists for the show and hide function
	GameObject[] pauseObjects;
	GameObject[] winObjects;
	GameObject[] lossObjects;
	PlayerController playerController;
	/// <summary>
	/// Start this instance.
	/// </summary>
	// Use this for initialization
	void Start ()
	{
		Time.timeScale = 1;

		pauseObjects = GameObject.FindGameObjectsWithTag ("Paused");
		winObjects = GameObject.FindGameObjectsWithTag ("Win");
		lossObjects = GameObject.FindGameObjectsWithTag ("Loss");
		winEnable = false;
		pauseEnable = false;

		//hiding the pop up text at start-up
		hidePaused ();
		hideWin ();
		hideLoss ();

		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();

		
	}
	/// <summary>
	/// Update this instance.
	/// </summary>
	// Update is called once per frame
	void Update ()
	{
		//If Escape key is pressed down, time stops and the pause menu will show up
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (Time.timeScale == 1 && playerController.alive == true && winEnable == false) {
				Time.timeScale = 0;
				showPaused ();
			
				//if the pause menu is on and time is stopped the menu will disappear and game will be unpaused
			} else if (Time.timeScale == 0 && playerController.alive && winEnable == false) {
				Time.timeScale = 1;
				hidePaused ();
			}
		}
		//If the player is dead and the game is paused the loss window will open
		if (Time.timeScale == 0 && playerController.alive == false && winEnable == false) {
			showLoss ();
		}
		//if the time is stopped, pausemenu is closed and the player is alive, win window will open
		if (Time.timeScale == 0 && playerController.alive == true && pauseEnable == false) {
			showWin ();
		}	
	}
	/// <summary>
	/// Reload this instance.
	/// </summary>
	// this method simply reloads the game (used for restart button)
	public void Reload ()
	{
		SceneManager.LoadScene ("Alepa");
	}
	/// <summary>
	/// Pauses the control.
	/// </summary>
	//this method controls the pausing of the game
	public void pauseControl ()
	{
		//when the method is used and time is on, the method will pause the game and show the pause menu
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
			showPaused ();
			// if the above is not true and the time is stopped and winWindow is not on the game will be unpaused and the pausemenu will be hidden
		} else if (Time.timeScale == 0 && winEnable == false) {
			Time.timeScale = 1;
			hidePaused ();
		}
	}
	/// <summary>
	/// show paused
	/// </summary>	
	public void showPaused ()
	{
		foreach (GameObject pause in pauseObjects) {
			pause.SetActive (true);
			pauseEnable = true;
		}
	}
	/// <summary>
	/// Hides paused.
	/// </summary>
	public void hidePaused ()
	{
		foreach (GameObject pause in pauseObjects) {
			pause.SetActive (false);
			pauseEnable = false;
		}
	}
	/// <summary>
	/// Shows the window.
	/// </summary>
	public void showWin ()
	{
		foreach (GameObject win in winObjects) {
			win.SetActive (true);
				winEnable = true;

		}
	}
	/// <summary>
	/// Hides the window.
	/// </summary>
	public void hideWin ()
	{
		foreach (GameObject win in winObjects) {
			win.SetActive (false);
			winEnable = false;

		}
	}
	/// <summary>
	/// Shows the loss.
	/// </summary>
	public void showLoss ()
	{
		foreach (GameObject loss in lossObjects) {
			loss.SetActive (true);

		}
	}
	/// <summary>
	/// Hides the loss.
	/// </summary>
	public void hideLoss ()
	{
		foreach (GameObject loss in lossObjects) {
			loss.SetActive (false);

		}
	}
	/// <summary>
	/// Loads the level.
	/// </summary>
	/// <param name="level">Level.</param>
	public void LoadLevel (string level)
	{
		SceneManager.LoadScene ("Menu");
	}
	/// <summary>
	/// Quit this instance.
	/// </summary>
	public void Quit ()
	{
		Application.Quit ();
	}
}
