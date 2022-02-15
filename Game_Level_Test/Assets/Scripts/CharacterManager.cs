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

    // Start is called before the first frame update
    void Start()
    {
        animator2d = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
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
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
