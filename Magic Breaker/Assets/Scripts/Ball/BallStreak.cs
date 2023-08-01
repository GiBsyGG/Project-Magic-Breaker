using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStreak : MonoBehaviour
{
     [SerializeField]
     private BallMovement ballMovement;

     [SerializeField]
     private int maxStreak = 25;

     [SerializeField]
     private HUDBounceBar bounceBar;  //Para enviar el máximo a la barra

     private int streak = 0;

     private void Start()
     {
          GameEvents.OnOutBallEvent += ResetStreak;
     }

     private void OnDestroy()
     {
          GameEvents.OnOutBallEvent -= ResetStreak;
     }

     private void OnCollisionEnter2D(Collision2D collision)
     {
          if (ballMovement != null)
          {
               // Racha maxima de 50 rebotes, cada 10 aumenta el umbral de velocidad
               if(streak < maxStreak)
               {
                    streak++;
                    GameEvents.OnStreakChange?.Invoke(streak);

                    if (streak % 5 == 0)
                    {
                         Debug.Log("Acelera");
                         ballMovement.MinSpeedThershhold += 5f;
                         ballMovement.BallMaxSpeed += 5f;
                    }
               }
          }
     }

     private void ResetStreak()
     {
          streak = 0;
     }
}
