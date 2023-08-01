using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallImpact : MonoBehaviour
{
     //TODO: Añadir el tipo de bola que es
     [SerializeField]
     private int ballDamage = 1;

     private void OnCollisionEnter2D(Collision2D collision)
     {
          if (collision.collider.CompareTag("Brick"))
          {
               if(collision.gameObject.TryGetComponent(out Brick brick))
                    brick.takeImpact(ballDamage); 
          }
     }

}
