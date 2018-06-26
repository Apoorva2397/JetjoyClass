using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour{

	[Range(0.0f,1.0f)]
	[SerializeField] private float control;

	[SerializeField]private PlayerActor player;
	
	
	private void Awake(){
		
	}

	private void Update () {
		
	}
	
}
