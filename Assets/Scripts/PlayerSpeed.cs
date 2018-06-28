using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerSpeed : ScriptableObject{

    [SerializeField] private float testSpeed;
    
    public float getSpeedX(){

        if (player == null){
            return testSpeed;
        }
        return player.getSpeedX();
    }


    public void registerPlayer(PlayerActor p){
        player = p;

    }
    public void unRegisterPlayer(){
        player = null;
        
    }


    [SerializeField]private PlayerActor player;
    
    
    
    

}
