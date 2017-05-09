﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFramework : MonoBehaviour {

    //Combat variables
    private int attack;             //Flat damage dealt
    private float maxSenseDistance;  //How far away the enemy can sense the player
	private int health;             //Maximum amount of damage an enemy can withstand
	
	//Movement variables
	public float runSpeed;
	public float walkSpeed;
	public float jumpForce;
	private bool canJump;
	
    public int Attack { get; set; }
    public float AttackRangeMax { get; set; }
    public float AttackRangeMin { get; set; }
    public int Health { get; set; }
	/**
	Beginning of enemy movement functions
	**/
	public void Walk(string direction)
	{
		//Finds Rigidbody2D of enemy
		Rigidbody2D rb;
		rb = GetComponent<Rigidbody2D>();
		
		//Checks string for direction and accelerates to
		//walkSpeed for each frame the function is called.
		if(direction == "right")
		{
			if(rb.velocity.x < walkSpeed){
				rb.AddForce(Vector2.right * ((walkSpeed - rb.velocity.x)/10), ForceMode2D.Impulse);
			}
		}
		if(direction == "left")
		{
			if(rb.velocity.x > -walkSpeed){
					rb.AddForce(Vector2.right * ((-walkSpeed - rb.velocity.x)/10), ForceMode2D.Impulse);
			}
		}
	}
	public void Run(string direction)
	{
		//Finds Rigidbody2D of enemy
		Rigidbody2D rb;
		rb = GetComponent<Rigidbody2D>();
		
		//Checks string for direction and accelerates to
		//runSpeed for each frame the function is called.	
		if(direction == "right")
		{
			if(rb.velocity.x < runSpeed){
				rb.AddForce(Vector2.right * ((runSpeed - rb.velocity.x)/10), ForceMode2D.Impulse);
			}
		}
		if(direction == "left")
		{
			if(rb.velocity.x > -runSpeed){
					rb.AddForce(Vector2.right * ((-runSpeed - rb.velocity.x)/10), ForceMode2D.Impulse);
			}
		}
	}
	public void Jump()
	{
		/**Currently, raycasts are used to detect if the enemy is on the ground.
		This is prone to create weird behaviour, as on some surfaces, both raycasts
		may not intersect with the terrain. (example: a bridge with holes in it)
		Caution also needs to be taken when setting up the gameObject and child sprites
		for the enemy so that the raycasts are indeed positioned at their feet.
		**/
		
		//Raycast on right
		Vector3 offset;
		offset = new Vector3(0.1f,0,0);
		RaycastHit2D groundHitRight = Physics2D.Raycast(transform.position + offset, Vector2.down, 0.05f);
		Debug.DrawRay(transform.position + offset, Vector2.down * 0.05f);
		
		//Raycast on left
		offset = new Vector3(-0.1f,0,0);
		RaycastHit2D groundHitLeft = Physics2D.Raycast(transform.position + offset, Vector2.down, 0.05f);
		Debug.DrawRay(transform.position + offset, Vector2.down * 0.05f);
		
		//Is enemy able to jump?
		canJump = groundHitRight || groundHitLeft;
		
		//If player is capable of jumping, an upward force is applied
		if(canJump)
		{
			//Finds Rigidbody2D of enemy
			Rigidbody2D rb;
			rb = GetComponent<Rigidbody2D>();
			
			//Applies jumpForce to player's Rigidbody2D
			rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
	}
	/**
	End of enemy movement functions
	**/
    //Only called in enemyBehaviour
    //'s' is equal to enemyType
    public EnemyFramework EnemyCreation(string s)
    {
        switch (s)
        {
            //Sorted alphabetically
            case "ArmCannonCultist":
                return new ArmCannonCultist();
            case "LaserCultist":
                return new LaserCultist();
            case "MeleeCultist":
                return new MeleeCultist();
            default:
                return null;
        }
    }
}