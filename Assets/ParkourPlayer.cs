using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkourPlayer : MonoBehaviour {

	//What do we want?
	//check every frame for player input
	//apply that input as player movement
	//update and fixed update

	private Rigidbody rb;

	public float jumpHeight;
	private Vector3 fallingVelocity;

	public LayerMask ground;
	public float gravity;



	void Start() {

		rb = GetComponent<Rigidbody>();

		jumpHeight = 3.0f;
		fallingVelocity = Vector3.zero;
		gravity = 9.8f;
	}
		

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		//Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		//rb.AddForce (movement);

		bool isGrounded = Physics.CheckSphere(transform.position, 0.1f, ground, QueryTriggerInteraction.Ignore);
		if(isGrounded)
			fallingVelocity.y = 0f;

		if(Input.GetButtonDown("Jump") && isGrounded) {
//			audio.Play();
			fallingVelocity.y = Mathf.Sqrt(gravity * jumpHeight);
		}
	}

}
