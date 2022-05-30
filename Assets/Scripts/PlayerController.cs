using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Collider2D feet;

    public bool isActive = true;

    Vector2 moveDirection;
    Vector2 rawInput;
    bool isJumping;
    Rigidbody2D rb;


    const string platformLayer = "Platform";

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Move the player
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);

        if (Input.GetButton("Jump")) OnJump();
        //Make the player jump
        if (isJumping)
        {
            rb.velocity += new Vector2(0f, jumpForce);
            isJumping = false;
        }
    }
    /*
    //Used by the input system 
    void OnMove(InputValue value)
    {
        if (!isActive) { return; }
        rawInput = value.Get<Vector2>();
    }
    */
    //Used by the input system
    void OnJump()
    {
        if (!isActive) { return; }
        if (!feet.IsTouchingLayers(LayerMask.GetMask(platformLayer))) { return; }

        isJumping = true;
    }
}
