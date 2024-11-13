using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float moveSpeed;

  public Rigidbody2D rb;

  public float jumpForce;
  public bool isJumping;
  public bool isGrounded;

  public Transform groundCheckLeft;
  public Transform groundCheckRight;

  private Vector3 velocity = Vector3.zero;
  private float horizontalMovement;

  public Animator animator;
  public SpriteRenderer spriteRenderer;

  void Update() {
    isGrounded = Physics2D.OverlapArea (groundCheckLeft.position, groundCheckRight.position);
    horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
    if (Input.GetKey(KeyCode.RightShift)) {
      horizontalMovement *= 2;
    }

    if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)  {
      isJumping = true;
    }

    // Animation de la vitesse
      float characterVelocity = Mathf.Abs(rb.velocity.x);
      animator.SetFloat("speed", characterVelocity);

      // Détection de la direction pour retourner le joueur
      if (horizontalMovement > 0) {
          spriteRenderer.flipX = false; // Face vers la droite
      } else if (horizontalMovement < 0) {
          spriteRenderer.flipX = true;  // Face vers la gauche
      }

  }

  void FixedUpdate() {
      MovePlayer(horizontalMovement);
      float characterVelocity = Mathf.Abs(rb.velocity.x);
      animator.SetFloat("speed", characterVelocity);
  }

  void MovePlayer(float _horizontalMovement) {
      Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
      rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, -05);

      if (isJumping == true) {
        rb.AddForce(new Vector2(0f, jumpForce));
        isJumping = false;
      }
    }
}
