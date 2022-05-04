using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    Animator myAnimator;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    [SerializeField] float moveSpeed = 10f;
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }
    void Run()
    {
        Vector2 PlayerVelocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
        myRigidbody.velocity = PlayerVelocity;
        bool playerHasSpeed = Mathf.Abs(myRigidbody.velocity.x+myRigidbody.velocity.y) > Mathf.Epsilon;

        myAnimator.SetBool("Running", playerHasSpeed);
    }


}

