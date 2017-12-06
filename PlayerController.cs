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
	public bool alive = true;
	public float speed = 5f;
	bool facingRight = true;
	Animator anim;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.1f;
	public LayerMask whatIsGround;
	public float jumpForce = 5f;

	bool doubleJump = false;
//	bool playerHit = false;

	private int count = 0;
	public Text scoreText;
	public int health = 3;
	public int maxHealth = 5;
	public Text healthText;

	// Use this for initialization
	void Start ()
	{
		

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
	}


	void Update ()
	{
//		if (playerHit) {
//			StartCoroutine (BeginTimeOut ());
//		}
		
		SetHealthText ();

		if ((grounded || !doubleJump) && Input.GetKeyDown (KeyCode.Space)) {
			anim.SetBool ("Ground", false);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, jumpForce);
			if (!doubleJump && !grounded) {
				doubleJump = true;
			}
		}
	}

	void FixedUpdate ()
	{

		

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);
		if (grounded) {
			doubleJump = false;
		}
		anim.SetFloat ("VSpeed", GetComponent<Rigidbody2D> ().velocity.y);

		
		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs (move));
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * speed, GetComponent<Rigidbody2D> ().velocity.y);
		if (move > 0 && !facingRight) {
			Flip ();
		} else if (move < 0 && facingRight) {
			Flip ();
		}
	}

	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count += 1;
			SetScoreText ();
		}
		if (other.gameObject.CompareTag ("Life")) {
			other.gameObject.SetActive (false);
			if (health <= maxHealth) {
				health += 1;
			}
		}
		//if (other.gameObject.tag == "Enemy") {
			//health -= other.gameObject.GetComponent<Enemy> ().attackDamage;
			//playerHit = true;
		//}



	}
	void SetScoreText () {
		scoreText.text = "Score: " + count.ToString ();
	}
	void SetHealthText(){
		healthText.text = "Health: " + health.ToString () +"/" + maxHealth;
		if (health <= 0 || alive == false)
			healthText.text = "Dead";
	}
//	public IEnumerator BeginTimeOut()
//	{
//		Debug.Log ("Kakka");
//		yield return new WaitForSeconds(3);
//		playerHit = false;
//	}


}
