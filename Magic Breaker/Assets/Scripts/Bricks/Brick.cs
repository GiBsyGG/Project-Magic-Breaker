using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Brick : MonoBehaviour
{
     [SerializeField]
     private int brickLife = 1;

     [SerializeField]
     private Sprite[] brickSprites;

     public void TakeImpact(int damage)
     {
          brickLife -= damage;

          if(brickLife <= 0)
          {
               GameEvents.OnBrickDestroyEvent?.Invoke();
               Destroy(gameObject);
          }
          else
          {
               // Se cambia el Sprite según el daño
               if (TryGetComponent(out SpriteRenderer spriteRenderer))
               {
                    spriteRenderer.sprite = brickSprites[brickLife - 1];
               }
          }
     }
}
