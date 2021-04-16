﻿using System.Collections;           //Required for Arrays & Other Collections
using System.Collections.Generic;   //Required to use Lists or Dictionaries
using UnityEngine;                  //Required for Unity


public class Main : MonoBehaviour
{
   static public Main S; //A singleton for Main

   [Header("Set in Inspector")]
   public GameObject[] prefabEnemies; // Array of Enemy prefabs
   public float enemySpawnPerSecond = 0.5f; //No. of Enemies/ second
   public float enemyDefaultPadding = 1.5f; // Padding for position

   private BoundsCheck bndCheck;

   void Awake(){
       S = this;
       //set bndCheck to reference the BoundCheck component on this GameObject
       bndCheck = GetComponent<BoundsCheck>();
       //invoke SpawnEnemy() once (in 2 seconds, based on default values)
       Invoke("SpawnEnemy", 1f/enemySpawnPerSecond);
   }

   public void SpawnEnemy(){
       //Pick a random Enemy prefab to instantiate
       int ndx = Random.Range(0, prefabEnemies.Length); 
       GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]);

       //Position the Enemy above the screen with a random x postion
       float enemyPadding = enemyDefaultPadding;
       if (go.GetComponent<BoundsCheck>()!= null){
           enemyPadding = Mathf.Abs( go.GetComponent<BoundsCheck>().radius);
       }

       //set the initial position for the spawned enemy 
       Vector3 pos = Vector3.zero;
       float xMin = -bndCheck.camWidth + enemyPadding;
       float xMax =  bndCheck.camWidth - enemyPadding;
       pos.x = Random.Range(xMin, xMax);
       pos.y = bndCheck.camHeight + enemyPadding;
       go.transform.position = pos;

       //invoke SpawnEnemy() again
       Invoke("SpawnEnemy", 1f/enemySpawnPerSecond);
   }

}
