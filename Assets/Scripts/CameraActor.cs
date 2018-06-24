using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
[RequireComponent(typeof(Camera))]
public class CameraActor : MonoBehaviour {
	private void Awake(){
		myCamera = GetComponent<Camera>();
	}

	// Use this for initialization
	void Start () {
		
	}


	public float getRightBound(){
		return transform.position.x+myCamera.aspect*myCamera.orthographicSize;
		
	}

	public float getLeftBound(){
		return transform.position.x-myCamera.aspect*myCamera.orthographicSize;
	}
	
	
	public bool isOffScreenLeft(float worldX ){
		return worldX < getLeftBound();
	}
	
	public bool isOffScreenRight(float worldX ){
		return worldX > getRightBound();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private Camera myCamera;
}
