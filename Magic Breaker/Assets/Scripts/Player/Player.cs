using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
     [SerializeField]
     private int lifePoints = 3;

    // Start is called before the first frame update
    void Start()
    {
          GameEvents.OnOutBallEvent += LoseLifePoint;
    }

     private void OnDestroy()
     {
          GameEvents.OnOutBallEvent -= LoseLifePoint;
     }

     private void LoseLifePoint()
     {
          if (lifePoints > 1)
          {
               lifePoints--;
               GameEvents.OnHealthChange?.Invoke(lifePoints);
          }
          else
          {
               GameManager.Instance.GameOver();
          }

          //TODO: En caso de no tener vidas Mostrar el Game Over

     }
}
