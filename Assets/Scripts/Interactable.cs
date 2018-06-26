using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Interactable : MonoBehaviour {
    

    [SerializeField]private Collider2D mySizeCollider2D;
    private void Awake(){
        
        Assert.IsTrue(mySizeCollider2D!=null && mySizeCollider2D.isTrigger,"attach a trigger collider");


        
       
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myRigidbody2D.isKinematic = true;
        myRigidbody2D.interpolation = RigidbodyInterpolation2D.Interpolate;
        
    }

    public void move(float amount){
       myRigidbody2D.MovePosition(myRigidbody2D.position+new Vector2(amount,0));

    }

    public float getMinX(){


        return mySizeCollider2D.bounds.min.x;
        
        return 0;
    }
    
    public float getMaxX(){
        return mySizeCollider2D.bounds.max.x;

    }

    private Rigidbody2D myRigidbody2D;

    public float getTopDistance(){

        return mySizeCollider2D.bounds.max.y - transform.position.y;
    }
    public float getBottomDistance(){

        return transform.position.y-mySizeCollider2D.bounds.min.y;
    }

}
