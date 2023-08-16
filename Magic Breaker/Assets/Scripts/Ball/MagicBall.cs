using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MagicBallTypes { normal, fire, water, wind, thunder}

public class MagicBall : MonoBehaviour
{
     [SerializeField]
     private int ballDamage = 1;

     [SerializeField]
     private MagicBallTypes ballType = MagicBallTypes.normal;

     private void OnCollisionEnter2D(Collision2D collision)
     {
          if (collision.collider.CompareTag("Brick"))
          {
               switch (ballType)
               {
                    case MagicBallTypes.fire:

                         FireBallImpact();

                         break;

                    case MagicBallTypes.thunder:

                         ThunderBalImpact(collision);

                         break;

                    default:
                         if (collision.gameObject.TryGetComponent(out Brick brick))
                              brick.TakeImpact(ballDamage);

                         break;
               }
          }

          // El poder de agua resetea la bola para controlar el lanzamiento
          if (collision.collider.CompareTag("Platform"))
          {
               if(ballType == MagicBallTypes.water)
               {
                    if(transform.parent.TryGetComponent(out BallMovement ballMovement))
                    {
                         
                         ballMovement.ResetBall();
                    }
               }
          }
     }

     private void FireBallImpact()
     {
          // Uso overlapcircleAll para aplicar daño en area detectando los colliders en un area
          // Este devuelve una lista de colliders detectados en esa area
          Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 2f);
          foreach (Collider2D collider in colliders)
          {
               if (collider.gameObject.TryGetComponent(out Brick brickf))
                    brickf.TakeImpact(ballDamage);
          }
     }

     private void ThunderBalImpact(Collision2D collision)
     {
          // Aplicar daño a bloque impactado
          if (collision.gameObject.TryGetComponent(out Brick brickThunderImp))
               brickThunderImp.TakeImpact(ballDamage);

          // Uso Raycast All Para aplicar daño a izquierda y derecha
          // Este devuelve un array con los impactos del raycast
          // 14.75 es la distancia de muro a muro
          RaycastHit2D[] hitsR = Physics2D.RaycastAll(transform.position, Vector2.right, 14.75f - Mathf.Abs(transform.position.x));
          RaycastHit2D[] hitsL = Physics2D.RaycastAll(transform.position, Vector2.right, 14.75f - Mathf.Abs(transform.position.x));

          // Aplicar daño a linea derecha
          foreach (RaycastHit2D hit in hitsR)
          {
               if (hit.collider.gameObject.TryGetComponent(out Brick brickt))
               {
                    brickt.TakeImpact(ballDamage);
               }
          }
          // Aplicar daño a line izquierda
          foreach (RaycastHit2D hit in hitsL)
          {
               if (hit.collider.gameObject.TryGetComponent(out Brick brickt))
               {
                    brickt.TakeImpact(ballDamage);
               }
          }
     }
}
