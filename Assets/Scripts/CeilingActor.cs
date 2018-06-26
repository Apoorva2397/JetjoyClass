using UnityEngine;



[RequireComponent(typeof(BoxCollider2D))]
[DisallowMultipleComponent]
public class CeilingActor:MonoBehaviour{
    private void Awake(){
        myBoxCollider2D = GetComponent<BoxCollider2D>();
        
    }
    
    
    
	public Vector2 getTopRight(){

	    return myBoxCollider2D.bounds.max;
	}
    
    
    public Vector2 getBottomLeft(){

        return myBoxCollider2D.bounds.min;
    }




    private BoxCollider2D myBoxCollider2D;

}
