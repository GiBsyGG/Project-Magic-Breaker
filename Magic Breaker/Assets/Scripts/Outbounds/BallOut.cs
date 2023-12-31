using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallOut : MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D collision)
     {
          
          if (collision.CompareTag("Ball"))
          {
               GameEvents.OnOutBallEvent?.Invoke();
               GameEvents.OnStreakChange?.Invoke(0);
          }
     }
}
