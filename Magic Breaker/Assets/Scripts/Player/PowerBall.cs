using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PowerBall : MonoBehaviour
{

     [SerializeField]
     private Transform ballParent;

     private MagicBall actualBall;

     [SerializeField]
     private MagicBall[] balls;

     [SerializeField]
     private BallStreak streak;

     private bool powerActive = false; // Flag para controlar la activación del poder

    // Start is called before the first frame update
    void Start()
    {
          if(balls.Length > 0)
          {
               ResetPowerBall();
          }

          GameEvents.OnOutBallEvent += ResetPowerBall;
    }

     private void OnDestroy()
     {
          GameEvents.OnOutBallEvent -= ResetPowerBall;
     }

     public void InputPowerBall(InputAction.CallbackContext callbackContext)
     {
          // El callback context es para ver si la tecla fue pulsada, mantenida o suelta
          // tiene tres fases started, performed y cancel (pulsada, pulsado, suelto)

          if (callbackContext.started)
          {
               if (!powerActive && streak.MaxReached)
               {
                    ActiveRandomPowerBall();
               }
          }
     }

     private void ActiveRandomPowerBall()
     {
          int ballSelectedIndex = Random.Range(1, balls.Length);

          // Obtenemos la velocidad de la bola anterior
          //if(actualBall.TryGetComponent(out Rigidbody2D prevBallRb)){
          //     prevBallVelocity = prevBallRb.velocity;
          //}

          // Destruyo la bola anterior
          if(actualBall != null)
          {
               Destroy(actualBall.gameObject);
          }

          // Creo la nueva bola
          actualBall = Instantiate(balls[ballSelectedIndex], ballParent.position, ballParent.rotation);
          actualBall.transform.parent = ballParent;

          powerActive = true;

          //if(actualBall.TryGetComponent(out Rigidbody2D actualBallRb)){
          //     actualBallRb.velocity = prevBallVelocity;
          //}
     }

     private void ActivePowerBall(int ballIndex)
     {
          if (actualBall != null)
          {
               Destroy(actualBall.gameObject);
          }

          actualBall = Instantiate(balls[ballIndex], ballParent.position, ballParent.rotation);
          actualBall.transform.parent = ballParent;

          powerActive = true;
     }

     private void ActivePowerBall(MagicBall magicBall)
     {
          if(actualBall != null)
          {
               Destroy(actualBall.gameObject);
          }

          actualBall = Instantiate(magicBall, ballParent.position, ballParent.rotation);
          actualBall.transform.parent = ballParent;

          powerActive = true;
     }

     private void ResetPowerBall()
     {
          if (actualBall != null)
          {
               Destroy(actualBall.gameObject);
          }

          // Al resetear la bola pierdo el estado de poder
          actualBall = Instantiate(balls[0], ballParent.position, ballParent.rotation);
          actualBall.transform.parent = ballParent;

          
          powerActive = false;
     }
}
