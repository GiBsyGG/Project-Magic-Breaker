using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

     public static GameManager Instance;

     //TODO: Añadir algun tipo de puntuacion

     private void Awake()
     {
          if (Instance == null)
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
          MainMenu();

          //TODO: Añadir niveles por tanto evento de subida ne nivel para suscribirlo aqui

     }

     // Update is called once per frame
     void Update()
     {

     }

     public void MainMenu()
     {
          HandleMenu();
     }

     public void StartGameplay()
     {
          HandleGameplay();
     }

     public void WinGame()
     {
          HandleWinGame();
     }

     public void GameOver()
     {
          HandleGameOver();
     }

     private void HandleMenu()
     {
          SceneManager.LoadScene("Scene_Menu");
     }

     private void HandleGameplay()
     {
          SceneManager.LoadScene("Scene_Gameplay");
     }

     private void HandleGameOver()
     {
          SceneManager.LoadScene("Scene_GameOver");
     }

     private void HandleWinGame()
     {
          //TODO: Añadir logica de siguiente nivel y una pequeña transicion
          SceneManager.LoadScene("Scene_Win");
     }
}
