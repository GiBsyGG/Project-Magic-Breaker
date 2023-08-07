using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BrickCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.OnBrickDestroyEvent += CheckBricksNumber;
    }

     private void OnDestroy()
     {
          GameEvents.OnBrickDestroyEvent -= CheckBricksNumber;
     }

     // Update is called once per frame
     void Update()
    {
        
    }

    private void CheckBricksNumber()
     {
          int bricksNumber  = transform.childCount;
          Debug.Log(bricksNumber);

          if (bricksNumber <= 1)
          {
               GameManager.Instance.WinGame();
          }
     }
}
