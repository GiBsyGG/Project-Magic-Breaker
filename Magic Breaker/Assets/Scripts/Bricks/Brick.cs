using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Brick : MonoBehaviour
{
     [SerializeField]
     private int brickLife = 1;

     public void takeImpact(int damage)
     {
          brickLife -= damage;

          if(brickLife <= 0)
          {
               GameEvents.OnBrickDestroyEvent?.Invoke();
               Destroy(gameObject);
          }
     }
}
