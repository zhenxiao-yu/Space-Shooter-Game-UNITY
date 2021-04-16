using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    static public Hero S; //Singleton

    [Header ("Set in Inspector")]
    //These fields control the movement of the ship
    public float speed = 30;
    public float rollMult = -45;
    public float pitchMult = 30;

    //This variable holds a reference to the last triggering GameObject
    private GameObject lastTriggerGo = null;

    void Awake(){
        if (S == null){
            S = this; //set the Singleton
        } else {
            Debug.LogError("Hero.Awake() - Attempted to assign second Hero.S!"); //Error handling
        }
    }

    void Update() {
        //pull in information drom the input class
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        //change transform.position based on axes
        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;

        //rotate the ship to make it feel more dynamic
        transform.rotation = Quaternion.Euler(yAxis*pitchMult,xAxis*rollMult,0);
    }

    void OnTriggerEnter(Collider other){
        //
        Transform rootT = other.gameObject.transform.root; 
        GameObject go = rootT.gameObject;
        //make sure its not the same triggering go as last time
        if (go == lastTriggerGo){
            return;
        }
        lastTriggerGo = go;

        if (go.tag == "Enemy"){
            Destroy(go);        //detroy the enemy object that collided with the _Hero
            Destroy(gameObject); //destroy _Hero after collision
        } else {
            print("Triggered by non-Enemy: " + go.name); //error handling
        }
    }
}
