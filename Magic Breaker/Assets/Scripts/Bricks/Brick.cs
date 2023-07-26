using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
     [SerializeField]
     private int brickLife = 1;

     private void OnCollisionEnter2D(Collision2D collision)
     {
          if (collision.collider.CompareTag("Ball"))
          {
               brickLife--;

               if(brickLife == 0)
               {
                    Destroy(gameObject);
               }
          }
     }
}
