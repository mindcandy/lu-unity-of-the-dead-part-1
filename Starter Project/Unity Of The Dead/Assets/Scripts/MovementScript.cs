﻿using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {
	
	public float speed = 4;

	private Vector2 movement;
	private Animator animator;

	void Start()
	{
		animator = GetComponent<Animator>();
	}
	
	void Update()
	{
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		if(inputY == 0 && inputX == 0)
		{
			animator.SetBool("Idle",true);
		}
		else
		{
			animator.SetBool("Idle",false);
		}

		movement = new Vector2(
			speed * inputX,
			speed * inputY);

	}
	
	void FixedUpdate()
	{
		rigidbody2D.velocity = movement;
		animator.SetFloat("Horizontal",movement.x);
		animator.SetFloat("Vertical",movement.y);
	}
}
