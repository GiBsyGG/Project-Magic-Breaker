using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

     public static GameManager Instance;

     private void Awake()
     {
          if(Instance == null)
          {
               Instance = this;

               // No destruir el GM durante el cambio de escenas
               DontDestroyOnLoad(gameObject);
          }
          else
          {
               Destroy(gameObject);
          }
     }

     // Start is called before the first frame update
     void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
