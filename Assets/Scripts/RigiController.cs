﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RigiController : MonoBehaviour {

	public float speed;
	public float jumpHeight;
	public LayerMask ground;
	public Transform feet;

	private Vector3 direction;
	private Rigidbody rbody;
	//private AudioSource audio;

	public Text winText;


	// Use this for initialization
	void Start () {
		speed = 2.0f;
		jumpHeight = 3.0f;
		rbody = GetComponent<Rigidbody>();
		//audio = GetComponent<AudioSource>();

		winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		direction = Vector3.zero;
		direction.x = -Input.GetAxis("Horizontal");
		direction.z = -Input.GetAxis("Vertical");
		direction = direction.normalized;
		if(direction != Vector3.zero) {
			transform.forward = direction;
			rbody.AddForce(direction * 1.0f, ForceMode.VelocityChange);
		}
		bool isGrounded = Physics.CheckSphere(feet.position, 0.1f, ground, QueryTriggerInteraction.Ignore);
		if(Input.GetButtonDown("Jump") && isGrounded) {
			//audio.Play();
			rbody.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
		}
	}

	void OnTriggerEnter(Collider other) {
		//Destroy(other.gameObject);
		if(other.gameObject.CompareTag("Pick Up")){
			other.gameObject.SetActive(false);
//			count++;
//			SetCountText ();
			winText.text = "You Win";
		}
	}

	void FixedUpdate() {
		//rbody.MovePosition(rbody.position + direction * speed * Time.fixedDeltaTime);
	}
}








