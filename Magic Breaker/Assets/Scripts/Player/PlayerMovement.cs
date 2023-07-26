using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
     [SerializeField]
     [Range(0f, 1f)]
     private float LerpConstant = 0.5f;

     [SerializeField]
     private float platformSpeed = 7f;

     private Rigidbody2D platformRigidbody;

     private void Start()
     {
          platformRigidbody = GetComponent<Rigidbody2D>();
     }

     // Usamos FixedUpdate al no usar el deltaTime
     // Si usamos deltaTime no usamos le FixedUpdate
     void FixedUpdate()
     {
          float dir = Input.GetAxis("Horizontal");

          // El movimiento es en X
          Vector2 movement = new Vector2(dir, platformRigidbody.velocity.y);

          // Como estamos actualizando la velocidad, no usamos deltatime
          // La interpolacion es para movimientos suaves de una velocidad a otra
          platformRigidbody.velocity = Vector2.Lerp(platformRigidbody.velocity, movement * platformSpeed, LerpConstant);
     }
}
