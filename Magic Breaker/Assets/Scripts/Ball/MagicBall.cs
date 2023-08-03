using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MagicBallTypes { normal, fire, water, wind, thunder}

public class MagicBall : MonoBehaviour
{
     //TODO: Añadir el tipo de bola que es
     [SerializeField]
     private int ballDamage = 1;

     [SerializeField]
     private MagicBallTypes ballTypes = MagicBallTypes.normal;

     private void OnCollisionEnter2D(Collision2D collision)
     {
          if (collision.collider.CompareTag("Brick"))
          {

               // TODO: Crear una interacción diferente segun el tipo de bola, como areas de daño u otros
               if(collision.gameObject.TryGetComponent(out Brick brick))
                    brick.takeImpact(ballDamage); 
          }
     }

}
