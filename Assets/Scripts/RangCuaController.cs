using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangCuaController : MonoBehaviour
{
    private int direction = 1;
 private float moveSpeed = 4;
 private bool movingRight = true; 

 
 void Update()
 {
     Vector3 movement = new Vector3(direction, 0f, 0f); 
     transform.Translate(movement * moveSpeed * Time.deltaTime);

    
     if (transform.position.x > 7.46f && movingRight)
     {
         movingRight = false;
         direction *= -1;
     }
     else if (transform.position.x < 1.28f && !movingRight)
     {
         movingRight = true;
         direction *= -1;
     }
 }
}
