using System.Collections;           //Required for Arrays & other Collections 
using System.Collections.Generic;   //Required for Lists and Dictionaries
using UnityEngine;                  //Required for Unity

public class Enemy : MonoBehaviour
{
   [Header("Set in Inspector: Enemy")]
   public float speed = 10f;        //The speed in m/s
   

   private BoundsCheck bndCheck;

   //This is a property : a method that act like a field
   public Vector3 pos{
      get{
         return (this.transform.position);
      }
      set {
         this.transform.position = value;
      }
   }

   void Awake(){
      bndCheck = GetComponent<BoundsCheck>();
   }

   void Update(){
      Move();

      if (bndCheck != null && !bndCheck.isOnScreen){
            //Check to make sure it's gone off the screen
            //We're off the screen, so destroy this GameObject
            Destroy(gameObject);
      }
   }
   //Method that move sthe nemy straight down
   public virtual void Move(){
      Vector3 tempPos = pos;
      //apply force at y direction
      tempPos.y -= speed * Time.deltaTime;
      pos = tempPos;
   }
}
