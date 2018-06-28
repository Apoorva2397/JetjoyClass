using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour{

	[Range(0.0f,1.0f)]
	[SerializeField] private float control;
//	[SerializeField]private PlayerActor player;

	[SerializeField] private PlayerSpeed speedProvider;
	
	private void Awake(){


		initPosition = transform.localPosition;
		repeatLength = (GetComponent<SpriteRenderer>().sprite.bounds.max -
		                GetComponent<SpriteRenderer>().sprite.bounds.min).x*transform.localScale.x;
		
		
	}

	private void Update (){
		float movement = control*speedProvider.getSpeedX()*Time.deltaTime;
		displacement += movement;
		

		displacement = Mathf.Repeat(displacement, repeatLength);
//		Debug.Log("displacement "+displacement);
		
		transform.localPosition = initPosition+new Vector3(-displacement,0,0);

	}


	private float repeatLength;
	private float displacement;

	private Vector3 initPosition;

}
