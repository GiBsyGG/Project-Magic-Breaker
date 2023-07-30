using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
     [SerializeField]
     private Button backToMenu;

     // Start is called before the first frame update
     void Start()
     {
          // TODO: Añadir interaccion en la UI con el teclado
          backToMenu.onClick.AddListener(OnBackToMenuClicked);
     }

     private void OnBackToMenuClicked()
     {
          // Para evitar varias interacciones con el boton
          backToMenu.interactable = false;

          GameManager.Instance.MainMenu();
     }
}
