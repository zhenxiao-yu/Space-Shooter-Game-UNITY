using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enemy_2 extends the Enemy class
public class Enemy_2 : Enemy
{
    //These fields will help adjust the direction Enemy_2 will move in
    private int _left = 1; //positive number makes Enmey_2 move to the left 
    private int _right = -1; //negative number makes Enmey_2 move to the right 
    private int _angle;

	// Use this for initialization
	void Start () {
        //Generate a number randomly between 1 and 2    
        int num = Random.Range(1, 3);
        //Switch statement that assign a direction based on the random number generated
       switch (num)
      {
          case 1:
              _angle = _left;
              break;
          case 2:
              _angle = _right;
              break;
          default:
              break;
      }
	}

    //Override the Move function on Enemy
    public override void Move() {
        //get the pos as an editable Vector 3
        Vector3 tempPos = pos;
        //Adding a force in the x direction makes the object move in 45 degree angle
        tempPos.x -= speed * Time.deltaTime * _angle ;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }
}