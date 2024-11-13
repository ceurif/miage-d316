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

  void Update() {
    isGrounded = Physics2D.OverlapArea (groundCheckLeft.position, groundCheckRight.position);
    horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
    if (Input.GetButtonDown("Jump") && isGrounded)  {
      isJumping = true;
    }
  }

  void FixedUpdate() {
      MovePlayer(horizontalMovement);
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
