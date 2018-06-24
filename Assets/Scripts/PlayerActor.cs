using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[DisallowMultipleComponent]
public class PlayerActor : MonoBehaviour{
	[SerializeField] private float jumpFactor;
	private void Awake(){

		myRigidbody2D = GetComponent<Rigidbody2D>();
		
	}

	void Start () {
		
	}

	private void FixedUpdate(){


		//TODO improve jump
		if (Input.GetKey(KeyCode.Space)){
		
			myRigidbody2D.AddForce(Vector2.up*jumpFactor,ForceMode2D.Force);
		}
		
	}

	private Rigidbody2D myRigidbody2D;
	




}
