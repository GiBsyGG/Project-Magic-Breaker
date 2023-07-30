using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScreen : MonoBehaviour
{

     [SerializeField]
     private Button startGameplay;

    // Start is called before the first frame update
    void Start()
    {
          // TODO: A�adir interaccion en la UI con el teclado
          startGameplay.onClick.AddListener(OnStartButtonClicked);
    }

     private void OnStartButtonClicked()
     {
          // Para evitar varias interacciones con el boton
          startGameplay.interactable = false;

          GameManager.Instance.StartGameplay();
     }
}
