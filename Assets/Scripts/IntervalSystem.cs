using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


[DisallowMultipleComponent]
public class IntervalSystem : MonoBehaviour{

	[SerializeField] private float minDistance;
	[SerializeField] private float maxDistance;




	[Header("Dependencies")] 
	[SerializeField]private PlayerActor player;
	[SerializeField] private CameraActor cam;
	[SerializeField] private CeilingActor topCeiling;
	[SerializeField] private CeilingActor BottomCeiling;



	[Serializable]
	struct Entity{
		public Interactable interactable;
	}

	[Header("Entities")] 
	
	[SerializeField] private Entity[] entities;


	private void Awake(){
		interactables = new List<Interactable>();
		
	}




	private void move(float amount){

		for (int i = 0; i < interactables.Count; i++){
			interactables[i].move(amount);
			
		}
	}

	private int getPendingInteractables(){


		int pending = 0;
		for (int i = 0; i < interactables.Count; i++){
			if (cam.isOffScreenRight(interactables[i].getMinX())){
				++pending;
			}
		}

		return pending;
	}
	private void FixedUpdate(){

		
		//get player speed
		//move all objects
		float playermovement = -1*player.getSpeedX()*Time.deltaTime;
		move(playermovement);


		int pending = getPendingInteractables();
		if (pending < 1){
			spawnInteractable();
		}
		destroyOffScreenInteractables();


		//instanitate if required.
		//delete which are out of bounds



	}

	private void spawnInteractable(){

		//returns prefab
		Interactable chosen = chooseInteractable();
		
		Vector3 pos = Vector3.zero;
		//spawning in scene based on prefab
		Interactable created =Instantiate(chosen, pos, chosen.transform.rotation, transform);
		
		
		
		float topLimit = topCeiling.getBottomLeft().y;
		float bottomLimit = BottomCeiling.getTopRight().y;
		topLimit-=created.getTopDistance();
		bottomLimit += created.getBottomDistance();

		pos.y = Random.RandomRange(topLimit, bottomLimit);

		if (interactables.Count > 0){
			var last = interactables[interactables.Count - 1];
			pos.x = last.getMaxX() + Random.Range(minDistance, maxDistance);
			
		}
		else{
			pos.x = cam.getRightBound() + maxDistance;
			
		}
		interactables.Add(created);
		created.transform.position = pos;
		


	}

	private Interactable chooseInteractable(){
		int randIndex = Random.Range(0, entities.Length);

		return entities[randIndex].interactable;
		
	}

	private void destroyOffScreenInteractables(){
		for (int i = interactables.Count-1; i >=0; --i){
			
			//if out of screen delete here.
			if (cam.isOffScreenLeft(interactables[i].getMaxX())){
				Interactable obj = interactables[i];
				Destroy(obj.gameObject);
				interactables.RemoveAt(i);
				
				
			}
			


		}
	}

	private List<Interactable> interactables;

}
