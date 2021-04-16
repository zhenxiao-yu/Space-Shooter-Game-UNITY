using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Check whether a GameObject is on screen and can force it to stay on screen
//Note that this ONLY works for an orthographic Main Camera

public class BoundsCheck : MonoBehaviour
{
    [Header ("Set in Inspector")]
    public float radius = 1f;           //The radius of the object 
    public bool keepOnScreen = true;    //Make the object remain on screen 
    
    [Header ("Set Dynamically")]
    public bool isOnScreen = true;      //check if an object on screen
    public float camWidth;              //Dimension of the game space
    public float camHeight;             //Dimesnion of the game space
    
    [HideInInspector]
    public bool offRight, offLeft, offUp, offDown; //which side of the screen did an object went off of

    void Awake(){
        //set game space dimension to the dimension of the camera
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    void LateUpdate (){
        //Chekc if an object has gobe off the screen
        Vector3 pos = transform.position;
        isOnScreen = true;
        offRight = offLeft = offUp = offDown = false;

        if (pos.x > camWidth - radius){
            pos.x = camWidth - radius;
            offRight = true;
        }
        if (pos.x < -camWidth + radius){
            pos.x = -camWidth + radius;
            offLeft = true;
        }
        if (pos.y > camHeight - radius){
            pos.y = camHeight - radius;
            offUp = true;
        }
        if (pos.y < -camHeight + radius){
            pos.y = -camHeight + radius;
            offDown = true;
        }

        isOnScreen = !(offRight || offLeft || offUp || offDown);
        if (keepOnScreen && !isOnScreen){
            transform.position = pos;
            isOnScreen = true;
            offRight = offLeft = offUp = offDown = false;
        }
    }

    //Draw the bounds in the Scene pane using OnDrawGizmos()
    void OnDrawGizmos(){
        if (!Application.isPlaying) return;
        Vector3 boundSize = new Vector3 (camWidth*2, camHeight * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, boundSize);
    }
    
}
