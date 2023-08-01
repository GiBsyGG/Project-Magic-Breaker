using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDPlayerHealth : MonoBehaviour
{

     private List<Image> hearts = new List<Image>();

    // Start is called before the first frame update
    void Start()
    {
        int childCount = transform.childCount;
        for(int i = 0; i < childCount; i++)
          {
               Transform child = transform.GetChild(i);
               if (child != null)
               {
                    if(child.TryGetComponent(out Image image))
                         hearts.Add(image);
               }
          }


          // Para el llamado al suceder el evento
          GameEvents.OnHealthChange += OnHealthPlayerChange;
    }

     private void OnDestroy()
     {
          GameEvents.OnHealthChange -= OnHealthPlayerChange;
     }

     private void OnHealthPlayerChange(int health)
     {
          // Se pinta un corazon o no, segun la vida del jugador
          for(int i = 0; i < hearts.Count; i++)
          {
               if(i < health)
               {
                    hearts[i].gameObject.SetActive(true);
               }
               else
               {
                    hearts[i].gameObject.SetActive(false);
               }
          }
     }
}
