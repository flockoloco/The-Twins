using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 10f;
    private Rigidbody2D rb;
    private Animator animator;

    private Vector3 moveDirection;
    private Vector3 dodgeDirection;
    private float dodgeSpeed;
    private float dodgeTimer = 0f;
    public bool invunerable;
    public GameObject playersword;
    public GameObject playerbow;
    public swordscript swordScript;
    public BowScript bowScript;

    public enum weaponState
    {
        sword,
        bow,
    }
    private weaponState weapon;

    private int health;

    // define a type of state
    public enum State
    {
        walking,
        dodging,
        hit,
    }

    public State state;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        state = State.walking;
        weapon = weaponState.sword;

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q)) {
            if (weapon == weaponState.sword && swordScript.rotatoFrezeto == false)
            {
                weapon = weaponState.bow;
            }else if(weapon == weaponState.bow && bowScript.rotatoFrezeto == false)
            {
                weapon = weaponState.sword;
            }
        }
        switch (weapon)
        {
            case weaponState.sword:
                playersword.SetActive(true);
                playerbow.SetActive(false);
                break;
            case weaponState.bow:
                playersword.SetActive(false);
                playerbow.SetActive(true);
                break;
        }

        //switch between the walking state to
        switch (state)
        {
            case State.walking:

                gameObject.GetComponent<PlayerStats>().invunerable = false;


                dodgeTimer -= Time.deltaTime;

                float moveX = 0f;
                float moveY = 0f;

                moveX = Input.GetAxisRaw("Horizontal");
                moveY = Input.GetAxisRaw("Vertical");

                moveDirection = new Vector3(moveX, moveY).normalized;

                animator.SetFloat("Horizontal", moveX);
                animator.SetFloat("Speed", moveDirection.sqrMagnitude);

                if (Input.GetKeyDown(KeyCode.Space) && (dodgeTimer <= 0) && (moveX != 0 || moveY != 0))
                {
                    dodgeDirection = moveDirection;
                    dodgeSpeed = 40f;
                    state = State.dodging;
                    dodgeTimer = 2f; 
                }
                break;
                //this dodging state 
            case State.dodging:
                //transicao para estado de walking enquanto diminui a velocidade do dodge

                gameObject.GetComponent<PlayerStats>().invunerable = true;

                float dodgeSpeedDropper = 2f;
                dodgeSpeed -= dodgeSpeed * dodgeSpeedDropper * Time.deltaTime;

                float dodgeSpeedMin = 30f;
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
            case State.hit:
                
                break;
            case State.walking:
                rb.velocity = moveDirection * moveSpeed;
                break;
            case State.dodging:
                rb.velocity = dodgeDirection * dodgeSpeed;
                break;
        }   
    }
}