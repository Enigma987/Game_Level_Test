using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    MovementController controller;
    Animator animator2d;

    private bool canMove;
    public bool CanMove
    {
        get { return canMove; }
        set { canMove = value; }
    }

    private float horizontalMove = 0f;

    public float moveSpeed;

    private bool jump;

    private int coins;
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
        controller = GetComponent<MovementController>();
        animator2d = GetComponent<Animator>();
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
                jump = true;

            if (Input.GetKeyDown(KeyCode.F))
            {
                animator2d.SetTrigger("attackTrigger");
                GetComponentInChildren<SwordScript>().EnemyHit();
            }
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
