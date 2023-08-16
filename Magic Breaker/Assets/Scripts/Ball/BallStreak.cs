using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BallStreak : MonoBehaviour
{
     [SerializeField]
     private BallMovement ballMovement;

     [SerializeField]
     private int maxStreak = 25;

     private int streak = 0;

     private bool maxReached = false; // Flag para controlar si es alcanzado el maximo

     private void Start()
     {
          GameEvents.OnOutBallEvent += ResetStreak;
          maxReached = false;
     }

     private void OnDestroy()
     {
          GameEvents.OnOutBallEvent -= ResetStreak;
     }

     private void OnCollisionEnter2D(Collision2D collision)
     {
          if (ballMovement != null)
          {
               // Racha maxima de rebotes, cada 5 aumenta el umbral de velocidad
               if(streak < maxStreak)
               {
                    streak++;
                    GameEvents.OnStreakChange?.Invoke(streak);

                    if (streak % 5 == 0)
                    {
                         
                         ballMovement.MinSpeedThershhold += 2f;
                         ballMovement.BallMaxSpeed += 2f;
                    }
               }
               else if(streak == maxStreak)
               {
                    maxReached = true;
               }
          }
     }

     private void ResetStreak()
     {
          streak = 0;
          maxReached = false;
     }

     public bool MaxReached
     {
          get { return maxReached; }
     }
}
