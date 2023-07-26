using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
     [SerializeField]
     [Range(0f, 1f)]
     private float _LerpConstant = 0.5f;

     [SerializeField]
     private float _platformSpeed = 7f;

     private Rigidbody2D _rb;

     private void Start()
     {
          _rb = GetComponent<Rigidbody2D>();
     }

     // Usamos FixedUpdate al no usar el deltaTime
     // Si usamos deltaTime no usamos le FixedUpdate
     void FixedUpdate()
     {
          float _dir = Input.GetAxis("Horizontal");

          // El movimiento es en X
          Vector2 movement = new Vector2(_dir, _rb.velocity.y);

          // Como estamos actualizando la velocidad, no usamos deltatime
          // La interpolacion es para movimientos suaves de una velocidad a otra
          _rb.velocity = Vector2.Lerp(_rb.velocity, movement * _platformSpeed, _LerpConstant);
     }
}
