using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
     [SerializeField]
     private float _ballThrust = 5f;

     [SerializeField]
     private float _ballMaxSpeed = 12f;

     [SerializeField]
     private float _minSpeedThershhold = 10f;

     private bool _ballInGame = false; // flag para controlar si la bola en juego

     //TODO: Entero con rebotes para armar combos

     private Rigidbody2D _ballRigidbody;

     private void Start()
     {
          _ballRigidbody = GetComponent<Rigidbody2D>();
     }

     // Update is called once per frame
     void Update()
    {
          if(Input.GetKeyDown("space") && !_ballInGame)
          {
               ImpulseBall();
          }

          // TODO: Implementar la aceleracion con el tiempo o cantidad de rebotes a la bola
          // TODO: A medida que la bola acelera estos valores minimos y maximos van cambiando tambien
          // TODO: Dependiendo donde golpee la bola en la plataforma se direccione, para que el jugador tenga cierto control de la bola
          // Restringir la velocidad de la bola
          _ballRigidbody.velocity = Vector3.ClampMagnitude(_ballRigidbody.velocity, _ballMaxSpeed);

          // Darle una velocidad minima a la bola
          if(_ballRigidbody.velocity.magnitude < _minSpeedThershhold)
          {
               _ballRigidbody.velocity = _ballRigidbody.velocity.normalized * _ballThrust;
          }

          Debug.Log(_ballRigidbody.velocity.magnitude);
    }

     private void ImpulseBall()
     {
          _ballInGame = true;

          float xRand = UnityEngine.Random.Range(-1f, 1f);
          Vector2 _dir = new Vector2(xRand, 1).normalized;

          // Divido entre mil ya que la masa es muy pequeña entonces el impulso tambien debe serlo
          _ballRigidbody.AddForce(_dir * _ballThrust / 10000, ForceMode2D.Impulse);
     }
}
