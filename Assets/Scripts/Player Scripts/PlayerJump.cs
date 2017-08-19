using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerJump : MonoBehaviour {

	[SerializeField]
	private AudioClip jumpClip;

	private float jumpForce = 7.5f, forwardForce = 0f;

	private Rigidbody2D myBody;

	private Button jumpButton;
	[SerializeField]
	private bool canJump;

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		myBody = GetComponent<Rigidbody2D> ();
		jumpButton = GameObject.Find ("Jump Button").GetComponent<Button> ();
		jumpButton.onClick.AddListener (() => Jump ());
	}
	
	// Update is called once per frame
	void Update () {
		//The character is on the ground.
		if(Mathf.Abs(myBody.velocity.y) == 0){
			canJump = true;
		}
		if (Input.GetKey (KeyCode.Space)) {
			if (canJump) {
				canJump = false;
				if (transform.position.x < -2) {
					forwardForce = 0.5f;
				} else {
					forwardForce = 0f;
				}
				myBody.velocity = new Vector2 (forwardForce, jumpForce);
				anim.Play ("Jumping");
			}
		}
	}

	public void Jump(){
		if (canJump) {
			canJump = false;
			if (transform.position.x < -2) {
				forwardForce = 0.5f;
			} else {
				forwardForce = 0f;
			}
			myBody.velocity = new Vector2 (forwardForce, jumpForce);
			anim.Play ("Jumping");
		}
	}
}
