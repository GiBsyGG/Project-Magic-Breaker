using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDBounceBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

     private void Start()
     {
          // Reiniciamos el valor de la racha
          slider.value = 0;

          GameEvents.OnStreakChange += SetStreak;
     }

     private void OnDestroy()
     {
          GameEvents.OnStreakChange -= SetStreak;
     }

     public void SetMaxStreak(int maxStreak)
     {
          slider.maxValue = maxStreak;
     }

     private void SetStreak(int streak)
     {
          slider.value = streak;
     }
}
