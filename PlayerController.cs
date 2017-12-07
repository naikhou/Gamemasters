using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	/*private ButtonController bX;
	private ButtonController bO;
	private ButtonController bLeft;
	private ButtonController bRight;
	private GameObject player;*/

	//initializing variables...
	public bool alive = true;
	public float speed = 5f;
	bool facingRight = true;
	Animator anim;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.025f;
	public LayerMask whatIsGround;
	public float jumpForce = 5f;

	bool doubleJump = false;


	private int count = 0;
	public Text scoreText;
	public int health = 3;
	public int maxHealth = 5;
	public Text healthText;
	public bool canMove;

	/// <summary>
	/// Start this instance.
	/// </summary>
	// Use this for initialization
	void Start ()
	{

		//getting health and scoretexts
		//and animator

		healthText = GameObject.Find ("HealthText").GetComponent<Text> ();
		scoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();
		/*player = GameObject.Find ("Player");
		bLeft = GameObject.Find ("ButtonLeft").GetComponent<ButtonController> ();
		bRight = GameObject.Find ("ButtonRight").GetComponent<ButtonController> ();
		bX = GameObject.Find ("ButtonX").GetComponent<ButtonController> ();
		bO = GameObject.Find ("ButtonO").GetComponent<ButtonController> ();*/
		anim = GetComponent<Animator> ();
		count = 0;
		SetScoreText ();
		alive = true;
		SetHealthText ();
		canMove = true;
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update ()
	{

		//updating healthtext all the time
		SetHealthText ();

		if ((grounded || !doubleJump) && Input.GetKeyDown (KeyCode.Space)) {
			anim.SetBool ("Ground", false);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, jumpForce);
			if (!doubleJump && !grounded) {
				doubleJump = true;
			}
		}
	}

	/// <summary>
	/// Fixed update.
	/// </summary>
	void FixedUpdate ()
	{
		if (!canMove) {
			GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			if (grounded == true) {

			}
		}
		
		//checks if the character is on the ground
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);


			

		if (grounded) {
			doubleJump = false;
		}
		anim.SetFloat ("VSpeed", GetComponent<Rigidbody2D> ().velocity.y);

			float move = Input.GetAxis ("Horizontal");
			anim.SetFloat ("Speed", Mathf.Abs (move));
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * speed, GetComponent<Rigidbody2D> ().velocity.y);

			//flips the player according to which direction it's going
				if (move > 0 && !facingRight) {
					Flip ();
				} else if (move < 0 && facingRight) {
					Flip ();
				}
			}
		

	/// <summary>
	/// Flip this instance.
	/// </summary>
	//character flipping method
	void Flip ()
	{
			facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="other">Other.</param>
	//what happens when player collides
	void OnTriggerEnter2D (Collider2D other)
	{

		//collecting points
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count += 1;
			SetScoreText ();
		}

		//collecting lives
		if (other.gameObject.CompareTag ("Life")) {
			other.gameObject.SetActive (false);
			if (health < maxHealth) {
				health += 1;
			} else {
				count += 1;
				SetScoreText ();
			}
		}
		// when player collides with dialogue, dialogue collider will disappear
		if (other.gameObject.CompareTag ("Dialogue")) {
			other.gameObject.SetActive (false);
		}
	}

	/// <summary>
	/// Sets the score text.
	/// </summary>
	void SetScoreText ()
	{
		scoreText.text = "Score: " + count.ToString ();
	}

	/// <summary>
	/// Sets the health text.
	/// </summary>
	void SetHealthText ()
	{
		healthText.text = "Health: " + health.ToString () + "/" + maxHealth;
		if (health <= 0 || alive == false)
			healthText.text = "Dead";
	}
}
