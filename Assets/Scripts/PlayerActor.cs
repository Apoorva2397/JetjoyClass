using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[DisallowMultipleComponent]
public class PlayerActor : MonoBehaviour{

	[SerializeField] private float speedX;
	
	[SerializeField] private float jumpFactor;


	[SerializeField] private PlayerSpeed speedProvider;

	public float getSpeedX(){

		return speedX;
	}
	
	
	private void Awake(){

		myRigidbody2D = GetComponent<Rigidbody2D>();
		
	}

	void Start () {
		
	}

	private void OnEnable(){
		
		if(speedProvider!=null)
			speedProvider.registerPlayer(this);
		
	}

	private void OnDisable(){
		if(speedProvider!=null)
			speedProvider.unRegisterPlayer();

	}

	private void FixedUpdate(){


		//TODO improve jump
		if (Input.GetKey(KeyCode.Space)){
		
			myRigidbody2D.AddForce(Vector2.up*jumpFactor,ForceMode2D.Force);
		}
		
	}

	private void OnTriggerEnter2D(Collider2D other){


		Debug.Log("on trigger called");
		if (other.gameObject.CompareTag("Obstacle")){
			Debug.Log("triggered with obstacle");
		}
		
		
	}

	private void OnTriggerExit2D(Collider2D other){
		
	}

	private Rigidbody2D myRigidbody2D;
	




}
