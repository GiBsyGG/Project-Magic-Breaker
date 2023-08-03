using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
     [SerializeField]
     private float ballThrust = 5f;

     [SerializeField]
     private float ballMaxSpeed = 6f;

     [SerializeField]
     private float minSpeedThershhold = 4f;

     private float minSpeedInitial;
     private float maxSpeedInitial;

     private bool ballInGame = false; // flag para controlar si la bola en juego

     [SerializeField]
     private Transform platform;

     private Rigidbody2D ballRigidbody;

     private void Start()
     {
          ballRigidbody = GetComponent<Rigidbody2D>();

          minSpeedInitial = minSpeedThershhold;
          maxSpeedInitial = ballMaxSpeed;

          GameEvents.OnOutBallEvent += ResetBall;
     }

     private void OnDestroy()
     {
          GameEvents.OnOutBallEvent -= ResetBall;
     }

     // Update is called once per frame
     void Update()
    {
          if (!ballInGame)
          {
               StickToPlatform();

               if (Input.GetKeyDown("space"))
               {
                    ImpulseBall();
               }
          }
          else
          {
               SpeedStabilizing();
          }
    }

     private void OnCollisionEnter2D(Collision2D collision)
     {
          if (collision.collider.CompareTag("Platform"))
          {

               // Solo se redireccionara al pegar arriba
               if(collision.GetContact(0).normal == new Vector2(0, 1))
                    RedirectBall();
          }
     }

     /// <summary>
     /// Funcion para que la bola tome una velocidad
     /// </summary>
     private void ImpulseBall()
     {
          ballInGame = true;

          float xRand = UnityEngine.Random.Range(-1f, 1f);
          Vector2 dir = new Vector2(xRand, 1).normalized;

          // Divido entre mil ya que la masa es muy pequeña entonces el impulso tambien debe serlo
          ballRigidbody.AddForce(dir * ballThrust / 10000, ForceMode2D.Impulse);
     }

     /// <summary>
     /// Funcion para mantener la bola entre una velocidad minima y maxima
     /// </summary>
     private void SpeedStabilizing()
     {
          // Restringir la velocidad de la bola
          ballRigidbody.velocity = Vector3.ClampMagnitude(ballRigidbody.velocity, ballMaxSpeed);
          //Debug.Log(ballRigidbody.velocity.magnitude);
          // Darle una velocidad minima a la bola
          if (ballRigidbody.velocity.magnitude < minSpeedThershhold)
          {  
               ballRigidbody.velocity = ballRigidbody.velocity.normalized * ballThrust;
          }
     }

     /// <summary>
     /// Funcion para pegar la bola a la plataforma en x
     /// </summary>
     private void StickToPlatform()
     {
          // Pegar la bola a la plataforma manteniendo la misma posición relativa.
          Vector3 ballPosition = transform.position;
          Vector3 platformPosition = platform.position;
          ballPosition.x = platformPosition.x;
          transform.position = ballPosition;
     }

     /// <summary>
     /// Funcion que calculara una direccion para que vaya la bola dependiendo del punto donde pegue la plataforma
     /// </summary>
     private void RedirectBall()
     {
          float xDir = HitPlatformFactor();

          // calcula la direccion de a donde debe ir segun el punto de la plataforma impactado
          Vector2 dir = new Vector2(xDir, 1).normalized;

          ballRigidbody.velocity = dir * ballThrust;
     }

     /// <summary>
     /// Calcula un factor (de -1 a 1) de donde pega la bola en la plataforma
     /// </summary>
     /// <returns>factor de golpe en la plataforma</returns>
     private float HitPlatformFactor()
     {
          // Con esto se calcula en que punto de -1 hasta 1 de la plataforma pego la bola
          float factor = (this.transform.position.x - platform.position.x) / platform.localScale.x;

          return factor;
     }

     /// <summary>
     /// Devuelve la bola a estado inicial
     /// </summary>
     private void ResetBall()
     {
          ballRigidbody.velocity = Vector3.zero;

          // Posicionamos por encima de la plataforma
          transform.position = platform.position + new Vector3(0, 0.5f, 0);

          ballInGame = false;

          // Devolvemos las velocidades maximas y minimas
          ballMaxSpeed = maxSpeedInitial;
          minSpeedThershhold = minSpeedInitial;
     }

     /// <summary>
     /// Getter y Setter para la variable minSpeedThershhold
     /// </summary>
     public float MinSpeedThershhold
     {
          get
          {
               return minSpeedThershhold;
          }

          set
          {
               minSpeedThershhold = value;
          }
     }

     /// <summary>
     /// Getter y Setter para la variable ballMaxSpeed
     /// </summary>
     public float BallMaxSpeed
     {
          get
          {
               return ballMaxSpeed;
          }

          set
          {
               ballMaxSpeed = value;
          }
     }
}
