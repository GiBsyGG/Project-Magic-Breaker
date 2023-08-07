using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
     public static Action OnOutBallEvent;

     public static Action<int> OnHealthChange; //Se pasan los puntos de vida del jugador

     public static Action<int> OnStreakChange; //Se pasa el valor de la racha que se lleva

     public static Action OnBrickDestroyEvent; 

     //TODO: Evento subida de nivel
}
