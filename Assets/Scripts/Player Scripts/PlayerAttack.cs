using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	private bool attack = false;
	private Animator anim;
	private float attackTimer = 0;
	private float attackCd = 0.5f;
	public Collider2D attackTrigger = new Collider2D();
	//private Animation animation;



	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		//attackTrigger = GetComponent<Collider2D> ();
		attackTrigger.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		//HandleInput ();
		if (Input.GetKeyDown (KeyCode.F) && !attack) {
			attack = true;
			attackTimer = attackCd;
			attackTrigger.enabled = true;
		}

		if (attack) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			}
			else {
				attack = false;
				attackTrigger.enabled = false;
			}
			anim.SetBool ("attack", attack);
		}
	}

//	void OnCollisionEnter2D(Collision2D target)
//	{
//		if(anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
//		{
//			if (target.gameObject.tag == "Enemy") {
//				target.gameObject.SetActive (false);
//			}
//		}
//	}
//
//	void FixedUpdate()
//	{
//		HandleAttacks ();
//		if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
//			ResetValues ();
//	}
//	public void HandleAttacks()
//	{
//		if (attack) {
//			anim.SetTrigger ("attack");
//		}
//	}
//
//	private void HandleInput()
//	{
//		if (Input.GetKeyDown (KeyCode.LeftShift)) {
//			attack = true;
//		}
//	}
//
//	private void ResetValues()
//	{
//		attack = false;
//	}
}
