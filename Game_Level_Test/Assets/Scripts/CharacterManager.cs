using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    CharacterController2d controller;
    Animator animator2d;
    Rigidbody2D rigidbody2d;

    private bool canMove;
    public bool CanMove
    {
        get { return canMove; }
        set { canMove = value; }
    }

    public float horizontalMove = 0f;

    public float moveSpeed;

    public bool jump;

    private int coins;

    private bool enemyHit;
    public bool EnemyHit
    {
        get { return enemyHit; }
        set { enemyHit = value; }
    }
    public int Coins
    {
        get { return coins; }
        set { coins = value; }
    }


    private int hearts;
    public int Hearts
    {
        get { return hearts; }
        set { hearts = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController2d>();
        animator2d = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        coins = 0;
        hearts = 3;
        canMove = true;
    }

    private void Update()
    {
        if (!canMove)
        {
            horizontalMove = 0f;
            animator2d.SetFloat("moveX", horizontalMove);
        }

        if (canMove)
        {

            horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
            animator2d.SetFloat("moveX", horizontalMove);

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }


            if (Input.GetKeyDown(KeyCode.F))
            {
                animator2d.SetTrigger("attackTrigger");
                if(enemyHit)
                {
                    GetComponentInChildren<SwordScript>().Enemy.GetComponent<MushroomScript>().Hit();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
