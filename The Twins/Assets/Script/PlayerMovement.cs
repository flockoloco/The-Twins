using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody2D rb;
    private Animator animator;

    private Vector3 moveDirection;
    private Vector3 dodgeDirection;
    private float dodgeSpeed;
    float dodgeTimer = 0f;

    // define a type of state
    private enum State
    {
        walking,
        dodging,
    }

    private State state;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        state = State.walking;
    }

    void Update()
    {
        //switch between the walking state to
        switch (state)
        {
            case State.walking:
                dodgeTimer -= Time.deltaTime;

                float moveX = 0f;
                float moveY = 0f;

                moveX = Input.GetAxisRaw("Horizontal");
                moveY = Input.GetAxisRaw("Vertical");

                moveDirection = new Vector3(moveX, moveY).normalized;

                animator.SetFloat("Horizontal", moveX);
                animator.SetFloat("Speed", moveDirection.sqrMagnitude);

                if (Input.GetKeyDown(KeyCode.Space) && dodgeTimer <= 0)
                {
                    dodgeDirection = moveDirection;
                    dodgeSpeed = 75f;
                    state = State.dodging;
                    dodgeTimer = 2f; 
                }
                break;
                //this dodging state 
            case State.dodging:
                //transicao para estado de walking enquanto diminui a velocidade do dodge
                float dodgeSpeedDropper = 5f;
                dodgeSpeed -= dodgeSpeed * dodgeSpeedDropper * Time.deltaTime;

                float dodgeSpeedMin = 50f;
                if (dodgeSpeed < dodgeSpeedMin)
                {
                    state = State.walking;
                }
                break;
        }
    }

    void FixedUpdate()
    {
        switch (state)
        {
            case State.walking:
                rb.velocity = moveDirection * moveSpeed;
                break;
            case State.dodging:
                rb.velocity = dodgeDirection * dodgeSpeed;
                break;
        }   
    }
}
