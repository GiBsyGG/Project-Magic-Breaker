using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
     [SerializeField]
     [Range(0f, 1f)]
     private float LerpConstant = 0.5f;

     [SerializeField]
     private float platformSpeed = 7f;

     private Rigidbody2D platformRigidbody;

     private PlayerInput playerInput;

     private void Start()
     {
          platformRigidbody = GetComponent<Rigidbody2D>();
          playerInput = GetComponent<PlayerInput>();
     }

     // Usamos FixedUpdate al no usar el deltaTime
     // Si usamos deltaTime no usamos le FixedUpdate
     void FixedUpdate()
     {
          // Usando el nuevo sistema de inputs de Unity
          Vector2 movement = playerInput.actions["Move"].ReadValue<Vector2>();

          // Como estamos actualizando la velocidad, no usamos deltatime
          // La interpolacion es para movimientos suaves de una velocidad a otra
          platformRigidbody.velocity = Vector2.Lerp(platformRigidbody.velocity, movement * platformSpeed, LerpConstant);
     }
}
