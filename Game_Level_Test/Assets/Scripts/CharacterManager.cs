using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public CharacterController2d controller;
    public Animator animator2d;
    public Rigidbody2D rigidbody2d;

    public float horizontalMove = 0f;

    public float moveSpeed;

    public bool jump;

    public int coins;

    // Start is called before the first frame update
    void Start()
    {
        animator2d = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        coins = 0;
    }

    private void Update()
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
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }

    public void UpgradeCoins()
    {
        coins++;
    }

    public int GetNumberOfCoins()
    {
        return coins;
    }
}
